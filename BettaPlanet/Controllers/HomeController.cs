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
        public ActionResult Hata()
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
            i.tarih = System.DateTime.Now;
            ctx.iletisim.Add(i);
            ctx.SaveChanges();
            Response.Redirect("/Home/Contact");
            return View();
        }


        public ActionResult Bakimbilgi()
        {
            List<balikbilgi> mainpage = new List<balikbilgi>();
            mainpage = ctx.balikbilgi.ToList();
            return View(mainpage);
        }






    }
}