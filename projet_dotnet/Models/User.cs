namespace projet_dotnet.Models
{
    public class User
    {
        public User(int id,string Filiere , int Niveau, string LastName, string FirstName, string Email, string Password)
        {
            this.Id = id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
            this.Filiere = Filiere;
            this.Niveau = Niveau;
        }
        public User(int id, string lastName, string firstName, string email, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static int id_generator = 100;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public  string Filiere { get; set; }
        public  int Niveau { get; set; }
        public ICollection<BookUser> BookUsers { get; set; }
    }
}
