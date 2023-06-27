using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventuresApp.Models
{
    public class OrderListingViewModel
    {
        public string Id { get; set; }
        public string OrderedOn { get; set; }
        public string EventId { get; set; }

        [Display(Name = "Event")]
        public string EventName { get; set; }
        public string EventStart { get; set; }
        public string EventEnd { get; set; }
        public string EventPlace { get; set; }
        public string CustomerId { get; set; }

        [Display(Name = "Customer")]
        public string CustomerUsername { get; set; }
        public int TicketsCount { get; set; }
    }
}
