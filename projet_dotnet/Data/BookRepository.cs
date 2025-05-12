using Microsoft.AspNetCore.Mvc;
using projet_dotnet.Models;

namespace projet_dotnet.Data
{
    public class BookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }
        public BookRepository()
        {
            
        }
        public List<Book> all()
        {
            BookContext bc = BookContext.Instantiate_Book_Context();
            var books = bc.Book;
            if (books == null) { return new List<Book>(); }
            else return books.ToList();
        }
        public List<Book> BooksByMatiere(string matiere)
        {

            BookContext bc = BookContext.Instantiate_Book_Context();
            var books = bc.Book;

            if (books == null)
            {
                return new List<Book>();
            }

            else
            {
                List<Book> c = new List<Book>();
                foreach (Book b in books)
                {
                    if (b.matiere == matiere) { c.Add(b); }
                }
                return c;
            }
        }
        
        public void Add(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Book.Update(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Book.Find(id);
            _context.Book.Remove(book);
            _context.SaveChanges();
        }
        
    }
}
