﻿using ProjectOne_Class_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
                User tempUser = JsonConvert.DeserializeObject<User>(Session["user"].ToString());
                LabelFirstName.Text = tempUser.FirstName.ToString();
                LabelLastName.Text = tempUser.LastName.ToString();
            }
        }
    }
}