using System.ComponentModel.DataAnnotations;

namespace MVCCRUD.Models
{
    public class Product
    {
        [Key]
        public int pid {  get; set; }
        public string? pname { get; set; }
        public string? pcat { get; set; }
        public string? picture { get; set; }

        public double price { get; set; }
    }
}
