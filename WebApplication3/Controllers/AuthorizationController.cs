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

namespace WebApplication3
{
    [Route("api/auth")]
    public class AuthorizationController : Controller
    {
        UserRepository userRepository = new UserRepository();
        AuthService authService = new AuthService();


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("signUp")]
        [HttpPost]
        public ResponseWrapper<User> SignUp([FromBody]User value)
        {
            if (!ModelState.IsValid) {
                Console.WriteLine("Brak walidacji");
                return new ResponseWrapper<User>()
                {
                    httpStatusCode = HttpStatusCode.BadRequest,
                    responseBody = null,
                    responseMessage = "Validation error,invalid email or password"
                };
            }
            if (userRepository.checkIfEmailIsAlreadytaken(value.email))
            {
                Console.WriteLine("CheckIfTaken");
                return new ResponseWrapper<User>()
                {
                    httpStatusCode = HttpStatusCode.BadRequest,
                    responseBody = null,
                    responseMessage = "Given email aleady exists."
                };
            }
            else
            {
                userRepository.insertUserToDb(value.email, value.password);

                return new ResponseWrapper<User>()
                {
                    httpStatusCode = HttpStatusCode.OK,
                    responseBody = value,
                    responseMessage = "Account has been created succesfuly."
                };


            }

            return null;


        }


        [Route("signUp")]
        [HttpPost]
        public ResponseWrapper<User> SignUp([FromBody]User value)
        {
            Console.WriteLine("TEST");
            Console.WriteLine(value.email);
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Brak walidacji");
                return new ResponseWrapper<User>()
                {
                    httpStatusCode = HttpStatusCode.BadRequest,
                    responseBody = null,
                    responseMessage = "Validation error,invalid email or password"
                };
            }


            if (userRepository.checkIfEmailIsAlreadytaken(value.email))
            {
                Console.WriteLine("CheckIfTaken");
                return new ResponseWrapper<User>()
                {
                    httpStatusCode = HttpStatusCode.BadRequest,
                    responseBody = null,
                    responseMessage = "Given email aleady exists."
                };
            }
            else
            {
                userRepository.insertUserToDb(value.email, value.password);

                return new ResponseWrapper<User>()
                {
                    httpStatusCode = HttpStatusCode.OK,
                    responseBody = value,
                    responseMessage = "Account has been created succesfuly."
                };


            }

            return null;
        }

        [Route("signIn")]
        [HttpPost]
        public ResponseWrapper<AuthorizationResponse> SignIn([FromBody]User user)
        {

            Console.WriteLine("TEST");
            if (authService.checkIfIsAdmin(user)) {




                return new ResponseWrapper<AuthorizationResponse>()
                {
                    httpStatusCode = HttpStatusCode.OK,
                    responseBody = new AuthorizationResponse() {
                        roleEnum = RoleEnum.ADMIN,
                        tokenExpiration = "2 hours",
                        token = TokenGenerator.generateToken()
                    },
                    responseMessage = "You are logged in as ADMIN"
                };
            }

             return new ResponseWrapper<AuthorizationResponse>()
            {
                httpStatusCode = HttpStatusCode.OK,
                responseBody = null ,
                responseMessage = "Test"
            };


        }


        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User value)
        {
            Console.WriteLine(value.email);
            Console.WriteLine(value.email);
            Console.WriteLine(value.email);
            Console.WriteLine(value.email);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
