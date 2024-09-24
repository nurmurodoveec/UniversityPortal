namespace UniversityPortalApi.Dto
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


        public DateTime PublishedDate { get; set; }
    }

}
