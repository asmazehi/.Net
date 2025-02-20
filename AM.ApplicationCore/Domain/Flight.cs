﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string? Airline { get; set; }
        public string? Departure { get; set; }
        public string? Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public Plane MyPlane { get; set; }
        public ICollection<Passenger> ListPassengers { get; set; }
        public override string ToString()
        {
            return $"FlightId: {FlightId}, Departure: {Departure}, Destination: {Destination}, EffectiveArrival: {EffectiveArrival}, EstimatedDuration: {EstimatedDuration}, FlightDate: {FlightDate}";
        }

    }
}
