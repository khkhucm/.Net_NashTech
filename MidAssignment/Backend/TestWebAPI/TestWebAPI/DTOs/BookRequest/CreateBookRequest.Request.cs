using System.ComponentModel.DataAnnotations;
using TestWebAPI.DTOs.User;

namespace TestWebAPI.DTOs.BookRequest
{
    public class CreateBookRequestRequest
    {
        [Required] 
        public List<int> BookIds { get; set; }
        //public UserModel? Requester { get; set; }
    }
}
