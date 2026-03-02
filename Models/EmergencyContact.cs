using System;

namespace StudentDemoAPI.Models
{
    public class EmergencyContact
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public Parent? Parent { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Relationship { get; set; } = string.Empty; 
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}