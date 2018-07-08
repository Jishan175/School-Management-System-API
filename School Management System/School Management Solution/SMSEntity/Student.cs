using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSEntity
{
    public class Student:Entity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public int ClassRoll { get; set; }
        public string Religion { get; set; }
        public string FatherName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Class { get; set; }
        public string Section { get; set; }
        public string Password { get; set; }
        public int ClassId { get; set; }

        
    }
}
