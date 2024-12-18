using System.Collections;
using System.Collections.Generic;

namespace asm.Models
{
    public class Course
    {
        public int courseID { get; set; }
        public string courseName { get; set; }
        public int TotalCredits { get; set; }
        public int LecturerID {  get; set; }
        public Lecturer Lecturer { get; set;}
        public ICollection<Enrolment> Enrolments { get; set; }
    }
}
