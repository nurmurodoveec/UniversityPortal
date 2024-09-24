
using UniversityPortal.Api.Models;

namespace UniversityPortal.Api.Models
{
    public class Timetable
    {
        public int Id { get; set; } 
        public int StudentId { get; set; } 
        public int SubjectId { get; set; }  
        public string DayOfWeek { get; set; } 
        public DateTime StartTime { get; set; }  
        public DateTime EndTime { get; set; } 

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}

