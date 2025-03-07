using NextGen_BM_BE_Domain.Entities;

namespace NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces
{
    public interface IJwtService
    {
        Task<string> GenerateJwtToken(User user);
    }
}
