using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment02.DTOs.Product
{
    public class UpdateProductRequest
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string? Manufacture { get; set; }
    }
}