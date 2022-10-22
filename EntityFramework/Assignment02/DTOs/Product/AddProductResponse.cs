using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment02.DTOs.Product
{
    public class AddProductResponse
    {
        public int ProductId {get; set;}
        public string ProductName {get; set;}
        public int CategoryId {get; set;}
    }
}