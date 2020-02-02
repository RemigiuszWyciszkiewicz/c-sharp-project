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

        protected void insertOrderToDatabase(Order oreder)
        {
            openConnection();

            string insertData = "insert into  bookstore.order(user_id,book_id,amount) values (@user_id, @book_id, @amount)";


            MySqlCommand cmd = new MySqlCommand(insertData, conn);

            cmd.Parameters.AddWithValue("@user_id", oreder.userId);
            cmd.Parameters.AddWithValue("@book_id", oreder.bookId);
            cmd.Parameters.AddWithValue("@amount", oreder.amount);
            cmd.ExecuteReader();
            closeConnection();
        }

         protected MySqlDataReader getAllOrdersOfSpecificUser(int id)
        {
            openConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT amount,book_id FROM bookstore.order where user_id = "+ id, conn);
            return cmd.ExecuteReader();
        }

        protected MySqlDataReader selectCostOfAllOrders(int id)
        {
            openConnection();
             MySqlCommand cmd = new MySqlCommand("SELECT sum((o.amount * b.price)) as cost FROM bookstore.order o inner join book b on o.book_id = b.id where o.user_id = " + id, conn);
            return cmd.ExecuteReader();
        }

        protected void deleteOrderfromDb(Order order)
        {
            openConnection();
            MySqlCommand cmd = new MySqlCommand("delete from bookstore.order a where a.user_id=@user_id and a.book_id = @book_id",conn);
            cmd.Parameters.AddWithValue("@user_id", order.userId);
            cmd.Parameters.AddWithValue("@book_id", order.bookId);
            cmd.ExecuteReader();
            closeConnection();
        }





    }
}
