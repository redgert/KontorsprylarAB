using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectOne_Class_library;

namespace Alex1___TestBench
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> myList = SQL.GetAllOrders(2);

            foreach (var item in myList)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
