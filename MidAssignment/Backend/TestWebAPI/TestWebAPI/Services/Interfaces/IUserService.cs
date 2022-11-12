using Test.Data.Entities;
using TestWebAPI.DTOs.User;

namespace TestWebAPI.Services.Interfaces
{
    public interface IUserService
    {
        LoginResponse? LoginUser(LoginRequest loginRequest);
        UserModel? GetUserById(int id);
    }
}
