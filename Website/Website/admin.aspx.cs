using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProjectOne_Class_library;
using Newtonsoft.Json;

namespace Website
{
    public partial class adminsida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQL mySQL = new SQL();
            if(Session["user"] != null)
            {
                User adminUser = mySQL.GetUser(Session["user"].ToString());

                if (adminUser.IsAdmin != 1)
                {
                    Server.Transfer("/index.aspx");
                }
            }

        }
    }
}