using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using eximo.core.Models;
using eximo.data;

namespace eximo.data.Services
{
    public class UserService : IUserService
    {
        private EximoDataContext _eximoContextRef;

        public UserService(EximoDataContext context)
        {
            _eximoContextRef = context;
        }

        public async Task<object[]> AddNewUserAsync(User user)
        {
            var response = await _eximoContextRef.AddUserAsync(user).ConfigureAwait(false);
            return response;

        }

        public async Task<object[]> GetUsersAsync(int userId)
        {
            var response = await _eximoContextRef.GetUserAsync(userId).ConfigureAwait(false);
            return response;
        }

        public async Task<object[]> RemoveUserAsync(int userId)
        {
            var response = await _eximoContextRef.DeleteUserAsync(userId).ConfigureAwait(false);
            return response;
        }

        public async Task<object[]> UpdateAUserAsync(User user)
        {
            var response = await _eximoContextRef.UpdateUserAsync(user).ConfigureAwait(false);
            return response;
        }
    }
}
