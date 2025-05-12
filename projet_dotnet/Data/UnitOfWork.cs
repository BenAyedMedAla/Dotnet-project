using projet_dotnet.Models;

namespace projet_dotnet.Data
{
    public class UnitOfWork
    {
        private readonly BookContext context;
        public UserRepository Users { get; set; }  
        public BookRepository Books { get; set; }  
        public UnitOfWork(BookContext context)
        {
            this.context = context;
            Users = new UserRepository(context);
            Books = new BookRepository(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
