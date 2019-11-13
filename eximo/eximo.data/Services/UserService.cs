using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eximo.core.Models;

namespace eximo.data.Services
{
    public class UserService : IUserService
    {
        private EximoDataContext _eximoContextRef;

        public UserService(string dbPath)
        {
            _eximoContextRef = new EximoDataContext(dbPath);
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
