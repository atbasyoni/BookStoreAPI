using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // User successfully registered, optionally log them in or return confirmation message
                    return Ok("Account Add Success");
                }
                return BadRequest("Error registering user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(model.Username);

                if(user != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(user, model.Password);
                    if(found) 
                    {
                        //Claims Token
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        //get Role
                        var roles = await _userManager.GetRolesAsync(user);
                        foreach(var role in roles) 
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        SecurityKey secuirtyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

                        SigningCredentials signincred = new SigningCredentials(secuirtyKey, SecurityAlgorithms.HmacSha256);

                        //Create Token
                        JwtSecurityToken mytoken = new JwtSecurityToken(
                            issuer: "http://localhost:16123/",
                            audience: "http://localhost:4200/",
                            claims: claims,
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: signincred
                        );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                            expiration = mytoken.ValidTo
                        });
                    }
                }
                return Unauthorized();
            }
            return Unauthorized();
        }

        //public async Task<IActionResult> Logout()
        //{
        //    return BadRequest();
        //}

        //public async Task<IActionResult> PasswordReset()
        //{
        //    return BadRequest();
        //}
    }
}
