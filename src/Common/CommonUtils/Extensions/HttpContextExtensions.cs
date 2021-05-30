using System;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;

namespace CommonUtils.Extensions
{
    public static class HttpContextExtensions
    {
        public static Guid GetIdFromJwtToken(this HttpContext context) =>
            Guid.Parse(context.User.Claims.Single(_ => _.Type == JwtBearerDefaults.AuthenticationScheme).Value);
    }
}