﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<BookBorrowingRequest>? BookBorrowingRequests { get; set; }
    }
}
