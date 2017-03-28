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

            if (Request["CreateUser"] != null)
            {
                var userName = Request["UserName"] != null ? Request["Username"] : "";
                var password = Request["Password"] != null ? Request["Password"] : "";
                //var password2 = Request["Password2"] != null ? Request["Password2"] : "";
                var firstName = Request["Firstname"] != null ? Request["Firstname"] : "";
                var lastName = Request["Lastname"] != null ? Request["Lastname"] : "";
                var street = Request["Street"] != null ? Request["Street"] : "";
                var zip = Request["Zip"] != null ? Request["Zip"] : "";
                var city = Request["City"] != null ? Request["City"] : "";
                var country = Request["Country"] != null ? Request["Country"] : "";
                var phoneNumber = Request["Phonenumber"] != null ? Request["Phonenumber"] : "";
                var email = Request["Email"] != null ? Request["Email"] : "";
                int isAdmin = Convert.ToInt32(Session["user"]);

                SQL sql = new SQL();
                sql.AddNewUser(userName, password, firstName, lastName, street, zip, city, country, phoneNumber, email, isAdmin);

                //infoLiteral.Text = JsonConvert.SerializeObject(userName);
            }

            if (Request["UpdateUser"] != null)
            {
                var firstName = Request["Firstname"] != null ? Request["Firstname"] : "";
                var lastName = Request["Lastname"] != null ? Request["Lastname"] : "";
                var street = Request["Street"] != null ? Request["Street"] : "";
                var zip = Request["Zip"] != null ? Request["Zip"] : "";
                var city = Request["City"] != null ? Request["City"] : "";
                var country = Request["Country"] != null ? Request["Country"] : "";
                var phoneNumber = Request["Phonenumber"] != null ? Request["Phonenumber"] : "";
                var email = Request["Email"] != null ? Request["Email"] : "";
                var userID = 10;  // Via Session?

                mySQL.UpdateUser(userID, firstName, lastName, street, city, zip, country, phoneNumber, email);
            }
        }
    }
}