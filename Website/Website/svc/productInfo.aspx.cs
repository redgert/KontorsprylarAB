using ProjectOne_Class_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Website.svc
{
    public partial class productInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQL mySQL = new SQL();

            if (Request["prodid"] != null)
            {
                Product myProduct = mySQL.GetProduct(Convert.ToInt32(Request["prodid"]));
                productInfoLiteral.Text = JsonConvert.SerializeObject(myProduct);
            }
            else
            {
                List<Product> productList = new List<Product>();

                productList = mySQL.GetAllProducts();

                productInfoLiteral.Text = JsonConvert.SerializeObject(productList);
            }
            
        }
    }
}