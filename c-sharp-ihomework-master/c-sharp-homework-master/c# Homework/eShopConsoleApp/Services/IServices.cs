using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary
{
    public interface IServices
    {
        void printVendors();

        void printProductsByVendors();

        void searchByProductName();

        void ascDescProductItems();

        void addOrderToCart();

        void printOrders();

        void deleteOrders();

        void shipPayOrders();

        void optionsUser();

        

    }
}
