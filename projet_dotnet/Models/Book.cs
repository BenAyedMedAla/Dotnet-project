using System.ComponentModel.DataAnnotations;

namespace projet_dotnet.Models
{
    public class Book
    {
        [Key]
        public int book_id { get; set; }
        public string book_title { get; set; }

        public string matiere { get; set; }
        public string author { get; set; }
        public virtual ICollection<BookUser> BookUsers { get; set; }
    }
}
