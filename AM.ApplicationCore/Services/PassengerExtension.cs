using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services
{
    public static class PassengerExtension
    {
        public static void UpperFullName(this Passenger p) {
            p.FirstName = p.FirstName[0].ToString().ToUpper()+p.FirstName.ToString().Substring(1);
            p.LastName = p.LastName[0].ToString().ToUpper() + p.LastName.ToString().Substring(1);
        }
    }
}
 //partie mtaa les methodes d extension