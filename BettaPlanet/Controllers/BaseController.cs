using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BettaPlanet.Models;
using static BettaPlanet.Models.Entities;
namespace BettaPlanet.Controllers
{
    public class BaseController : Controller
    {
        public Context ctx;
        public BaseController()
        {
            if (ctx == null)
                ctx = new Context();
        }

    }
}