using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

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

        protected MySqlDataReader checkIfThereIsUSerwithSpecificPasswordAndEmail(User user)
        {
            openConnection();
            MySqlCommand cmd = new MySqlCommand("select count(id) from user where email = @email and password = @password",conn);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);
            return cmd.ExecuteReader();
        }

        protected MySqlDataReader getIdOfuser(User user)
        {
            openConnection();
            MySqlCommand cmd = new MySqlCommand("select id from user where email = @email and password = @password", conn);
            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);
            return cmd.ExecuteReader();
        }





    }
}
