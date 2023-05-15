using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineTicketsApp.Entities
{
    public class Plane
    {
        public Plane()
        {
            this.Flights = new HashSet<Flight>();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
        public double Obem { get; set; }
        public int Bar { get; set; }
        public int Mesta { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
