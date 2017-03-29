using Newtonsoft.Json;
using ProjectOne_Class_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website.svc
{
    public partial class svc_cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQL mySQL = new SQL();

            if (Request["prodid"] != null)
            {
                Product myProduct = mySQL.GetProduct(Convert.ToInt32(Request["prodid"]));
                List<Product> cartProducts;

                if (Session["myCart"] != null)
                {
                    cartProducts = (List<Product>)Session["myCart"];
                    bool exist = false;
                    foreach (var item in cartProducts)
                    {
                        if (item.ProductID == myProduct.ProductID)
                        {
                            exist = true;
                            break;
                        }
                    }
                    if(!exist)
                    {
                        cartProducts.Add(myProduct);
                    }

                    Session["myCart"] = cartProducts;
                }
                else
                {
                    cartProducts = new List<Product>();

                    cartProducts.Add(myProduct);

                    Session["myCart"] = cartProducts;
                }

                infoLit.Text = JsonConvert.SerializeObject(cartProducts);
            }

            if (Request["product"] != null && Session["myCart"] != null)
            {
                var tempCart = (List<Product>)Session["myCart"];
                infoLit.Text = JsonConvert.SerializeObject(tempCart);
            }
            //else //Varför????
            //{
            //    List<Product> productList = new List<Product>();

            //    productList = mySQL.GetAllProducts();

            //    infoLit.Text = JsonConvert.SerializeObject(productList);
            //}
        }
    }
}