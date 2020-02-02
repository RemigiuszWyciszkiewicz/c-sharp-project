using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services
{
    public class UserRepository : DataBaseConnectionActionsMethods
    {

        public void addUserToDb(string email, string password)
        {

            
            insertUserToDb(email, password);
          
        }

        public bool checkIfEmailIsAlreadytaken(string email)
        {
            MySqlDataReader rdr = getNumberOfUsersWithSpecificEmail(email);
            rdr.Read();
            


            if (Convert.ToInt64(rdr.GetValue(0)) == 0)
            {
                closeConnection();
                return false;
            } else
            {
                return true;
            }
          
          
           
        }

    }
}
