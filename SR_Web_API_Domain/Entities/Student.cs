using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR_WebAPI_Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string NIC { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }

    }
}
