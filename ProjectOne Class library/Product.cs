using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne_Class_library
{
    public class Product
    {
        public int ProductID { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string URL { get; set; }
        public double VatTag { get; set; }

        public Product(int productID, double price, int stock, string shortDescription, string longDescription, string url, double vatTag)
        {
            ProductID = productID;
            Price = price;
            Stock = stock;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            URL = url;
            VatTag = vatTag;
        }

        public override string ToString()
        {
            return $"ProductID: {ProductID} Price: {Price} Stock: {Stock} ShortDescrp: {ShortDescription} LongDescrp: {LongDescription} VatTag: {VatTag}";
        }

    }
}
