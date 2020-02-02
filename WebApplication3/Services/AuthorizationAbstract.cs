using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Services
{
    interface AuthorizationAbstract
    {
        bool isloggedAsAdmin(IHeaderDictionary headers);
        bool isloggedAsUser(IHeaderDictionary headers);
    }
}
