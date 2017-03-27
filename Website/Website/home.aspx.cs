using ProjectOne_Class_library;
using System;
using Newtonsoft.Json;

namespace Website
{
    public partial class successlogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check for Session, which should be parted from null as default.
            if(Session["user"] != null)
            {
                SQL mySQL = new SQL();
                User tempUser = mySQL.GetUser(Session["user"].ToString());
            }
        }
    }
}