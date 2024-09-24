namespace UniversityPortalApi.Dto
{
    public class GradeDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public double Score { get; set; }
        public string GradeLetter { get; set; }  
    }

}
