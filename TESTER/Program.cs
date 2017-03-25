using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectOne_Class_library;

namespace TESTER
{
    class Program
    {
        static void Main(string[] args)
        {
            SQL mySQL = new SQL();
            User myUser = mySQL.GetUser("pattzor", "gillarintejava");

            List<Order> myList = SQL.GetAllOrders(2);

            //foreach (var order in myList)
            //{
            //    Console.WriteLine(order);
            //}
            Console.ReadKey();
            Console.WriteLine(myUser.FirstName);
            Console.ReadKey();

            List<Product> testList = mySQL.GetAllProducts();

            foreach (var product in testList)
            {
                Console.WriteLine(product.ShortDescription);
            }
            Console.ReadKey();

            int tempoutput = mySQL.AddProduct(400, 1, 10, "Klocka", "En skinande klocka");
            Console.WriteLine(tempoutput);
            Console.ReadKey();

            Product tempProduct = mySQL.GetProduct("Klocka");

            Console.WriteLine(tempProduct.LongDescription);
            Console.ReadKey();


           
        }
    }
}
