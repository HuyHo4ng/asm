using System.Collections;
using System.Collections.Generic;

namespace asm.Models
{
    public class Lecturer
    {
        public int LecturerID { get; set; }
        public string LecturerName { get; set; }
        public string Department {  get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
