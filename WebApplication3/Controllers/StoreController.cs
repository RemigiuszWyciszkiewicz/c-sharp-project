using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3
{
    [Route("api/store")]
    public class StoreController : Controller
    {

        AuthService authService = new AuthService();
        BookRepository bookRepository = new BookRepository();


        // GET: api/<controller>
        [HttpGet]
        public ResponseWrapper<List<Book>> GetBooks()
        {
            Console.WriteLine("TEST");
            if (authService.isloggedAsUser(Request.Headers))
            {

                return new ResponseWrapper<List<Book>> {
                    responseBody = bookRepository.getBooks(),
                    httpStatusCode = HttpStatusCode.OK,
                    responseMessage = "List of books"
                };
            }

            return new ResponseWrapper<List<Book>>
            {
                responseBody = null,
                httpStatusCode = HttpStatusCode.Unauthorized,
                responseMessage = "Unauthorized"
            };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
