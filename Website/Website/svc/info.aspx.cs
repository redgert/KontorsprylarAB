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
            SQL mySQL = new SQL();
            if (Request["username"] != null && Request["password"] != null)
            {
                
                var tempuser = mySQL.GetUser(Request["username"], Request["password"]);

                if (tempuser != null)
                {
                    infoLiteral.Text = JsonConvert.SerializeObject(tempuser);
                    //Create session based on user information, all information connected to user is stored in this.
                    Session["user"] = tempuser.UserID;
                }
                else
                {
                    infoLiteral.Text = JsonConvert.SerializeObject("Error");
                }
            }

            if(Request["loggedin"] != null && Session["user"] != null)
            {
                var tempuser = mySQL.GetUser(Session["user"].ToString());
                infoLiteral.Text = JsonConvert.SerializeObject(tempuser);
            }
        }
    }
}