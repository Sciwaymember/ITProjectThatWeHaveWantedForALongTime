namespace Transleader.LibraryServer.Models
{
    public class DataBaseStub
    {
        public IList<BookView> Books { get; }

        public DataBaseStub()
        {
            BookInstanceView[] books = new BookInstanceView[] { new BookInstanceView("Человек дождя", "Стюарт Джефферсон", new BookText(), "Манн и шайка", "Русский"),
                                                                new BookInstanceView("Человек дождя", "Стюарт Джефферсон", new BookText(), "Idiots", "Английский"),
                                                                new BookInstanceView("Фамилия", "Сенъенсо де Ипабло", new BookText(), "Манн и шайка", "Русский"),
                                                                new BookInstanceView("Багдад слезам не верит", "Абдулахал Малик", new BookText(), "ЛитРес ООО", "Русский")};
            
            Books = new List<BookView>();

            foreach (BookInstanceView b in books)
            {
                if (Books.Count != 0)
                {
                    int count = 0;

                    foreach (BookView bv in Books)
                    {               
                        if (bv.Title == b.Title && bv.Author == b.Author)
                        {
                            bv.Books.Add(b);

                            break;
                        }

                        count++;
                    }

                    if (Books.Count == count)
                    {
                        Books.Add(new BookView(b));
                    }
                }
                else
                {
                    Books.Add(new BookView(b));
                }
            }         
        }
    }
}
