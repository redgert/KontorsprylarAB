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
        public int AddNewUser(string username, string password, string firstname, string lastname, string street, string zip, string city, string country, string phonenumber, string email, int bit = 0)
        {
            int newUserID = 0;
            //Check if User Exists, If it exists, GetUser() will return a user, not null
            User temp = GetUser(username, password);
            if (temp == null)
            {

                SqlConnection myConnection = new SqlConnection(CON_STR);
                try
                {
                    myConnection.Open();
                    SqlCommand myCommand = new SqlCommand("CreateUser", myConnection);
                    myCommand.CommandType = CommandType.StoredProcedure;
                    #region Parameters
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
                    #endregion
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
            }
            return newUserID;
        }
        //Get User with matching username and password
        public User GetUser(string username, string password)
        {
            //Default value null, returned if not existing or matching username and password
            User tempUser = null;
            SqlConnection myConnection = new SqlConnection(CON_STR);

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("getUser", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //Select all information from the user with the matching username and password
                SqlParameter myUserName = new SqlParameter("@username", SqlDbType.VarChar);
                myUserName.Value = username;
                SqlParameter myPassword = new SqlParameter("@password", SqlDbType.VarChar);
                myPassword.Value = password;

                myCommand.Parameters.Add(myUserName);
                myCommand.Parameters.Add(myPassword);

                SqlDataReader myReader;

                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    try
                    {
                        //TODO Add Phonenumber if not Null or default
                        //Create new User based on all information in User Table SQL
                        tempUser = new User(Convert.ToInt32(myReader["UserID"]), myReader["FirstName"].ToString(), myReader["LastName"].ToString(), myReader["Street"].ToString(), myReader["Zip"].ToString(), myReader["City"].ToString(), myReader["Country"].ToString(), myReader["PhoneNumber"].ToString(), myReader["Email"].ToString(), Convert.ToInt32(myReader["IsAdmin"]));
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
        //Method to save all products in a list, use this to convert into JSON
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            SqlConnection myConnection = new SqlConnection(CON_STR);
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT * FROM products where Active=1", myConnection);
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
            return products;
        }
        //Try to add product, if product already exists or something goes wrong, default return is 0
        public int AddProduct(double price, int vattag, int stock, string shortdescription, string longdescription)
        {
            int newProductID = 0;
            //Call method get product to see if it is already existing
            Product tempproduct = GetProduct(shortdescription);
            if (tempproduct == null)
            {
                {
                    SqlConnection myConnection = new SqlConnection(CON_STR);
                    try
                    {
                        myConnection.Open();
                        SqlCommand myCommand = new SqlCommand("CreateProduct", myConnection);
                        myCommand.CommandType = CommandType.StoredProcedure;
                        #region Parameters
                        SqlParameter addProductID = new SqlParameter("@OutputID", SqlDbType.Int);
                        addProductID.Direction = ParameterDirection.Output;
                        SqlParameter addProductPrice = new SqlParameter("@Price", SqlDbType.Money);
                        addProductPrice.Value = price;
                        SqlParameter addProductVatTag = new SqlParameter("@VatTag", SqlDbType.Int);
                        addProductVatTag.Value = vattag;
                        SqlParameter addProductStock = new SqlParameter("@Stock", SqlDbType.Int);
                        addProductStock.Value = stock;
                        SqlParameter addShortDescription = new SqlParameter("@ShortDescription", SqlDbType.VarChar);
                        addShortDescription.Value = shortdescription;
                        SqlParameter addLongDescription = new SqlParameter("@LongDescription", SqlDbType.VarChar);
                        addLongDescription.Value = longdescription;


                        myCommand.Parameters.Add(addProductPrice);
                        myCommand.Parameters.Add(addProductID);
                        myCommand.Parameters.Add(addProductStock);
                        myCommand.Parameters.Add(addProductVatTag);
                        myCommand.Parameters.Add(addShortDescription);
                        myCommand.Parameters.Add(addLongDescription);
                        #endregion
                        myCommand.ExecuteNonQuery();
                        newProductID = Convert.ToInt32(addProductID.Value);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        myConnection.Close();
                    }
                }
            }
            return newProductID;
        }
        //Get one single product, if not found, default return will be null
        public Product GetProduct(string shortdescription)
        {
            //Return null as default if product is not existing
            Product tempProduct = null;
            SqlConnection myConnection = new SqlConnection(CON_STR);

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("GetProduct", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //Select all information from the Product with the matching shortdescription
                SqlParameter myShortDescription = new SqlParameter("@shortdescription", SqlDbType.VarChar);
                myShortDescription.Value = shortdescription;

                myCommand.Parameters.Add(myShortDescription);

                SqlDataReader myReader;

                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    try
                    {
                        //Create new Product based on all information in Product Table SQL
                        tempProduct = new Product(Convert.ToInt32(myReader["ProductID"]), Convert.ToDouble(myReader["Price"]), Convert.ToInt32(myReader["Stock"]), myReader["ShortDescription"].ToString(), myReader["LongDescription"].ToString(), Convert.ToDouble(myReader["VatTag"]));
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
            //return the created Product to be able to use information as session
            return tempProduct;
        }
    }

}
