using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BettaPlanet.Models.Entities;
using static BettaPlanet.Models.Dto;
using System.Web.Security;
using System.Threading.Tasks;

namespace BettaPlanet.Controllers
{
    public class LoginController : BaseController
    {
        System.Web.HttpContext htc = System.Web.HttpContext.Current;

        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult dologin(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var user = ctx.admin.FirstOrDefault(ww => ww.username == login.username && ww.password == login.password);

                if (user != null)
                {
                    HttpCookie usr = new HttpCookie("username");
                    usr.Value = user.username;
                    usr.Expires = DateTime.Now.AddDays(2);
                    htc.Response.Cookies.Add(usr);

                    Response.Redirect("/Admin/Index");
                    return View();

                }

                else
                {
                    Response.Redirect("/Login/Index?h=Giriş başarısız", true);
                }
            }
            return View(login);

        }

        public ActionResult Logout()
        {
            htc.Response.Cookies["username"].Expires = DateTime.Now.AddDays(-2);

            Response.Redirect("/Login/Index");
            return View();
        }

    }
}