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

        //TODO Call GetUser withint AddNewUser to check if already existing
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
        //Get User with matching username and password
        public User GetUser(string username, string password)
        {
            User tempUser = null;
            SqlConnection myConnection = new SqlConnection(CON_STR);

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("getUser", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //Select all information from the user with the matching username and password
                //TODO Add parameters to check username and password
                SqlParameter myUserName = new SqlParameter("@username", SqlDbType.VarChar);
                myUserName.Value = username;
                SqlParameter myPassword = new SqlParameter("@password", SqlDbType.VarChar);
                myPassword.Value = password;

                myCommand.Parameters.Add(myUserName);
                myCommand.Parameters.Add(myPassword);

                SqlDataReader myReader;

                myReader = myCommand.ExecuteReader();

                while(myReader.Read())
                {
                    try
                    {
                        //TODO Add Phonenumber if not Null or default
                        //Create new User based on all information in User Table SQL
                        tempUser = new User(Convert.ToInt32(myReader["UserID"]), myReader["FirstName"].ToString(), myReader["LastName"].ToString(), myReader["Street"].ToString(), myReader["Zip"].ToString(), myReader["City"].ToString(), myReader["Country"].ToString(), myReader["Email"].ToString(), Convert.ToInt32(myReader["IsAdmin"]));
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

            }
            catch
            {

            }
            finally
            {
                myConnection.Close();
            }
            //return the created User to be able to use information as session
            return tempUser;
        }

        public void GetAllProducts()
        {
            List<Product> products = new List<Product>();

            SqlConnection myConnection = new SqlConnection();
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT * FROM products", myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    products.Add(new Product(Convert.ToInt32(myReader["productID"]), Convert.ToDouble(myReader["price"]), Convert.ToInt32(myReader["stock"]), myReader["shortDescription"].ToString(), myReader["longDescription"].ToString(), Convert.ToDouble(myReader["vatTag"])));
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                myConnection.Close();
            }
        }

        //TODO Add method to add product and get product


    }
    
}
