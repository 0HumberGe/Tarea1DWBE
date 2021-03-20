using System;
using System.Linq;
using Tarea1DWBE_.DataAccess;

namespace Tarea1DWBE_
{
    class Program
    {
            public static NorthwindContext dbContext = new NorthwindContext();

        public static void Excersice()
        {
            AddNewProduct("Jugo del valle 1lt", 15.50m);
        }

        private static void AddNewProduct(string productName, decimal unitPrice)
        {
            var newProduct = new Product();
            newProduct.ProductName = productName;
            newProduct.UnitPrice = unitPrice;

            dbContext.Products.Add(newProduct);
            dbContext.SaveChanges();
        }

        static void Main(string[] args)
        {
            Excersice();
        }


        }  
        
    }



