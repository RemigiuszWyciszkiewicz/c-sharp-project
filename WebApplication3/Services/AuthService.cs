using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class AuthService : DataBaseConnectionActionsMethods, AuthorizationAbstract 
    {

        User admin = new User()
        {
            email = "admin@gmail.com",
            password = "adminadmin"
        };

        bool isLoggedAsAdmin = false;
        bool isLoggedAsUser = false;


        
        public bool isloggedAsAdmin(IHeaderDictionary headers)
        {
            if (headers["Authorization"].Equals("IsloggedAsAdmin"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool isloggedAsUser(IHeaderDictionary headers)
        {
            if (true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkIfIsAdmin(User user)
        {
            if(user.email.Equals(admin.email) && user.password.Equals(admin.password))
            {
                return true;
            } else
            {
                return false;
            }
            
        }

        public bool checkIfIsUser(User user)
        {
           
            MySqlDataReader rdr = checkIfThereIsUSerwithSpecificPasswordAndEmail(user);

            rdr.Read();

            Console.WriteLine("Ilosc id");
            Console.WriteLine(rdr.GetValue(0));
            if (Convert.ToInt64(rdr.GetValue(0)) == 0)
            {
                closeConnection();
                return false;
            }
            else
            {
                closeConnection();
                return true;
            }



        }

    
    }
}
