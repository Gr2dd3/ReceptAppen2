using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceptAppen2.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Ttl { get; set; }
        public int CustomerRole { get; set; }
        public float Id { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string YearOfBirth { get; set; }
        public int CardType { get; set; }
    }
}
