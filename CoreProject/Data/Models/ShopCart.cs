using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreProject.Data.Models
{
    public class ShopCart
    {
        private readonly AppDbContent appDbContent;
        public ShopCart(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> Items { get; set; }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        public void AddToCart(Car car)
        {
            //var item = appDbContent.Car.FirstOrDefault(i => i.Id == car.Id);
            appDbContent.ShopCartItem.Add(new ShopCartItem
            {
                shopCartId = ShopCartId,
                car = car,
                price = car.Price
            });
            appDbContent.SaveChanges();
        }
        public List<ShopCartItem> GetShopItems()
        {
            return appDbContent.ShopCartItem.Where(c => c.shopCartId == ShopCartId).Include(s => s.car).ToList();
        }
    }
}
