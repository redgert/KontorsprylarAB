using ProjectOne_Class_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class checkout : System.Web.UI.Page
    {
        private List<Product> cartProducts;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["myCart"] != null)
            {
                cartProducts = (List<Product>)Session["myCart"];

                foreach (var item in cartProducts)
                {
                    TableRow myRow = new TableRow();
                    TableCell cell1 = new TableCell();
                    cell1.Text = item.ShortDescription;
                    myRow.Controls.Add(cell1);

                    TableCell cell2 = new TableCell();
                    cell2.Text = item.Price.ToString();
                    myRow.Controls.Add(cell2);
                    
                    checkOutTable.Controls.Add(myRow);
                }
            }
        }
    }
}