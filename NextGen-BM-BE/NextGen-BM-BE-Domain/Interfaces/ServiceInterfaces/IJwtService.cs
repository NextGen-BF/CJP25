using NextGen_BM_BE_Domain.Entities;

namespace NextGen_BM_BE_Domain.Interfaces.ServiceInterfaces{
    public interface IJwtService{
        string GenerateJwtToken(User user);
    }
}