using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Application.Services{
    public class AuthService : IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;

        public AuthService(UserManager<User> userManager, IJwtService jwtService)
        {
            _jwtService = jwtService;
            _userManager = userManager;
        }
        public async Task<string> LoginAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password)){
                var token = _jwtService.GenerateJwtToken(user);
                return token;
            }
            return null;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterModel registerModel)
        {
            var user = new User { UserName = registerModel.Email, Email = registerModel.Email };
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            return result;
        }
    }
}