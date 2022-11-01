namespace Transleader.LibraryServer.Models
{
    public class BookInstanceView
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Language { get; set; }

        public BookText Text { get; set; }

        public string? Description { get; set; }

        public string? Picture { get; set; }

        public string Publisher { get; set; }

        public BookInstanceView(string title, string author, BookText text, string publisher, string language)
        {
            Title = title;

            Author = author;

            Text = text;

            Publisher = publisher;

            Language = language;
        }

        /*Title,Author,Description,Id,Publishment/UserTranslator/Team,
         * Picture,Year,Tom,BookText(ChapterAmount,Text,Chapters,PaperPagesAmount),*/
    }
}
