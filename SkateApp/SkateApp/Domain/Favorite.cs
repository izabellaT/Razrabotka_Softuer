using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkateApp.Domain
{
    public class Favorite
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string SkateboardId { get; set; }
        public virtual Skateboard Skateboard { get; set; }
        public int SkateboardCount { get; set; }
        public string SkateboardColour { get; set; }
        public string CustomerId { get; set; }
        public virtual SkateboardsUser Customer { get; set; }
        public string SkateboardSize { get; set; }
        public decimal SkateboardPrice { get; set; }
        public string SkateboardPicture { get; set; }
    }
}
