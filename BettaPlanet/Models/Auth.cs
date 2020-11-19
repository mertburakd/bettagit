using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BettaPlanet.Models
{

    public class Auth
    {
        System.Web.HttpContext htc = System.Web.HttpContext.Current;
        public Auth()
        {
            if (htc.Request.Cookies["username"] == null)
            {
                htc.Response.Redirect("/Login/Index");
            }
        }
    }
}