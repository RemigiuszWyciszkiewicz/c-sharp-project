using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;
using WebApplication3.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{

    [Route("api/order")]
    public class OrderController : Controller
    {

        OrderRepository orderRepository = new OrderRepository();

        // GET: api/<controller>
        [HttpGet]
        public ResponseWrapper<List<Order>> Get()
        {
            int id = TokenGenerator.getIdFromToken(Request.Headers["Authorization"]);
          
            return new ResponseWrapper<List<Order>>()
            {
                httpStatusCode = HttpStatusCode.OK,
                responseBody = orderRepository.getAll(id),
                responseMessage = "All orders has been returned"
            };
            return null;
        }

        // GET api/<controller>/5
        [HttpGet("summary")]
        public int Get(int id)
        {
            return orderRepository.getCostOfAllOrders(TokenGenerator.getIdFromToken(Request.Headers["Authorization"]));

             
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void deleteOrder([FromBody]Order value)
        {
            Console.WriteLine(value);
            orderRepository.deleteOrder(value);

        }

        // POST api/<controller>
        [HttpPost]
        public string Post([FromBody]Order order)
        {
            Console.WriteLine(order.amount);
            Console.WriteLine(order.userId);
            orderRepository.createNewOrder(order);
            return "TEST";
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

     
    }
}
