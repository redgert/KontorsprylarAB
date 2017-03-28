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

        public User GetUser(string id)
        {
            User tempUser = null;
            SqlConnection myConnection = new SqlConnection(CON_STR);

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("GetUserByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //Select all information from the user with the matching username and password
                SqlParameter myUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
                myUserID.Value = Convert.ToInt32(id);
                

                myCommand.Parameters.Add(myUserID);

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
                    if (Convert.ToInt32(myReader["vatTag"]) == 1)
                    {
                        products.Add(new Product(Convert.ToInt32(myReader["productID"]), Math.Round(Convert.ToDouble(myReader["price"]) * 1.12, 2), Convert.ToInt32(myReader["stock"]), myReader["shortDescription"].ToString(), myReader["longDescription"].ToString(), myReader["URL"].ToString(), Convert.ToInt32(myReader["vatTag"])));

                    }
                    else if (Convert.ToInt32(myReader["vatTag"]) == 2)
                    {
                        products.Add(new Product(Convert.ToInt32(myReader["productID"]), Math.Round(Convert.ToDouble(myReader["price"])* 1.25, 2), Convert.ToInt32(myReader["stock"]), myReader["shortDescription"].ToString(), myReader["longDescription"].ToString(), myReader["URL"].ToString(), Convert.ToInt32(myReader["vatTag"])));

                    }
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
        public int AddProduct(double price, int vattag, int stock, string shortdescription, string longdescription, string url)
        {
            int newProductID = 0;
            //Call method get product to see if it is already existing
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
                        SqlParameter addURL = new SqlParameter("@URL", SqlDbType.VarChar);
                        addURL.Value = url;

                        myCommand.Parameters.Add(addProductPrice);
                        myCommand.Parameters.Add(addProductID);
                        myCommand.Parameters.Add(addProductStock);
                        myCommand.Parameters.Add(addProductVatTag);
                        myCommand.Parameters.Add(addShortDescription);
                        myCommand.Parameters.Add(addLongDescription);
                        myCommand.Parameters.Add(addURL);
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

        public Product GetProduct(int ProductID)
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
                SqlParameter myProductID = new SqlParameter("@ProductID", SqlDbType.VarChar);
                myProductID.Value = ProductID;

                myCommand.Parameters.Add(myProductID);

                SqlDataReader myReader;

                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    
                    try
                    {
                        if (Convert.ToInt32(myReader["VatTag"]) == 1)
                        {
                            //Create new Product based on all information in Product Table SQL
                            tempProduct = new Product(Convert.ToInt32(myReader["ProductID"]), Math.Round(Convert.ToDouble(myReader["Price"])* 1.12, 2), Convert.ToInt32(myReader["Stock"]), myReader["ShortDescription"].ToString(), myReader["LongDescription"].ToString(), myReader["URL"].ToString(), Convert.ToInt32(myReader["VatTag"]));
                        }
                        else if (Convert.ToInt32(myReader["VatTag"]) == 2)
                        {
                            //Create new Product based on all information in Product Table SQL
                            tempProduct = new Product(Convert.ToInt32(myReader["ProductID"]), Math.Round(Convert.ToDouble(myReader["Price"])* 1.25, 2), Convert.ToInt32(myReader["Stock"]), myReader["ShortDescription"].ToString(), myReader["LongDescription"].ToString(), myReader["URL"].ToString(), Convert.ToInt32(myReader["VatTag"]));
                        }
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

        static public List<Order> GetOrder(int UserID)
        {
            List<Order> orders = new List<Order>();

            SqlConnection myConnection = new SqlConnection(CON_STR);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("GetOrders", myConnection); // Option: Select* from FullOverView where UserID = @UserID
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.Int);

                parameterUserID.Value = UserID;

                myCommand.Parameters.Add(parameterUserID);

                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    orders.Add(new Order(Convert.ToInt32(myReader["ProductID"]), Convert.ToInt32(myReader["UserID"]), myReader["OrderStatus"].ToString(), DateTime.Parse(myReader["OrderDate"].ToString())));


                }

                myReader.Close();
                myCommand.Dispose();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                myConnection.Close();
            }
            return orders;
        }

        static public void CreateProductList(int OrderID, int ProductID, int Quantity)
        {

            SqlConnection myConnection = new SqlConnection(CON_STR);



            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("CreateProductList", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter parameterOrderID = new SqlParameter("@OrderID", SqlDbType.Int);
                parameterOrderID.Value = OrderID;

                SqlParameter parameterProductID = new SqlParameter("@ProductID", SqlDbType.Int);
                parameterProductID.Value = ProductID;

                SqlParameter parameterQuantity = new SqlParameter("@Quantity", SqlDbType.Int);
                parameterQuantity.Value = Quantity;

                myCommand.Parameters.Add(parameterOrderID);
                myCommand.Parameters.Add(parameterProductID);
                myCommand.Parameters.Add(parameterQuantity);

                myCommand.ExecuteNonQuery();


            }
            finally
            {

                myConnection.Close();
            }


        }

        static public List<ProductList> GetProductList(int ProductListID)

        {
            SqlConnection myConnetion = new SqlConnection(CON_STR);
            List<ProductList> productLists = new List<ProductList>();

            try
            {
                myConnetion.Open();

                SqlCommand myCommand = new SqlCommand("GetProductList", myConnetion); //TODO lägg in en query!
                myCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter paramterProductListID = new SqlParameter("@ProductListID", SqlDbType.Int);
                paramterProductListID.Value = ProductListID;

                myCommand.Parameters.Add(paramterProductListID);


                SqlDataReader myReader = myCommand.ExecuteReader();


                while (myReader.Read())

                {

                    productLists.Add(new ProductList(Convert.ToInt32(myReader["ProductListID"]), Convert.ToInt32(myReader["OrderID"]), Convert.ToInt32(myReader["ProductID"]), Convert.ToInt32(myReader["Quantity"])));


                }

                myReader.Close();
                myCommand.Dispose();


            }
            finally
            {

                myConnetion.Close();
            }

            return productLists;
        }

        static public void UpdateProduct(int productID, double price, int vatTag, int stock, string shortDescrip, string longDescrip )

        {
            SqlConnection myConnection = new SqlConnection(CON_STR);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand("UpdateProduct", myConnection);

                myCommand.CommandType = CommandType.StoredProcedure;

                #region Parameters
                SqlParameter parameterProductID = new SqlParameter("@ProductID", SqlDbType.Int);
                parameterProductID.Value = productID;

                SqlParameter parameterPrice = new SqlParameter("@Price", SqlDbType.Money);
                parameterPrice.Value = price;

                SqlParameter parameterVatTag = new SqlParameter("@VatTag", SqlDbType.Int);
                parameterVatTag.Value = vatTag;

                SqlParameter parameterStock = new SqlParameter("@Stock", SqlDbType.Int);
                parameterStock.Value = stock;

                SqlParameter parameterShortDescrip= new SqlParameter("@ShortDescription", SqlDbType.VarChar);
                parameterShortDescrip.Value = shortDescrip;

                SqlParameter parameterLongDescrip = new SqlParameter("@LongDescription", SqlDbType.VarChar);
                parameterLongDescrip.Value = longDescrip;

                myCommand.Parameters.Add(parameterProductID);
                myCommand.Parameters.Add(parameterPrice);
                myCommand.Parameters.Add(parameterVatTag);
                myCommand.Parameters.Add(parameterStock);
                myCommand.Parameters.Add(parameterShortDescrip);
                myCommand.Parameters.Add(parameterLongDescrip);

                myCommand.ExecuteNonQuery();






                #endregion
            }
            finally
            {

                myConnection.Close();
            }

        }

        static public void RemoveProduct (int DeleteProductID)

        {
            SqlConnection myConnection = new SqlConnection(CON_STR);

            SqlCommand myCommand = new SqlCommand("RemoveProduct", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                myConnection.Open();

                SqlParameter parameterDeleteProductID = new SqlParameter("@ProductID", SqlDbType.Int);
                parameterDeleteProductID.Value = DeleteProductID;

                myCommand.Parameters.Add(parameterDeleteProductID);

                myCommand.ExecuteNonQuery();
            }
            finally
            {

                myConnection.Close();
            }

        }


    }

}
