using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.Entities;

namespace NextGen_BM_BE_Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<User> GetUserById(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return user;
        }
    }
}