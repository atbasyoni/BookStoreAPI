using BookStore.Core.DTOs;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Interfaces
{
    public interface IAuthRepository
    {
        Task<AuthModel> RegisterAsync(RegisterDTO model);
        Task<AuthModel> LoginAsync(LoginDTO model);
        Task<string> AddRoleAsync(RoleDTO model);
        Task<bool> RevokeTokenAsync(string token);
        Task<string> ConfirmEmail(string userId, string token);
        Task ForgetPassword(string email);
        Task<string> ResetPassword(ResetPasswordDTO model);
    }
}
