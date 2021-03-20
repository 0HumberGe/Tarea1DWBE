using System;
using System.Collections.Generic;
using System.Text;
using Tarea1DWBE_.DataAccess;

namespace Tarea1DWBE_.Backend
{
    public class ProductSC : BaseSC
    {
        public void AddNewProduct(string productName, decimal unitPrice)
        {
            var newProduct = new Product();
            newProduct.ProductName = productName;
            newProduct.UnitPrice = unitPrice;

            dbContext.Products.Add(newProduct);
            dbContext.SaveChanges();
        }
    }
}
