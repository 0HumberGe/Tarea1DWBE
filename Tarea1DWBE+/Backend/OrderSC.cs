using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea1DWBE_.DataAccess;

namespace Tarea1DWBE_.Backend
{
    class OrderSC : BaseSC
    {
        public IQueryable<Order> GetOrderByID(int orderID)
        {
            return GetAllOrders().Where(w => w.OrderId == orderID);
        }

        public IQueryable<Order> GetAllOrders()
        {
            return dbContext.Orders;
        }
    }
}
