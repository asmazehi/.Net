﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public IUnitOfWork unitOfWork;
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public bool IsAvailable(Flight flight, int n)
        {

            int capacity = flight.MyPlane.Capacity;
            int tickets = flight.ListTickets.Count;

            return n >= capacity - tickets;
        }

        public IList<Staff> GetStaff(int id)
        {
            Flight flight = GetById(id);
            return flight.ListTickets
                .Select(t => t.MyPassenger)
                .OfType<Staff>()
                .Distinct()
                .ToList();
        }

        public IList<Traveller> GetPassengers(Plane plane, DateTime date)
        {
            return plane.ListFlights.Where(f => f.FlightDate.Date == date)
                .SelectMany(f => f.ListTickets)
                .Select(t => t.MyPassenger)
                .OfType<Traveller>()
                .Distinct()
                .ToList();
        }
        public Dictionary<DateTime, int> GetTravellerCountByFlightDate(DateTime startDate, DateTime endDate)
        {
            return GetMany(f => f.FlightDate >= startDate && f.FlightDate <= endDate)
                .GroupBy(f => f.FlightDate.Date)
                .ToDictionary(
                    g => g.Key,
                    g => g.SelectMany(f => f.ListTickets)
                          .Select(t => t.MyPassenger)
                          .OfType<Traveller>()
                          .Count()
                );
        }
    }
}
