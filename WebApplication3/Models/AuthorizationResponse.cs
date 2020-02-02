using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class AuthorizationResponse
    {
        public string token { get; set; }
        public RoleEnum roleEnum { get; set; }
        public string tokenExpiration { get; set; }
    }
}
