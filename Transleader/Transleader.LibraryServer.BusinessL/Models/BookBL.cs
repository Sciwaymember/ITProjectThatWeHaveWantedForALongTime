using Transleader.LibraryServer.DataAccessL.Types;

namespace Transleader.LibraryServer.BusinessL.Models
{
    public class BookBL
    {
        public Uid Id { get; set; }

        public int? ParentId { get; set; }

        public string? Identifier { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Description { get; set; }

        public int? Year { get; set; }

        public string? Edition { get; set; }

        public string? Publisher { get; set; }

        public string? Extension { get; set; }

        public string? DownloadUrl { get; set; }

        public string? CoverPicture { get; set; }

        public string? Language { get; set; }

        public int? Pages { get; set; }
    }
}