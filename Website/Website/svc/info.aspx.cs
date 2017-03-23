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
            ProjectOne_Class_library.SQL mySQL = new SQL();
        }
    }
}