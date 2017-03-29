using ProjectOne_Class_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                double totCost = 0;
                List<Product> ourProdList = new List<Product>();
                List<ProductList> prodList = new List<ProductList>();
                SQL mySQL = new SQL();
                User myUser = mySQL.GetUser(Session["user"].ToString());
                
                var myList = SQL.GetOrder(myUser.UserID);

                foreach (var item in myList)
                {
                    prodList = SQL.GetProductList(item.OrderID);
                }

                List<int> quantity = new List<int>();

                foreach (var product in prodList)
                {
                    ourProdList.Add(mySQL.GetProduct(product.ProductID));
                    quantity.Add(product.Quantity);
                }

                for (int i = 0; i < ourProdList.Count; i++)
                {
                    totCost += Convert.ToDouble(ourProdList[i].Price * quantity[i]);
                }

                LabelPrice.Text = totCost.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["myCart"] = null;
            Response.Redirect("thankyou.aspx");
        }
    }
}