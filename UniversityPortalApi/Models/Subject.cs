namespace UniversityPortal.Api.Models
{
    public class Subject
    {
        public int Id { get; set; }  
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; } 
        public ICollection<Grade> Grades { get; set; }  
    }
}

