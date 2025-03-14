using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AM.ApplicationCore.Domain
{
    [PrimaryKey("FlightFK", "PassengerFK")]
    public class Ticket
    {
        public double Prix { get; set; }
        public int Siege { get; set; }
        public bool VIP { get; set; }
        public Flight MyFlight { get; set; }
        public Passenger MyPassenger { get; set; }
        [ForeignKey("MyFlight")]
        public int FlightFK { get; set; }
        [ForeignKey("MyPassenger")]
        public string PassengerFK { get; set; }

    }
}
