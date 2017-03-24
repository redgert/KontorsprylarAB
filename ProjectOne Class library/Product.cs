using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne_Class_library
{
    class Product
    {
        public int ProductID { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public double VatTag { get; set; }

        public Product(int productID, int price, int stock, string shortDescription, string longDescription, double vatTag)
        {
            ProductID = productID;
            Price = price;
            Stock = stock;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            VatTag = vatTag;
        }

    }
}
