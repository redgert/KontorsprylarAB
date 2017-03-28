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
            //if(IsPostBack)
            //{
            //    // Skapa order
            //    foreach (var item in checkOutTable.Controls)
            //    {
            //        if(item is TextBox)
            //        {
            //            TextBox myTextbox = item as TextBox;

            //            if(myTextbox.ID.Contains("prodTextBox_"))
            //            {
            //                int antal = Convert.ToInt32(myTextbox.Text);
            //            }
            //        }
            //    }
            //}

            if (Session["myCart"] != null)
            {
                cartProducts = (List<Product>)Session["myCart"];

                TableHeaderRow myHeadRow = new TableHeaderRow();
                checkOutTable.Controls.Add(myHeadRow);

                TableHeaderCell cellHead1 = new TableHeaderCell();
                cellHead1.Text = "Produkt";
                myHeadRow.Controls.Add(cellHead1);

                TableHeaderCell cellHead2 = new TableHeaderCell();
                cellHead2.Text = "Pris";
                myHeadRow.Controls.Add(cellHead2);

                TableHeaderCell cellHead3 = new TableHeaderCell();
                cellHead3.Text = "Antal";
                myHeadRow.Controls.Add(cellHead3);



                foreach (var item in cartProducts)
                {
                    TableRow myRow = new TableRow();

                    TableCell cell2 = new TableCell();
                    cell2.Text = item.ShortDescription;
                    myRow.Controls.Add(cell2);

                    TableCell cell4 = new TableCell();
                    cell4.Text = item.Price.ToString();
                    myRow.Controls.Add(cell4);

                    TableCell cell5 = new TableCell();
                    TextBox myTextBox = new TextBox();
                    myTextBox.Text = "5";
                    myTextBox.ID = "prodTextBox_" + item.ProductID;
                    cell5.Controls.Add(myTextBox);
                    myRow.Controls.Add(cell5);

                    checkOutTable.Controls.Add(myRow);
                }

            }
        }
    }
}