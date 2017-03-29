using ProjectOne_Class_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Order> orderHistory;

            orderHistory = SQL.GetOrder(Convert.ToInt32(Session["user"]));

            TableHeaderRow myHeadRow = new TableHeaderRow();
            orderHistoryTable.Controls.Add(myHeadRow);

            TableHeaderCell cellHead1 = new TableHeaderCell();
            cellHead1.Text = "OrderID";
            myHeadRow.Controls.Add(cellHead1);

            TableHeaderCell cellHead2 = new TableHeaderCell();
            cellHead2.Text = "UserID";
            myHeadRow.Controls.Add(cellHead2);

            TableHeaderCell cellHead3 = new TableHeaderCell();
            cellHead3.Text = "OrderStatus";
            myHeadRow.Controls.Add(cellHead3);

            TableHeaderCell cellHead4 = new TableHeaderCell();
            cellHead4.Text = "OrderDate";
            myHeadRow.Controls.Add(cellHead4);

            foreach (var item in orderHistory)
            {
                TableRow myRow = new TableRow();

                TableCell cell2 = new TableCell();
                cell2.Text = item.OrderID.ToString();
                myRow.Controls.Add(cell2);

                TableCell cell4 = new TableCell();
                cell4.Text = item.UserID.ToString();
                myRow.Controls.Add(cell4);

                TableCell cell5 = new TableCell();
                cell5.Text = item.OrderStatus;
                myRow.Controls.Add(cell5);

                TableCell cell6 = new TableCell();
                cell6.Text = item.OrderDate.ToShortDateString();
                myRow.Controls.Add(cell6);


                orderHistoryTable.Controls.Add(myRow);
            }
        }


        }
    }