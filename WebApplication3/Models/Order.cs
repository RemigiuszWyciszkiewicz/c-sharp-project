using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Order
    {
        public int bookId { get; set; }
        public int userId { get; set; }
        public int amount { get; set; }
    }
}
