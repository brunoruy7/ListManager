using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ListManager.Service
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContext;
        public UserService(IHttpContextAccessor httpcontext)
        {
            this.httpContext = httpContext;
        }
        public string GetUserId()
        {
            return this.httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
