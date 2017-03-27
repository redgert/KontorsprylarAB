using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website.svc
{
    public partial class logOutUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Remove this when the Logout-method is changed from JSON to something else...
            logOutUserLiteral.Text = "temporary, unecessary text";

            Session["user"] = null;
        }
    }
}