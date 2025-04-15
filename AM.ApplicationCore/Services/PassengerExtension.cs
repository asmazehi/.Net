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
            p.FullName.FirstName = p.FullName.FirstName[0].ToString().ToUpper()+p.FullName.FirstName.ToString().Substring(1);
            p.FullName.LastName = p.FullName.LastName[0].ToString().ToUpper() + p.FullName.LastName.ToString().Substring(1);
        }
    }
}
 //partie mtaa les methodes d extension