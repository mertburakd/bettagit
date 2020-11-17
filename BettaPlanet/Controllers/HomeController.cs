using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BettaPlanet.Models.Entities;

namespace BettaPlanet.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            about a = new about();
            a = ctx.about.FirstOrDefault();


            return View(a);
        }

        public ActionResult Contact()
        {
            
            return View();
        }

        public ActionResult ContactPost(Models.Entities.iletisim iletisim)
        {
            iletisim i = new iletisim();
            i.name = iletisim.name;
            i.email = iletisim.email;
            i.topic = iletisim.topic;
            i.project = iletisim.project;
            ctx.iletisim.Add(i);
            ctx.SaveChanges();
            Response.Redirect("/Home/Contact");
            return View();
        }









    }
}