using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using BettaPlanet.Models;
using static BettaPlanet.Models.Dto;
using static BettaPlanet.Models.Entities;
using System.Drawing;

namespace BettaPlanet.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Input()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult Urunekle(URUNLER gelenur, HttpPostedFileBase ourFile)
        {
            var myid = System.Web.HttpContext.Current.Session.SessionID;
            MethodStatus _m = new MethodStatus();
            _m.AdditionalData = new List<AddData>();
            string directory = Server.MapPath("/Content/Bettapic");
            if (gelenur.urunadi == null)
            {
                _m.Error = 1;
                _m.ErrorMessage = "Eksik bilgi girdiniz";
                _m.ReturnId = 0;
                _m.success = false;

                _m.AdditionalData.Add(new AddData()
                {
                    text = "hata",
                    value = "hata oluştu"
                });
                return Json(_m, JsonRequestBehavior.AllowGet);
            }

            else
            {
                if (ourFile.FileName != null && ourFile.ContentLength > 0)
                {

                        Bitmap Resim = new Bitmap(ourFile.InputStream);
                        Bitmap kucuk = new Bitmap(Resim, 100, 100);
                        Bitmap buyuk = new Bitmap(Resim, 500, 500);
                        string resimAdi = (Guid.NewGuid().ToString("N")) + (Path.GetFileName(ourFile.FileName));
                        buyuk.Save(Server.MapPath("~/Content/Bettapic/Bettapicb/" + resimAdi));
                        kucuk.Save(Server.MapPath("~/Content/Bettapic/Bettapick/" + resimAdi));
                        Resim.Dispose();
                        kucuk.Dispose();
                        buyuk.Dispose();
                }

                var urunek = ctx.urunler.Add(new URUNLER()
                {
                    urunadi = gelenur.urunadi,
                    fiyat = gelenur.fiyat,
                    tarih = System.DateTime.Now,
                    kuyruk=gelenur.kuyruk,
                    tecrube=gelenur.tecrube,
                    yas=gelenur.yas,
                    resim = ourFile.FileName,

            });
                
                ctx.SaveChanges();
                //return olacak
                _m.success = true;
                _m.Error = 0;
                _m.ReturnId = urunek.id;
                _m.AdditionalData.Add(new AddData()
                {
                    text = "success",
                    value = "Veri Eklendi"
                });
                return Json(urunek, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Urunler()
        {
            List<URUNLER> mainpage = new List<URUNLER>();
            mainpage = ctx.urunler.ToList();
            return View(mainpage);
        }
        public ActionResult Urunsil(int id)
        {
            URUNLER dell = ctx.urunler.FirstOrDefault(p => p.id == id);
            ctx.urunler.Remove(dell);
            ctx.SaveChanges();
            Response.Redirect("/Admin/Urunler");
            return View();
        }

        public ActionResult Duzeltici(int id)
        {
            URUNLER deler = ctx.urunler.FirstOrDefault(p => p.id == id);
            return View(deler);
        }


        [HttpPost]
        public ActionResult UrunDuzenle(int id,Dto.uruncuk ur)
        {
            URUNLER u = ctx.urunler.FirstOrDefault(q => q.id == id);
            HttpPostedFileBase resim = Request.Files["photo"];
            if (resim.FileName != null && resim.ContentLength > 0)
            {

                Bitmap Resim = new Bitmap(resim.InputStream);
                Bitmap kucuk = new Bitmap(Resim, 100, 100);
                Bitmap buyuk = new Bitmap(Resim, 500, 500);
                string resimAdi = (Guid.NewGuid().ToString("N")) + (Path.GetFileName(resim.FileName));
                buyuk.Save(Server.MapPath("~/Content/Bettapic/Bettapicb/" + resimAdi));
                kucuk.Save(Server.MapPath("~/Content/Bettapic/Bettapick/" + resimAdi));
                Resim.Dispose();
                kucuk.Dispose();
                buyuk.Dispose();
            }

                u.id = id;
                u.fiyat = ur.fiyat;
                u.kuyruk = ur.kuyruk;
                u.tarih = System.DateTime.Now;
                u.yas = ur.yas;
                u.tecrube = ur.tecrube;
                u.resimk = ur.resimk;
                u.resimb = ur.resimb;

                ctx.SaveChanges();

                Response.Redirect("/Admin/Duzeltici?id="+id);

            return View(u);
        }
        public ActionResult Inbox()
        {
            List<Iletisim> mainpage = new List<Iletisim>();
            mainpage = ctx.iletisim.ToList();
            return View(mainpage);
        }
     

    }
}