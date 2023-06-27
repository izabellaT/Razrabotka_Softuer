using SkateboardApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardApp.Models
{
    public class AccessoriesAllViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
    }
}
