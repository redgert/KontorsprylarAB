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
            else if (Request["add"] != null && Request["price"] != null && Request["stock"] != null && Request["shortDesc"] != null && Request["longDesc"] != null && Request["url"] != null && Request["vatTag"] != null)
            {
                try
                {
                    mySQL.AddProduct(Convert.ToDouble(Request["price"]), Convert.ToInt32(Request["stock"]), Request["shortDesc"].ToString(), Request["longDesc"].ToString(), Request["url"].ToString(), Convert.ToInt32(Request["vatTag"]));
                    productInfoLiteral.Text = JsonConvert.SerializeObject("Success!");
                }
                catch (Exception)
                {
                    productInfoLiteral.Text = JsonConvert.SerializeObject("Failure!");
                    throw;
                }
            }
            else if (Request["action"] != null && Request["removeid"] != null)
            {
                try
                {
                    SQL.RemoveProduct(Convert.ToInt32(Request["removeid"]));
                    productInfoLiteral.Text = JsonConvert.SerializeObject("success");
                }
                catch (Exception)
                {
                    productInfoLiteral.Text = JsonConvert.SerializeObject("failure");
                    throw;
                }
            }
            else if (Request["action"] != null && Request["pid"] != null && Request["price"] != null && Request["stock"] != null && Request["shortDesc"] != null && Request["longDesc"] != null && Request["url"] != null && Request["vatTag"] != null)
            {
                try
                {
                    SQL.UpdateProduct(Convert.ToInt32(Request["pid"]), Convert.ToDouble(Request["price"]), Convert.ToInt32(Request["stock"]), Request["shortDesc"].ToString(), Request["longDesc"].ToString(), Request["url"].ToString(), Convert.ToInt32(Request["vatTag"]));
                    productInfoLiteral.Text = JsonConvert.SerializeObject("success");
                }
                catch (Exception)
                {
                    productInfoLiteral.Text = JsonConvert.SerializeObject("failure");
                    throw;
                }
                

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