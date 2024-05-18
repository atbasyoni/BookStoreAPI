using AutoMapper;
using BookStore.Core.DTOs;
using BookStore.Core.Helpers;
using BookStore.Core.Interfaces;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookStore.EF.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSenderRepository _emailSender;
        private readonly IMapper _mapper;
        private readonly JWT _jwt;

        public AuthRepository(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailSenderRepository emailSender,
            IMapper mapper,
            IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _mapper = mapper;
            _jwt = jwt.Value;
        }

        public async Task<AuthModel> RegisterAsync(RegisterDTO model)
        {
            if(await _userManager.FindByNameAsync(model.UserName) is not null)
                return new AuthModel() { Message = "Username is alerady registered!" };

            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                return new AuthModel() { Message = "Email is already registered!" };

            var user = _mapper.Map<ApplicationUser>(model);

            var result = await _userManager.CreateAsync(user, model.Password);
            
            if(!result.Succeeded)
            {
                var errors = string.Empty;
                foreach(var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AuthModel() { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "User");

            var token = await CreatJwtToken(user);

            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);

            return new AuthModel 
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresOn = token.ValidTo,
                IsAuthenticated = true,
                Message = "Registration Successed",
                Roles = new List<string>() { "User" },
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiredOn
            };
        }

        public async Task<AuthModel> LoginAsync(LoginDTO model)
        {
            var authModel = new AuthModel();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Email or Password is incorrect";
                return authModel;
            }

            var token = await CreatJwtToken(user);
            var roles = await _userManager.GetRolesAsync(user);

            authModel.UserName = user.UserName;
            authModel.Email = user.Email;
            authModel.IsAuthenticated = true;
            authModel.Roles = roles.ToList();
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(token);
            authModel.ExpiresOn = token.ValidTo;

            if(user.RefreshTokens.Any(r => r.IsActive))
            {
                var activeRefershToken = user.RefreshTokens.SingleOrDefault(r => r.IsActive);
                authModel.RefreshToken = activeRefershToken.Token;
                authModel.RefreshTokenExpiration = activeRefershToken.ExpiredOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authModel.RefreshToken = refreshToken.Token;
                authModel.RefreshTokenExpiration = refreshToken.ExpiredOn;
            }
            return authModel;
        }

        public async Task<string> AddRoleAsync(RoleDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user is null || await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";
            
            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Something went wrong!";
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user is null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);
            if(!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);
            return true;
        }

        private async Task<JwtSecurityToken> CreatJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwt.ValidIssuer,
                audience: _jwt.ValidAudiance,
                claims: claims,
                expires:DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signInCredentials
            );
            return token;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var RandomNumber = new Byte[32];
            using var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(RandomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumber),
                ExpiredOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow,
            };
        }

        public async Task<string> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return "Invalid UserId";
            }

            if (user.EmailConfirmed)
            {
                return "The email has already been confirmed.";
            }

            var decodedToken = DecodeToken(token);

            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
            
            if (!result.Succeeded)
            {
                return "An error occurred in your email confirmation.";
            }

            return result.ToString();
        }

        public async Task ForgetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            
            if(user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                _emailSender.ResetPasswordEmail(token, user);
            }
        }

        public string DecodeToken(string token)
        {
            var tokenDecodedBytes = WebEncoders.Base64UrlDecode(token);
            return Encoding.UTF8.GetString(tokenDecodedBytes);
        }

        public async Task<string> ResetPassword(ResetPasswordDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null)
            {
                return "An error occurred while retrieving the user.";
            }

            if (model.Password != model.ConfirmPassword)
            {
                return "The Password doesn't match confirmed password.";
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            
            if (!result.Succeeded) 
            {
                return "An error occurred while changing your password.";
            }

            return result.ToString();
        }

    }
}