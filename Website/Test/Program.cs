using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectOne_Class_library;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            SQL mySQL = new SQL();
            List<Product> products = mySQL.GetAllProducts();

            foreach (var item in products)
            {
                Console.WriteLine(item.ToString());
            }

            //SQL.UpdateProduct(2, 15, 2, 10, "Alex", "Har testat att uppdater produkten");


            SQL.RemoveProduct(2);


            products = mySQL.GetAllProducts();

            foreach (var item in products)
            {
                Console.WriteLine(item.ToString());
            }




        }
    }
}
