using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Domain.Entities.User.Models;

namespace WebApplication1.Extension
{
    public static class HttpContextExtensions
    {
        public static UMinData GetMySessionObject(this HttpContext current)
        {
            return (UMinData)current?.Session["__SessionObject"];
        }

        public static void SetMySessionObject(this HttpContext current, UMinData profile)
        {
            current.Session.Add("__SessionObject", profile);
        }
    }
}