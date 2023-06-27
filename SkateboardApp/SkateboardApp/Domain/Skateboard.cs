using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardApp.Domain
{
    public class Skateboard : Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      //  public string Id { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int Count { get; set; }
      //  public decimal Price { get; set; }
    }
}
