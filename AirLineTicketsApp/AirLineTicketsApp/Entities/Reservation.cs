using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineTicketsApp.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        [ForeignKey("Client")]
        [Required]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Flight")]
        [Required]
        public int FlightId { get; set; }
        public Flight Flight { get; set; }     

        public DateTime DataiChas { get; set; }
        public int BroiBileti { get; set; }
        public decimal TotalPrice => BroiBileti*Flight.Price - (Flight.Discount* Flight.Price)/100;
    }
}
