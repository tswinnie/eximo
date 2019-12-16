using eximo.core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eximo.data.Services
{
    public interface IUserService
    {
        Task<object[]> GetUsersAsync(int userId);
        Task<object[]> AddNewUserAsync(User user);
        Task<object[]> UpdateAUserAsync(User user);
        Task<object[]> RemoveUserAsync(int userId);
    }
}
