﻿namespace Transleader.LibraryServer.Models
{
    public class BookView
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string? Title { get; set; }
        
        public string? Author { get; set; }

        public string? CoverPicture { get; set; }
    }
}
