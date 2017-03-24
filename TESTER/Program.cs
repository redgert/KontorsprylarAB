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

            Console.WriteLine(myUser.FirstName);
            Console.ReadKey();

            int processed = mySQL.AddNewUser("pattzor", "gillarintejava", "jonas", "redneck", "hehe", "52233", "osmdo", "sweden", "0707887744", "Email");

            if (processed != 0)
            {
                Console.WriteLine("Hmmm");
            }
            else
            {
                Console.WriteLine("Success!");
            }

            List<Product> testList = mySQL.GetAllProducts();

            foreach (var product in testList)
            {
                Console.WriteLine(product.ShortDescription);
            }
            Console.ReadKey()

        }
    }
}
