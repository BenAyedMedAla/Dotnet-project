using Microsoft.EntityFrameworkCore;
using projet_dotnet.Models;
using System.Diagnostics;
namespace projet_dotnet.Data
{
    public class BookContext :DbContext
    {
        static private BookContext bookContextInstance = null;
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<BookUser> BookUser { get; set; }
        public BookContext(DbContextOptions o) : base(o) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookUser>()
                .HasKey(bu => new { bu.BookId, bu.UserId });
            modelBuilder.Entity<BookUser>()
                .HasOne(bu => bu.Book)
                .WithMany(b => b.BookUsers)
                .HasForeignKey(bu => bu.BookId);
            modelBuilder.Entity<BookUser>()
                .HasOne(bu => bu.User)
                .WithMany(u => u.BookUsers)
                .HasForeignKey(bu => bu.UserId);
        }
        public static BookContext Instantiate_Book_Context()
        {
            if (bookContextInstance == null)
            {

                var optionsBuilder = new DbContextOptionsBuilder<BookContext>();
                    optionsBuilder.UseSqlite(@"Data Source=C:\Users\Mediatek\Downloads\projetdotnet-main\projetdotnet-main\projet_dotnet\biblio.db");
                bookContextInstance = new BookContext(optionsBuilder.Options);
                Debug.WriteLine("instance created for the first time");
                return bookContextInstance;
            }
            else
            {
                Debug.WriteLine("instance already created");
                return bookContextInstance;
            }
        }

    }
}
