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
            List<URUNLER> mainpage = new List<URUNLER>();
            mainpage = ctx.urunler.ToList();
            return View(mainpage);
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








    }
}