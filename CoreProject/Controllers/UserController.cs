using CoreProject.Data.Interfaces;
using CoreProject.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DiaSymReader;

namespace CoreProject.Controllers
{
	public class UserController : Controller
	{
		private readonly IUser user;
		public UserController(IUser user)
		{
			this.user = user;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			if (TempData.ContainsKey("USER_CREATED"))
				ViewBag.USER_CREATED = TempData["USER_CREATED"].ToString();
			return View();
		}

		[HttpPost]
		public IActionResult Login(User user)
		{
			if (user == null)
				return View();
			if (user.Username == null || user.Password == null)
				return View();

			HttpContext.Session.SetString("currentLogin", user.Username);
			HttpContext.Session.SetString("currentPassword", user.Password);
			if (isLogged())
				HttpContext.Session.SetString("logged", "true");
			if (isAdmin())
                HttpContext.Session.SetString("admin", "true");
            return RedirectToAction("Index", "Home");
			//return View();
		}

		[HttpGet]
		public IActionResult Logout()
		{
			HttpContext.Session.Remove("currentLogin");
			HttpContext.Session.Remove("currentPassword");
			HttpContext.Session.Remove("logged");
			HttpContext.Session.Remove("admin");
            return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
        [HttpGet]
        public IActionResult AdminPanel()
        {
			if (isAdmin())
				return View();
			return RedirectToAction("Index", "Home");
        }

        [HttpPost]
		public IActionResult Register(User userToCreate)
		{
			if (user.isExisting(userToCreate.Username, userToCreate.Email))
			{
				ViewBag.USER_EXIST_ERROR = "Пользователь с таким именем (или почтой) уже существует";
				return View();
			}
			user.Register(userToCreate);
			TempData["USER_CREATED"] = "Пользователь успешно зарегистрирован";
			return RedirectToAction("Login", "User");
		}
		public bool isLogged()
		{
			var currentLogin = HttpContext.Session.GetString("currentLogin");
			var currentPassword = HttpContext.Session.GetString("currentPassword");
			if (currentLogin == null || currentPassword == null)
				return false;
			return user.isLogged(currentLogin, currentPassword);
		}
        public bool isAdmin()
        {
            var currentLogin = HttpContext.Session.GetString("currentLogin");
            var currentPassword = HttpContext.Session.GetString("currentPassword");
            if (currentLogin == null || currentPassword == null)
                return false;
            return user.isAdmin(currentLogin, currentPassword);
        }
    }
}
