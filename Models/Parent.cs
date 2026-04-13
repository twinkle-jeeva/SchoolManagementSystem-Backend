namespace StudentDemoAPI.Models
{
    public class Parent
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Relationship { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public ICollection<Student> Students { get; set; } = new List<Student>();

        public ICollection<EmergencyContact> EmergencyContacts { get; set; } = new List<EmergencyContact>();
    }
}