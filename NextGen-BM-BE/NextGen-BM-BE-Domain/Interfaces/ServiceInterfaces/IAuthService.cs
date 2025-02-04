using Microsoft.AspNetCore.Identity;
using NextGen_BM_BE_Domain.ViewModels;

namespace NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces{
    public interface IAuthService{
        Task<string> LoginAsync(LoginModel loginModel);
        Task<IdentityResult> RegisterAsync(RegisterModel registerModel);
    }
}