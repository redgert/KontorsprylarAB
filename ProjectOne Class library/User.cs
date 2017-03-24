using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne_Class_library
{
    public class User
    {
        public int UserID { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int IsAdmin { get; set; }
        public User(int userID, string firstname, string lastname, string street, string zip, string city, string country, string phonenumber, string email, int isAdmin)
        {
            UserID = userID;
            //Username = username;
            //Password = password;
            FirstName = firstname;
            LastName = lastname;
            Street = street;
            Zip = zip;
            City = city;
            Country = country;
            PhoneNumber = phonenumber;
            Email = email;
            IsAdmin = isAdmin;
        }
        public User(int userID, string firstname, string lastname, string street, string zip, string city, string country, string email, int isAdmin)
        {
            UserID = userID;
            //Username = username;
            //Password = password;
            FirstName = firstname;
            LastName = lastname;
            Street = street;
            Zip = zip;
            City = city;
            Country = country;
            PhoneNumber = null;
            Email = email;
            IsAdmin = isAdmin;
        }

        public User()
        {

        }

    }
}
