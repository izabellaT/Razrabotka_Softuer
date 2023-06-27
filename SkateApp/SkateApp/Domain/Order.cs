using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkateApp.Domain
{
    public class Order
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string Id { get; set; }
            public DateTime OrderedOn { get; set; }
            public string SkateboardId { get; set; }
            public virtual Skateboard Skateboard { get; set; }
            public string CustomerId { get; set; }
            public virtual SkateboardsUser Customer { get; set; }
            public int SkateboardsCount { get; set; }

            public IEnumerable<Order> Orders { get; set; } = new List<Order>();
        }
    }

