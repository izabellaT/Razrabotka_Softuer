using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Model
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Discount { get; set; }
        public int IdCategory { get; set; }
        public Category Category { get; set; }
        public int IdBrand { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
