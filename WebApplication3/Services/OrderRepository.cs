using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.Utils;

namespace WebApplication3.Services
{
    public class OrderRepository: DataBaseConnectionActionsMethods, RowExtracotr<Order>
    {

        List<Order> list = new List<Order>();

        public void createNewOrder(Order order)
        {
            insertOrderToDatabase(order);
            
        }

       

        public List<Order> getAll(int id)
        {
            MySqlDataReader rdr = getAllOrdersOfSpecificUser(id);
            while (rdr.Read())
            {
                list.Add(extractBookFromDbRow((IDataRecord)rdr));

            }
            closeConnection();
            return list;
        }

        public Order extractBookFromDbRow(IDataRecord record)
        {
            return new Order
            {
                amount = Convert.ToInt32(record[0]) ,
                bookId = Convert.ToInt32(record[1])
            };
        }

        public int getCostOfAllOrders(int id)
        {
            int cost = 0;
            MySqlDataReader rdr = selectCostOfAllOrders(id);
            rdr.Read();
            try
            {
                 cost = Convert.ToInt32(rdr.GetValue(0));
            } catch(Exception e)
            {
                Console.WriteLine("null exception");
            }
          
            closeConnection();
            return cost;

        }




    }
}
