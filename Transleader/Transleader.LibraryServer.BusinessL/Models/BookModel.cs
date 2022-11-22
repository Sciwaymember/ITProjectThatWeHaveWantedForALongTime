namespace Transleader.LibraryServer.BusinessL.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? CoverPicture { get; set; }
    }
}