﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight : IService<Flight>
    {
        bool IsAvailable(Flight flight, int i);
        public IList<Staff> GetStaff(int id);
        public IList<Traveller> GetPassengers(Plane plane , DateTime date);
        public Dictionary<DateTime, int> GetTravellerCountByFlightDate(DateTime startDate, DateTime endDate);


    }

}
