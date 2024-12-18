namespace asm.Models
{
    public class Enrolment
    {
        public int EnrolmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }
        public int Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
