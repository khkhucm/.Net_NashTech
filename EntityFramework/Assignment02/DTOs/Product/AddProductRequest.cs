namespace Assignment02.DTOs.Product
{
    public class AddProductRequest
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string? Manufacture { get; set; }
    }
}