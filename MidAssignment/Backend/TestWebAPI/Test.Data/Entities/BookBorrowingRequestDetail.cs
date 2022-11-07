using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    public class BookBorrowingRequestDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetailId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RequestId { get; set; }
        public BookBorrowingRequest BookBorrowingRequest { get; set; }
    }
}
