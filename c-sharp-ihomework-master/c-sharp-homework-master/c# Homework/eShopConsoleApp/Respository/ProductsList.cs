using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository
{
    public class ProductsList
    {
        public Dictionary<string, List<ProductItem>> productsItems;

        public List<OrderItem> userOrders;



        public ProductsList()
        {
            productsItems.Add("VW", new List<ProductItem>()

                {
                        new ProductItem("VW Golf VII R 2.0 Petrol",30000,001),
                        new ProductItem("VW Arteon 2.0 Petrol",35000,002),
                        new ProductItem("VW Passat 2.0 Diesel",25000,003)


                });

            productsItems.Add("Audi", new List<ProductItem>()
                {
                        new ProductItem("Audi RS7 3.0 Diesel",50000,004),
                        new ProductItem("Audi RS4 Avant 2.9 Petrol",70000,005),
                        new ProductItem("Audi S8 3.0 Diesel",100000,006)

                });

            productsItems.Add("BMW", new List<ProductItem>()
                {
                        new ProductItem("BMW M760LI 6.6 Petrol",180000,007),
                        new ProductItem("BMW X5 3.0 Diesel",55000,008),
                        new ProductItem("BMW M4 CS 3.0 Petrol",75000,009)

                });
        }
    }
}
