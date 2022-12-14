using Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    public class BookRequestDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DetailId { get; set; }
        public RequestBookDetailStatus Status { get; set; } = RequestBookDetailStatus.Waiting;
        public DateTime? ReturnDate { get; set; }
        public int RequestId { get; set; }
        public BookRequest? BookRequest { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
