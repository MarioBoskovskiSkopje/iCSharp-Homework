using ServicesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eShopConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ESHOP APP");
            startApp();
            
        }
        public static void startApp()
        {

            var services = new Services();

            Console.WriteLine("Log in to start using this app.");
            Console.WriteLine("Enter Username");

            bool productsShop = true;
            while (productsShop)
            {
                services.optionsUser();
                var getUserInput = 0;
                bool isValidInput = Int32.TryParse(Console.ReadLine(), out getUserInput);
                if (isValidInput == false || getUserInput < 1 || getUserInput > 8)
                {
                    Console.WriteLine("Your input is invalid. Please try again.");
                }
                switch (getUserInput)
                {
                    case 1:
                        services.printVendors();
                        break;
                    case 2:
                        services.printProductsByVendors();
                        break;
                    case 3:
                        services.searchByProductName();
                        break;
                    case 4:
                        services.ascDescProductItems();
                        break;
                    case 5:
                        services.addOrderToCart();
                        break;
                    case 6:
                        services.printOrders();
                        break;
                    case 7:
                        services.deleteOrders();
                        break;
                    case 8:
                        services.shipPayOrders();
                        break;
                    case 9:
                        productsShop = false;
                        break;
                    default:
                        Console.WriteLine("Please choose from the list");
                        break;
                }
            }
        }
    }
}
