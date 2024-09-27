namespace UniversityPortalApi.Dto
{
    public class CreateGradeDto
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public double Score { get; set; }
        public string GradeLetter { get; set; }  
    }

}
