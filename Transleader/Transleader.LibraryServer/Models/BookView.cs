namespace Transleader.LibraryServer.Models
{
    public class BookView
    {
        public string Title => Books.First().Title;

        public string? Description => Books.First().Description;
        
        public string Author => Books.First().Author;

        public string? Picture => Books.First().Picture;

        public IList<BookInstanceView> Books { get; set;}

        public int Count { get => Books.Count; }

        public BookView(BookInstanceView book)
        {
            Books = new List<BookInstanceView>{book};
        }
    }
}
