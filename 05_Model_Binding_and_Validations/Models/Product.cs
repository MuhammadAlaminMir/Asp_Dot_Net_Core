using System.ComponentModel.DataAnnotations;

namespace _5_Model_Binding_and_Validations.Models
{
    public class Product
    {
        public string? Title { get; set; }

        public string? OwnerName { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        public List<string?> Tags { get; set; } = new List<string?>();

        public override string ToString()
            {
                return $"Title: {Title}, Price: {Price}, Owner Name: {OwnerName}";
        }
    }
}
