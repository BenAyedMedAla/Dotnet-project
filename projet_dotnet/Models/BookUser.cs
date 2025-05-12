namespace projet_dotnet.Models
{
    public class BookUser
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public BookUser(int bookId,int userId) {
            this.UserId = userId;
            this.BookId = bookId;   
        }   
    }
}
