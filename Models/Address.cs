namespace asm.Models
{
    public class Address
    {
        public int AddressID {  get; set; }
        public int StudentID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Student Student { get; set; }
    }
}
