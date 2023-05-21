using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineTicketsApp.Entities
{
    public class Flight
    {
        public Flight()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        public int Id { get; set; }
        public int Number { get; set; }
        public string FDestination { get; set; }
        public string LDestination { get; set; }
        public DateTime Izlitane { get; set; }
        public DateTime Kacane { get; set; }
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
