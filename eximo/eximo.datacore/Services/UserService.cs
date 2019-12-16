using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using eximo.core.Models;

namespace eximo.datacore.Services
{
    public class UserService : UserDataAccess, IUserService
    {
        private EximoDataContext _eximoContextRef;

        public UserService()
        {
            _eximoContextRef = _eximoContext;
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
