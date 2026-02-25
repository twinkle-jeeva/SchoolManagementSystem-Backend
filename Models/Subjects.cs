using System;

namespace StudentDemoAPI.Models
{
    public class Subject
    {
        public int Id { get; set; }                  
        public string Code { get; set; } = string.Empty;  
        public string Name { get; set; } = string.Empty;  
        public int? TeacherId { get; set; }           
        public Teacher? Teacher { get; set; }       
        public int? Level { get; set; }               
        public DateTime? StartDate { get; set; }      
        public DateTime? EndDate { get; set; }        
        public bool IsActive { get; set; } = true;    

        public int? CourseId { get; set; }         
        public Course? Course { get; set; }         
    }
}