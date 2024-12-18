using System.Collections.Generic;

namespace asm.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public Address Address { get; set; }
        public ICollection<Enrolment> Enrolments { get; set; }
    }
}
