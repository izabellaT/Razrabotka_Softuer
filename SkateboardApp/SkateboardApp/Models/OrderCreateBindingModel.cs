using SkateboardApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardApp.Models
{
    public class OrderCreateBindingModel
    {
        [Required]
        public string ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Products")]
        public int Count { get; set; }
        public Category Category { get; set; }
        public string Price { get; set; }
    }
}
