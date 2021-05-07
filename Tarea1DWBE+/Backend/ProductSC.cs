using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tarea1DWBE_.DataAccess;
using Tarea1DWBE_.Models;

namespace Tarea1DWBE_.Backend
{
    public class ProductSC : BaseSC
    {
        public Product GetProductById(int id)
        {
            var product = GetAllProducts().Where(w => w.ProductId == id).FirstOrDefault();

            if (product == null)
                throw new Exception("El id solicitado para el empleado que quieres obtener, no existe");

            return product;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return dbContext.Products.Select(s => s);
        }

        public void AddNewProduct(ProductModel newProduct)
        {
            var newProductRegister = new Product()
            {
                ProductName = newProduct.ProductName,
                UnitPrice = newProduct.UnitPrice
            };

            dbContext.Products.Add(newProductRegister);
            dbContext.SaveChanges();
        }

        public void DeleteProductById(int id)
        {
            var product = GetProductById(id);
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
        }

    }
}
