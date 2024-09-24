namespace UniversityPortalApi.Dto
{
    public class TimetableDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string DayOfWeek { get; set; }
    }
}
