using Entities;
using Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary
{
    public class Services :  ProductsList , IServices
    {
        

       
        public void printVendors()
        {
            var vendorItems = new Entities.VendorItems().VendorItemsList;

            Console.WriteLine("Vendors:");
            Console.WriteLine("_ _ _ _ _ _ _");
            foreach (var vendor in vendorItems)
            {
                Console.WriteLine(vendor);
            }

        }
        public void printProductsByVendors()
        {
            

            Console.WriteLine("Select from VW , Audi , BMW");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _");
            var vendorsBrands = Console.ReadLine();

            foreach (var product in productsItems[vendorsBrands])
            {
                Console.WriteLine($"Name : {product.Name}\n price:{product.Price}\n Product code:{product.ProductCode}");
                Console.WriteLine("______________________");
            }
        }
        public void searchByProductName()
        {
            
            Console.WriteLine("Enter name of product to get that product");
            var inputProductName = Console.ReadLine();
            var searchProductName = productsItems.Select(c => c.Value.Where(y => y.Name == inputProductName));
            foreach (var product in searchProductName)
            {
                foreach (var product2 in product)
                {
                    Console.WriteLine(product2.Name);
                }
            }
        }
        public void ascDescProductItems()
        {
            var userProducts = Console.ReadLine();
            Console.WriteLine("Write asc for sorted list by product name by ascending, or desc for oposite");
            if (userProducts == "asc")
            {
                Console.WriteLine("Sorted list by product name Asc:");

                var sortByProductNameAsc = productsItems[userProducts].OrderBy(x => x.Name);

                foreach (var product in sortByProductNameAsc)
                {
                    Console.WriteLine($"Name : {product.Name}\n price:{product.Price}\n Product code:{product.ProductCode}");
                    Console.WriteLine("______________________");
                }
            }
            if (userProducts == "desc")
            {
                Console.WriteLine("Sorted list by product name Desc:");

                var sortByProductNameDesc = productsItems[userProducts].OrderByDescending(x => x.Name);

                foreach (var product in sortByProductNameDesc)
                {
                    Console.WriteLine($"Name : {product.Name}\n price:{product.Price}\n Product code:{product.ProductCode}");
                    Console.WriteLine("______________________");
                }
            }
        }
        public void addOrderToCart()
        {
            bool addOrderToCart = true;
            while (addOrderToCart)
            {
                Console.WriteLine("Enter product cod");
                long productCode = long.Parse(Console.ReadLine());
                Console.WriteLine("Number of products");
                int quantity = Int32.Parse(Console.ReadLine());

                foreach (var item in productsItems)
                {
                    var product = item.Value.Find(c => c.ProductCode == productCode);
                    if (product != null)
                    {
                        double totalPrice = quantity * product.Price;
                        var order = new OrderItem(new ProductItem(
                            product.Name,
                            product.Price,
                            product.ProductCode),
                            quantity,
                            totalPrice);
                        userOrders.Add(order);
                    }

                }
                Console.WriteLine("You can continue to add orders or submit current orders");
                Console.WriteLine("To continue adding orders enter add,to submit orders enter submit");
                addOrderToCart = Console.ReadLine() == "add" ? true : false;
            }
        }
        public void printOrders()
        {
            foreach (var orderProducts in userOrders)
            {
                Console.WriteLine($"Name: {orderProducts.Product.Name}\n price:{orderProducts.Product.Price}\n quantity: {orderProducts.Quantity}");
                Console.WriteLine("_____________________________________");
            }
        }
        public void deleteOrders()
        {
            for (int i = 0; i < userOrders.Count; i++)
            {
                Console.WriteLine($"{i}:Name:{userOrders[i].Product.Name}\n price:{userOrders[i].Product.Price}\n quantity:{userOrders[i].Quantity}");
            }
            Console.WriteLine("Select the row number of the product you want to remove");
            int removedProduct = int.Parse(Console.ReadLine());
            userOrders.RemoveAt(removedProduct);
            foreach (var item in userOrders)
            {
                Console.WriteLine($"Name:{item.Product.Name}\n price:{item.Product.Price}\n quanity:{item.Quantity}");
                Console.WriteLine("________________________");
            }
        }
        public void shipPayOrders()
        {
            string msg = "You buy products with PayPal";
            string msgOne = "You buy products with CreditCard";
            PaymentEvent paymentEvent = new PaymentEvent();
            UserNotified userNotified = new UserNotified();
            paymentEvent.userNotifiedHandler += userNotified.MsgProcessed;
            var username = new User();
            Console.WriteLine(username.Name);
            for (int i = 0; i < userOrders.Count; i++)
            {
                Console.WriteLine($"{i + 1}:Name:{userOrders[i].Product.Name} price:{userOrders[i].Product.Price} quanity:{userOrders[i].Quantity}");

            }
            double totalSum = userOrders.Sum(el => el.TotalPrice);
            Console.WriteLine("Total:" + totalSum);

            Console.WriteLine("You can continue to add orders or pay and ship current orders");
            Console.WriteLine("To continue adding orders enter add , to continue to paying and shipping orders enter submit");
            var userInput = Console.ReadLine();

            if (userInput == "submit")
            {
                Console.WriteLine("Pay with credit card or paypal by entering credit or pay");

                var creditCard = Console.ReadLine();
                if (creditCard == "credit")
                {
                    userNotified.MsgProcessed(msg);

                }
                if (creditCard == "pay")
                {
                    userNotified.MsgProcessed(msgOne);

                }
                Console.WriteLine("If you are living in Skopje, Bitola, Ohrid, Stip you can get your products by entering your city name");

                var city = Console.ReadLine();
                if (city == "Skopje" || city == "Bitola" || city == "Ohrid" || city == "Stip")
                {
                    Console.WriteLine("Please enter posta or delco to ship your orders");

                    var ship = Console.ReadLine();

                    if (ship == "posta")
                    {
                        Console.WriteLine("Your orders are shipped by posta....");
                    }
                    if (ship == "delco")
                    {
                        Console.WriteLine("Your orders are shipped by delco....");

                    }


                    Console.WriteLine("See your list of expensive orders above 50.000 or see your cheap orders under 50.000 by entering exp or cheap");
                    Console.WriteLine("Enter exp or cheap");
                    var cost = Console.ReadLine();
                    if (cost == "exp")
                    {
                        double fiveK = 50.000;
                        var totalSumExp = userOrders.Where(x => x.TotalPrice > fiveK);
                        foreach (var item in totalSumExp)
                        {
                            Console.WriteLine(item);
                        }
                            
                    }
                    if (cost == "cheap")
                    {
                        double fiveK = 50.000;
                        var totalSumExp = userOrders.Where(x => x.TotalPrice < fiveK);
                        foreach (var item in totalSumExp)
                        {
                            Console.WriteLine(item);
                        }


                    }
                }
            }


            else
            {
                Console.WriteLine("We dont have service for shipping in your city yet or you dont choose right paying method");

            }


        }
        public void optionsUser()
        {
            Console.WriteLine("1. See the whole list of Vendors");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine("2. Search by Vendor name for their products");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine("3. Search by part of name of Products");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine("4. Sort products by product name, enter VW,Audi or BMW");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine("5. Sort products by product price");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine("6. Make a order");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine("7. Show orders");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine("8. Remove order");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine("9. View orders and");
            Console.WriteLine("Submit order and continue to choose paying method and shipping");
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");

            Console.WriteLine("To close this app please enter escape key.");
            Console.WriteLine("_______________________________________________");


           
        }
        
    }
}
