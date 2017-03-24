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

            List<Product> productList = new List<string>();


            SQL mySQL = new SQL();

            List<Product> productList = mySQL.GetAllProducts();

            productInfoLiteral.Text = "";

        }
    }
}