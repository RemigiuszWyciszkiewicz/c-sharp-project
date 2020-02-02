using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services
{
    public class DataBaseConnectionActionsMethods : DataBaseConnection
    {

        public MySqlDataReader selectDataFromDb(string entityName)
        {
             MySqlCommand cmd = new MySqlCommand("select * from " + entityName, conn);
            
            return cmd.ExecuteReader();
        } 

        public void insertUserToDb(string email, string password)
        {

            openConnection();
            string insertData = "insert into user(email,password) values (@email, @password)";


            MySqlCommand cmd = new MySqlCommand(insertData,conn);

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);

             cmd.ExecuteReader();

            closeConnection();

        }

        protected MySqlDataReader getNumberOfUsersWithSpecificEmail(String email)
        {
            openConnection();
            MySqlCommand cmd = new MySqlCommand("select count(*) from user where email = @email ", conn);
            cmd.Parameters.AddWithValue("@email", email);
            return cmd.ExecuteReader();
            
        }

        
           
           

    }
}
