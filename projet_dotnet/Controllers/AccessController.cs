using Microsoft.AspNetCore.Mvc;
using projet_dotnet.Data;
using projet_dotnet.Models;
using System.Runtime.Intrinsics.X86;

namespace projet_dotnet.Controllers
{
    public class AccessController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(BookContext.Instantiate_Book_Context());
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            UserRepository userRepository = new UserRepository(BookContext.Instantiate_Book_Context());
            User u = userRepository.GetUserByLogin(email, password);
            if (u != null)
            {
                UserRepository.currentUser = u;
                return RedirectToAction("Index", "Home");
            }
            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View();
        }

        public IActionResult LogOut()
        {
            UserRepository.currentUser = null;
            return RedirectToAction("Login", "Access");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(string first_name, string last_name, string email, string password)
        {
            unitOfWork.Users.AddUser(last_name, first_name, email, password);
            unitOfWork.Save();
            return View("RegisterCompleted");
        }
        public IActionResult UpdateUser()
        {

            if (UserRepository.currentUser == null)
            {
                TempData["Error"] = "You're not logged in!";
            }
            else
                ViewData["currentUser"] = UserRepository.currentUser;
            return View();
        }
    }
}
