using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkateApp.Models
{
    public class FavoriteListingViewModel
    {
        public string Id { get; set; }
        public string SkateboardId { get; set; }

        [Display(Name = "Skateboard")]
        public string SkateboardName { get; set; }
        public int SkateboardsCount { get; set; }
        public string CustomerId { get; set; }
        public string CustomerUsername { get; set; }
        public string SkateboardColour { get; set; }
        public string SkateboardSize { get; set; }
        public decimal SkateboardPrice { get; set; }
        public string SkateboardPicture { get; set; }
        
    }
}
