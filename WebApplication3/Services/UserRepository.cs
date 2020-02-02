using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

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


            Console.WriteLine(rdr.GetValue(0));
            if (Convert.ToInt64(rdr.GetValue(0)) == 0)
            {
                closeConnection();
                return false;
            } else
            {
                closeConnection();
                return true;
            }

        }

        public int getId(User user)
        {
            MySqlDataReader rdr = getIdOfuser(user);
            rdr.Read();
            int id = Convert.ToInt32(rdr.GetValue(0));
            closeConnection();
            return id;

        }

    }
}
