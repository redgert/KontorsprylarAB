using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Website.svc
{
    public partial class logOutUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Remove this when the Logout-method is changed from JSON to something else...
            logOutUserLiteral.Text = JsonConvert.SerializeObject("ok");

            Session["user"] = null;
        }
    }
}