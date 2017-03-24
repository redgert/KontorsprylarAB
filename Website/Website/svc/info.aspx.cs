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
    public partial class info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["username"] != null && Request["password"] != null)
            {
                SQL mySQL = new SQL();
                var tempuser = mySQL.GetUser(Request["username"], Request["password"]);

                if (tempuser != null)
                {
                    infoLiteral.Text = JsonConvert.SerializeObject(tempuser);
                    //Server.Transfer("/successlogin.aspx");
                    //Session tempuser
                    Session["user"] = tempuser.ToString();
                }
                else
                {
                    infoLiteral.Text = JsonConvert.SerializeObject("Error");
                }
            }
            
        }
    }
}