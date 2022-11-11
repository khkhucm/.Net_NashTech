using Test.Data.Entities;
using Test.Data.Repositories.Interfaces;
using TestWebAPI.DTOs.User;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public LoginResponse? LoginUser(LoginRequest loginRequest)
        {
            var user = _userRepository.Get(x => x.UserName.ToLower() == loginRequest.Username.Trim().ToLower()
                                        && x.Password.ToLower() == loginRequest.Password.Trim().ToLower());

            if (user == null)
            {
                return null;
            }

            return new LoginResponse
            {
                Id = user.Id,
                Username = user.UserName,
                Role = user.Role.ToString()
            };
        }

    }
}
