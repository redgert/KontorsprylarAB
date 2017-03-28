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

                foreach (var product in prodList)
                {
                    ourProdList.Add(mySQL.GetProduct(product.ProductID));
                }

                foreach (var price in ourProdList)
                {
                    totCost += Convert.ToDouble(price.Price);
                }

                LabelPrice.Text = totCost.ToString();
            }
        }
    }
}