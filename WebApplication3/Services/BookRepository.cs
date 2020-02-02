using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class BookRepository: DataBaseConnectionActionsMethods
    {
        List<Book> books = new List<Book>();

        public List<Book> getBooks()
        {
            openConnection();

            MySqlDataReader rdr = selectDataFromDb("book");
            while (rdr.Read())
            {
                books.Add(extractBookFromDbRow((IDataRecord)rdr));

            }
            closeConnection();
            return books;
        }

        private Book extractBookFromDbRow(IDataRecord record)
        {

            return new Book
            {
                id = (int)record[0],
                name = record[1].ToString(),
                author = record[2].ToString(),
                relase_date = record[3].ToString(),
                amount = (int)record[4],
                price = (float)record[5]

            };

        }

    }
}
