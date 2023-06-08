﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventuresApp.Models
{
    public class EventCreateBindingModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Place")]
        public string Place { get; set; }

        [Required]
        [Display(Name = "Start")]
        public DateTime Start { get; set; }

        [Required]
        [Display(Name = "End")]
        public DateTime End { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage ="Total tickets must be a possitive number!")]
        [Display(Name = "TotalTickets")]
        public int TotalTickets { get; set; }

        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "Price per ticket must be a possitive number!")]
        [Display(Name = "PricePerTicket")]
        public decimal PricePerTicket { get; set; }

    }
}
