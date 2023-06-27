using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkateApp.Models
{
    public class OrderCreateBindingModel
    {
        [Required]
        public string SkateboardId { get; set; }

        [Required]
        public int SkateboardsCount { get; set; }
    }
}
