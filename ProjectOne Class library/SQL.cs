using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ProjectOne_Class_library
{
    public class SQL
    {
        const string CON_STR = "Data Source=.;Initial Catalog=Sofia;Integrated Security=True";

        //Adding new user containing all information needed, by default new user is not admin (bit = 0).
        public int AddNewUser(string username, string password, string firstname, string lastname, string street, string zip, string city, string country, string phonenumber, string email, int bit=0)
        {
            int newUserID = 0;

            SqlConnection myConnection = new SqlConnection(CON_STR);
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("CreateUser", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter addUserID = new SqlParameter("@OutputID", SqlDbType.Int);
                addUserID.Direction = ParameterDirection.Output;
                SqlParameter addUserName = new SqlParameter("@Username", SqlDbType.VarChar);
                addUserName.Value = username;
                SqlParameter addPassword = new SqlParameter("@Password", SqlDbType.VarChar);
                addPassword.Value = password;
                SqlParameter addFirstname = new SqlParameter("@Firstname", SqlDbType.VarChar);
                addFirstname.Value = firstname;
                SqlParameter addLastname = new SqlParameter("@Lastname", SqlDbType.VarChar);
                addLastname.Value = lastname;
                SqlParameter addStreet = new SqlParameter("@Street", SqlDbType.VarChar);
                addStreet.Value = street;
                SqlParameter addZip = new SqlParameter("@Zip", SqlDbType.VarChar);
                addZip.Value = zip;
                SqlParameter addCity = new SqlParameter("@City", SqlDbType.VarChar);
                addCity.Value = city;
                SqlParameter addCountry = new SqlParameter("@Country", SqlDbType.VarChar);
                addCountry.Value = country;
                SqlParameter addPhoneNumber = new SqlParameter("@PhoneNumber", SqlDbType.VarChar);
                addPhoneNumber.Value = phonenumber;
                SqlParameter addEmail = new SqlParameter("@Email", SqlDbType.VarChar);
                addEmail.Value = email;
                SqlParameter addBit = new SqlParameter("@IsAdmin", SqlDbType.Bit);
                addBit.Value = bit;

                myCommand.Parameters.Add(addUserID);
                myCommand.Parameters.Add(addFirstname);
                myCommand.Parameters.Add(addLastname);
                myCommand.Parameters.Add(addUserName);
                myCommand.Parameters.Add(addPassword);
                myCommand.Parameters.Add(addStreet);
                myCommand.Parameters.Add(addZip);
                myCommand.Parameters.Add(addCity);
                myCommand.Parameters.Add(addCountry);
                myCommand.Parameters.Add(addPhoneNumber);
                myCommand.Parameters.Add(addEmail);
                myCommand.Parameters.Add(addBit);

                myCommand.ExecuteNonQuery();
                newUserID = Convert.ToInt32(addUserID.Value);

            }
            catch
            {
                throw;
            }
            finally
            {
                myConnection.Close();
            }


            return newUserID;
        }
    }
    
}
