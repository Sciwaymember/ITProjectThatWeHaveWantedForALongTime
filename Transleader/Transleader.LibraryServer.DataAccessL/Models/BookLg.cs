namespace Transleader.LibraryServer.DataAccessL.Models
{
    public class BookLg
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string? Identifier { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Description { get; set; }

        public int? Year { get; set; }

        public string? Edition { get; set; }

        public string? Extension { get; set; }

        public string? Publisher { get; set; }

        public string? Md5 { get; set; }

        public string? Coverurl { get; set; }

        public string? Language { get; set; }

        public int? Pages { get; set; }

        public DateTime Timeadded { get; set; }

        public DateTime Timelastmodified { get; set; }
    }
}