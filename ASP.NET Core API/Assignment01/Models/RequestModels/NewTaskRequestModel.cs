
using System.ComponentModel.DataAnnotations;

namespace Assignment01.Models.RequestModels
{
    public class NewTaskRequestModel
    {
        public Guid Id { get; set; }
        [Required]
        [MinLength(5)]
        public String Title { get; set; } = null!;
        public bool IsCompleted { get; set; }
    }
}