using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne_Class_library
{
    public class ProductList
    {
        public int ProductListID { get; set; }
        public int  OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }


        public ProductList(int ProductListID, int OrderID, int ProductID, int Quantity )
        {
            this.ProductListID = ProductListID;
            this.OrderID = OrderID;
            this.ProductID = ProductID;
            this.Quantity = Quantity;
        }

        public override string ToString()
        {
            return $"ProductListID: {ProductListID} OrderID: {OrderID} ProductID: {ProductID} Quantity: {Quantity} ";

        }

    }
}
