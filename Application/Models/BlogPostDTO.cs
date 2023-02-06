
namespace MicroServiceAPITutorial.DTOs
{
    public class BlogPostDTO
    {
        public bool Habilited { get; set; }
        public string Title { get; set; }
        public Guid CategoryID { get; set; }
        public string Content { get; set; }
    }
}
