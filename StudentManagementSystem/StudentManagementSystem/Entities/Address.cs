using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
