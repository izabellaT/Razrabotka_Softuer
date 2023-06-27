using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardApp.Models
{
    public class OrderListingViewModel
    {
        public string Id { get; set; }
        public string OrderedOn { get; set; }
        public string ProductId { get; set; }
        public string ProductPrice { get; set; }
        public string TotalPrice { get; set; }
        public string Category { get; set; }
        public string CustomerId { get; set; }
        public string CustomerUsername { get; set; }
    }
}
