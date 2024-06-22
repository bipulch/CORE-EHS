using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.backend.Models
{
    // CarModel.cs
    public class CarModel
    {
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required, RegularExpression(@"^[a-zA-Z0-9]{10}$", ErrorMessage = "Model Code must be 10 alphanumeric characters.")]
        public string ModelCode { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Features { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime DateOfManufacturing { get; set; }
        public bool Active { get; set; }
        public int SortOrder { get; set; }
        // Additional properties as needed
    }
}
