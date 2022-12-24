using CoreProject.Data.Interfaces;
using CoreProject.Data.Models;
using System;

namespace CoreProject.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContent appDbContent;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDbContent.Order.Add(order);
            appDbContent.SaveChanges();

            var items = shopCart.Items;
            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    carId = item.car.Id,
                    orderId = order.id,
                    price = item.car.Price
                };
                appDbContent.OrderDetail.Add(orderDetail);
                appDbContent.SaveChanges();
            }

        }
    }
}
