using NextGen_BM_BE_Domain.Entities;

public interface IUserService
{
    Task<User> GetUserById(int userId);
}