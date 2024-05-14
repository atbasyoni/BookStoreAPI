using BookStore.Core.DTOs;
using BookStore.Core.Models;
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
    }
}
