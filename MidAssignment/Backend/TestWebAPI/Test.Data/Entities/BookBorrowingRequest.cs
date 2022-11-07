using Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    public class BookBorrowingRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public User RequestedByUser { get; set; }
        public DateTime? RequestedDate { get; set; }
        public RequestBookStatus Status { get; set; }
        public User? RejectedBy { get; set; }
        public User? ApprovedBy { get; set; }
        public ICollection<BookBorrowingRequestDetail>? BookBorrowingRequestDetails { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
