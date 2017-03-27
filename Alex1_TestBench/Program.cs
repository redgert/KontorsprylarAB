using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectOne_Class_library;

namespace Alex1_TestBench
{
    class Program
    {
        static void Main(string[] args)
        {
            SQL.CreateProductList(1, 2, 1);


            List<ProductList> myProductList = SQL.GetProductList(1);
            foreach (var order in myProductList)
            {
                Console.WriteLine(order.ToString());
            }


       
        }
    }
}
