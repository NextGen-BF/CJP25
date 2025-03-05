using System.Security.Cryptography;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NextGen_BM_BE_Domain.Entities;
using NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces;
using NextGen_BM_BE_Domain.ViewModels;


namespace NextGen_BM_BE_Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        public AuthService(UserManager<User> userManager, IJwtService jwtService, IConfiguration config)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _config = config;
        }
        public async Task<string> LoginAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var token = _jwtService.GenerateJwtToken(user);
                return token;
            }
            return null;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterModel registerModel)
        {
            var user = new User { UserName = registerModel.Email, Email = registerModel.Email, FirstName = registerModel.FirstName, LastName = registerModel.LastName };
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            return result;
        }

        public async Task<string> LoginWithGoogleAsync(string googleToken)
        {
            try
            {
                var result = await ValidateGoogleToken(googleToken);
                if (result == null)
                    return null;
                var user = await _userManager.FindByEmailAsync(result.Email);
                var token = _jwtService.GenerateJwtToken(user);
                var refreshToken = GenerateRefreshToken();
                //TODO: Insert refresh token to database
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception("Could not login with provided google token", ex);
            }
        }

        private async Task<GoogleJsonWebSignature.Payload?> ValidateGoogleToken(string googleToken)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _config.GetSection("Authentication:Google:ClientId").Value }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(googleToken, settings);
                return payload;
            }
            catch (Exception ex)
            {
                throw new Exception("Google Token could not be validated. ", ex);
            }
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}