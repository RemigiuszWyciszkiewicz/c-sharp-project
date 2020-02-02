using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class AuthService : DataBaseConnection , AuthorizationAbstract 
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
            if (headers["Authorization"].Equals("IsloggedAsUser"))
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

    
    }
}
