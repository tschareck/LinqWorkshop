using LinqWorkshop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqWorkshop.ConsoleApp
{
    static class LazyLoading
    {
        static public void LazyLoadItems()
        {
            using (var dbContext = new NORTHWNDEntities())
            {
                var query = dbContext.Orders.Where(p => p.OrderID == 10250);
                var order = query.First();
                // order was materialized
                Console.WriteLine($"{order.ShipName}, {order.ShipAddress}, {order.ShipCity}");
                Console.WriteLine(order.CustomerID);

                var customer = order.Customers;
                Console.WriteLine(order.Customers.CompanyName);

                var hanari = dbContext.Customers.Find("HANAR");
                Console.WriteLine(hanari.Address);

                var alfred = dbContext.Customers.Find("ALFKI");
                Console.WriteLine(alfred.Address);
            }
        }

        static public void EagerLoadWithInclude()
        {
            using (var dbContext = new NORTHWNDEntities())
            {
                var query = dbContext.Orders.Include("Customers").Where(p => p.OrderID == 10285);

                // materializing order with dependent property
                var order = query.First();
            }
        }

        static public void EagerLoadingWithLoad()
        {
            using (var dbContext = new NORTHWNDEntities())
            {
                // load Product
                var product = dbContext.Products.Find(1);

                // two ways to load dependent property
                dbContext.Entry(product).Reference(p => p.Categories).Load();
                dbContext.Entry(product).Reference("Suppliers").Load();

                // load order
                var order = dbContext.Orders.Find(10286);

                //load collection
                dbContext.Entry(order).Collection(p => p.Order_Details).Load();
            }
        }

        //static public void FetchOrderEagerly()
        //{
        //    using (var dbContext = new NORTHWNDEntities())
        //    {
        //        var order = dbContext.Orders.Find(10287);
        //        Console.WriteLine(order.Employees.FirstName);
        //    }
        //}
    }
}
