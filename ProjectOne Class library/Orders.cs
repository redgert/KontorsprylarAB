using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne_Class_library
{
    class Order
    {
     
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }


        //TODO You need to update the database SOFIA!!!

        //TODO Do I need to catch up @OutPutID from CreateUser procedure?

        public Order(int OrderID, int UserID, string OrderStatus, DateTime OrderDate) //Constructor for Order 
        {
            this.OrderID = OrderID;
            this.UserID = UserID;
            this.OrderStatus = OrderStatus;
            this.OrderDate = OrderDate;
        }

        public Order()

        {


        }

        public override string ToString()
        {
            return $" OrderID: {OrderID} UserID: {UserID} OrderStatus: {OrderStatus} OrderDate: {OrderDate}";

        }

    }
}
