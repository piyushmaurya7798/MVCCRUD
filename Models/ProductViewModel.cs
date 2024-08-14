using System.ComponentModel.DataAnnotations;

namespace MVCCRUD.Models
{
    public class ProductViewModel
    {
        [Key]
        public int pid { get; set; }
        public string? pname { get; set; }
        public string? pcat { get; set; }
        public IFormFile? picture { get; set; }

        public double price { get; set; }
    }
}
