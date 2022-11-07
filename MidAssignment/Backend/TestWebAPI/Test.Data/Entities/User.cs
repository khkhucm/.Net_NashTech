using Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public GenderEnum? Gender { get; set; }
        public int? Age { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public UserRoleEnum Role { get; set; }
        public ICollection<BookBorrowingRequest>? RequestedBorrowingRequests { get; set; }

    }
}
