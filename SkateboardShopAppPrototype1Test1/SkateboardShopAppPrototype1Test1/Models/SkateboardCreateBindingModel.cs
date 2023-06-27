using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardShopAppPrototype1Test1.Models
{
    public class SkateboardCreateBindingModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Colour")]
        public string Colour { get; set; }

        [Required]
        [Display(Name = "Size")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Features")]
        public string Features { get; set; }

        [Required]
     //   [Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
     //   [Display(Name = "Image1")]
        public string Image1 { get; set; }

        [Required]
     //   [Display(Name = "Image2")]
        public string Image2 { get; set; }

        [Required]
        [Display(Name = "Delivery And Returns")]
        public string DeliveryAndReturns { get; set; }

        [Required]
        [Display(Name = "Count")]
        public int Count { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

    }
}
