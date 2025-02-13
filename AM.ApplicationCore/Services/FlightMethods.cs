using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight> { }; //liste initialisee a 0

        public IList<DateTime> GetFlightDates(string destination)
        {
            IList<DateTime> dates = new List<DateTime> { };
            //for(int i = 0; i < Flights.Count; i++) {
            //    if (Flights[i].Destination.Equals(destination))
            //    {
            //        dates.Add(Flights[i].FlightDate);
            //    }
            //}
            //foreach (var flight in Flights)
            //{
            //    if (flight.Destination.Equals(destination))
            //    {
            //        dates.Add(flight.FlightDate);
            //    }
            //}
            //return dates;
            //question 9: requete LINQ
            var query = from flight in Flights
                        where flight.Destination == destination
                        select flight.FlightDate;
            return query.ToList();
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination.Equals(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightDate.Equals(DateTime.Parse(filterValue)))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (var flight in Flights)
                    {
                        if (flight.EstimatedDuration== float.Parse(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if (flight.Departure.Equals(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EffectiveArrival":
                    foreach (var flight in Flights)
                    {
                        if (flight.EffectiveArrival == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
            }
        }

        public void ShowFlightDetails(Plane plane)
        {
            var query = from flight in Flights
                        where flight.MyPlane == plane
                        select flight;
            foreach (var item in query)
            {
                Console.WriteLine(item.FlightDate + item.Destination);
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            ////methode 1
            //var query = from flight in Flights
            //            where DateTime.Compare(flight.FlightDate, startDate) > 0 && (flight.FlightDate-startDate).TotalDays > 7
            //            select flight;
            //return query.Count();

            //methode 2
            var query = from flight in Flights
                        where flight.FlightDate > startDate && flight.FlightDate < startDate.AddDays(7)
                        select flight;
            return query.Count();

        }

        public float DurationAverage(string destination)
        {
            var query = from flight in Flights
                        where flight.Destination == destination
                        select flight.EstimatedDuration;
            return query.Average();
        }

        public IList<Flight> OrderedDurationFlights()
        {
            var query = from flight in Flights
                        orderby flight.EstimatedDuration descending
                        select flight;
            return query.ToList();
        }

        public IList<Traveller> SeniorTravellers(Flight flight)
        {
            var query = from passenger in flight.ListPassengers.OfType<Traveller>()
                        orderby passenger.BirthDate ascending
                        select passenger;
            return query.Take(3).ToList();
        }

        public void DestinationGroupedFlights()
        {
            var query = from Flight in Flights
                        group Flight by Flight.Destination;
                foreach (var g in query){
                Console.WriteLine("Destination:"+g.Key);
                foreach (var item in g)
                {
                    Console.WriteLine("Decollage :"+item.FlightDate);
                }

            }
        }
    }
}
