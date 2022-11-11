using Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    public class BookRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        public int UserId { get; set; }
        public User? RequestedByUser { get; set; }
        public DateTime? RequestedDate { get; set; }
        public RequestBookStatus Status { get; set; }
        public int? ApprovalById { get; set; }
        public User? ApprovalModifiedByUser { get; set; }
        public ICollection<BookRequestDetail>? BookRequestDetails { get; set; }
    }
}
