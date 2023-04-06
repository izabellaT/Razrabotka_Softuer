using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Model
{
    public class Order
    {
        public Order()
        {
        }
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }
        public int IdProduct { get; set; }
        [Required]
        public Product Product { get; set; }

        public int IdClient { get; set; }
        [Required]
        public Client Client { get; set; }

        [Required]
        public decimal TotalPrice => this.Product.Price * Quantity - this.Product.Discount * Quantity;

        [Required]
        public int Quantity { get; set; }
    }
}
