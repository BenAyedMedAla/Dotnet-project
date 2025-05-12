using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projet_dotnet.Data;
using projet_dotnet.Models;

namespace projet_dotnet.Controllers
{
    public class AccountController : Controller
    {
        private UnitOfWork unitOfWork;

        public AccountController()
        {
            this.unitOfWork = new UnitOfWork(BookContext.Instantiate_Book_Context());
        }
        public IActionResult All()
        {
            //userRepository.AddUser("Arij", "Kouki", "arijkouki17@gmail.com", "cookieee", "28/06/2001", "Tunis");
            List<User> l = unitOfWork.Users.GetAllUsers();
            ViewData["usersList"] = l;
            return View();
        }


        public IActionResult Profile()
        {
            if (UserRepository.currentUser != null)
            {
                ViewData["currentUser"] = UserRepository.currentUser;
            }
            else { TempData["Error"] = "You're not logged in!"; }
            return View();
        }
    }
}
