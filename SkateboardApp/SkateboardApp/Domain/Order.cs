﻿using SkateboardApp.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SkateboardApp.Domain
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime OrderedOn { get; set; }
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Category Category { get; set; }
        public string CustomerId { get; set; }
        public virtual SkateboardsUser Customer { get; set; }
        public int Count { get; set; }
        
    }
}
