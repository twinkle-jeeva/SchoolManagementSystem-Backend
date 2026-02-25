using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDemoAPI.Models
{
    public class Course
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;   
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public int? GradeLevel { get; set; }       
    public int? Credits { get; set; }          
    public DateTime? StartDate { get; set; }   
    public DateTime? EndDate { get; set; }     
    public int? TeacherId { get; set; }         
    public Teacher? Teacher { get; set; }       

    
   public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
   public ICollection<Student> Students { get; set; } = new List<Student>();}


    }
