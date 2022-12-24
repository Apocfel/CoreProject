using CoreProject.Data.Interfaces;
using CoreProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;
        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FavCars = _carRep.FavCars
            };
            return View(homeCars);
        }
    }
}
