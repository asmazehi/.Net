using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }
        [Display(Name = "Date of birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }
        public FullName FullName { get; set; }
        [Key]
        [StringLength(7)]
        public string? PassportNumber { get; set; }
        [RegularExpression(@"^[0-9]{8}$")]
        public string? TelNumber { get; set; }
        public ICollection<Flight> MyFlightss { get; set; }
        public override string ToString()
        {
            return (FullName.ToString() + "\nEmailAddress : " + EmailAddress + " \n");
        }
        // polymorphisme 
        public bool CheckProfile(String fn, string ln)
        {
            return (FullName.FirstName.Equals(fn) && FullName.LastName.Equals(ln));
        }

        public bool CheckProfile(String fn, string ln, string email)
        {
            return (FullName.FirstName.Equals(fn) && FullName.LastName.Equals(ln) && EmailAddress.Equals(email));
        }
        public bool CheckProfileComplete(String fn, string ln, string? email = null)
        {
            return (FullName.FirstName.Equals(fn) && FullName.LastName.Equals(ln) && (EmailAddress.Equals(email) || email == null));
        }
        // polymorphisme + héritage : virtual
        public virtual void PassengerType()
        {
            Console.WriteLine(" i am a passenger \n");
        }
    }
    }
