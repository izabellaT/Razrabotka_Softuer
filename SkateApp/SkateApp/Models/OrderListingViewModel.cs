using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkateApp.Models
{
    public class OrderListingViewModel
    {
        public string Id { get; set; }
        public string OrderedOn { get; set; }
        public string SkateboardId { get; set; }

        [Display(Name = "Product")]
        public string SkateboardName { get; set; }
        public string CustomerId { get; set; }

        [Display(Name = "Customer")]
        public string CustomerUsername { get; set; }
        public int SkateboardsCount { get; set; }
    }
}
