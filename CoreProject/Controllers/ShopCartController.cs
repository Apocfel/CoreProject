using CoreProject.Data.Interfaces;
using CoreProject.Data.Models;
using CoreProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProject.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.Items = items;
            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart,
            };
            return View(obj);
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(i => i.Id == id);
            if (item != null)
                _shopCart.AddToCart(item);
            return RedirectToAction("Index");

        }
    }
}
