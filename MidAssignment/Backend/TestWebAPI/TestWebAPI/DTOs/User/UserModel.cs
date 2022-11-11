using Common.Enums;

namespace TestWebAPI.DTOs.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public UserRoleEnum Role { get; set; }
    }
}
