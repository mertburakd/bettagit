﻿using System;
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
        System.Web.HttpContext htc = System.Web.HttpContext.Current;
        Auth yetki = new Auth();
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


                Bitmap Resim = new Bitmap(ourFile.InputStream);
                Bitmap kucuk = new Bitmap(Resim, 75, 75);
                Bitmap buyuk = new Bitmap(Resim, 250, 250);
                string resimAdi = (Path.GetFileName(ourFile.FileName));
                buyuk.Save(Server.MapPath("~/Content/Bettapic/Bettapicb/" + resimAdi));
                kucuk.Save(Server.MapPath("~/Content/Bettapic/Bettapick/" + resimAdi));
                Resim.Dispose();
                kucuk.Dispose();
                buyuk.Dispose();

                var urunek = ctx.urunler.Add(new URUNLER()
                {
                    urunadi = gelenur.urunadi,
                    fiyat = gelenur.fiyat,
                    tarih = System.DateTime.Now,
                    kuyruk = gelenur.kuyruk,
                    aciklama = gelenur.aciklama,
                    tecrube = gelenur.tecrube,
                    yas = gelenur.yas,
                    resimb = resimAdi,
                    resimk = resimAdi,

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
        public ActionResult UrunDuzenle(int id, Dto.uruncuk ur)
        {
            URUNLER u = ctx.urunler.FirstOrDefault(q => q.id == id);
            HttpPostedFileBase resim = Request.Files["photo"];
            if (resim.FileName != null && resim.ContentLength > 0)
            {

                Bitmap Resim = new Bitmap(resim.InputStream);
                Bitmap kucuk = new Bitmap(Resim, 75, 75);
                Bitmap buyuk = new Bitmap(Resim, 250, 250);
                string resimAdi = (Guid.NewGuid().ToString("N")) + (Path.GetFileName(resim.FileName));
                buyuk.Save(Server.MapPath("~/Content/Bettapic/Bettapicb/" + resimAdi));
                kucuk.Save(Server.MapPath("~/Content/Bettapic/Bettapick/" + resimAdi));
                Resim.Dispose();
                kucuk.Dispose();
                buyuk.Dispose();


                u.id = id;
                u.fiyat = ur.fiyat;
                u.kuyruk = ur.kuyruk;
                u.tarih = System.DateTime.Now;
                u.yas = ur.yas;
                u.tecrube = ur.tecrube;
                u.resimk = resimAdi;
                u.resimb = resimAdi;
                u.aciklama = ur.aciklama;


            }
            else
            {
                u.id = id;
                u.fiyat = ur.fiyat;
                u.kuyruk = ur.kuyruk;
                u.tarih = System.DateTime.Now;
                u.yas = ur.yas;
                u.tecrube = ur.tecrube;
                u.aciklama = ur.aciklama;
            }
            ctx.SaveChanges();

            Response.Redirect("/Admin/Duzeltici?id=" + id);

            return View(u);
        }
        public ActionResult Inbox()
        {
            List<iletisim> mainpage = new List<iletisim>();
            mainpage = ctx.iletisim.ToList();
            return View(mainpage);
        }
        public ActionResult DellMessage(int id)
        {
            iletisim x = ctx.iletisim.FirstOrDefault(p => p.id == id);
            ctx.iletisim.Remove(x);
            ctx.SaveChanges();
            Response.Redirect("/Admin/Inbox");
            return View();

        }


        public ActionResult Siparis(int id)
        {
            URUNLER sip = ctx.urunler.FirstOrDefault(p => p.id == id);
            return View(sip);
        }



        public ActionResult Siparisolustur(int id, Dto.sip ur)
        {
            URUNLER u = ctx.urunler.FirstOrDefault(q => q.id == id);
            sip adresgir = new sip();
            if ( u.id > 0)
            {
                adresgir.adres = ur.adres;
                adresgir.aliciad = ur.aliciad;
                adresgir.tarih = System.DateTime.Now;
                adresgir.telefon = ur.telefon;

                var se = ctx.siparisler.Add(new siparisler()
                {

                adres=adresgir.adres,
                aliciad=adresgir.aliciad,
                telefon=adresgir.telefon,
                tarih = adresgir.tarih,
                kuyruk = u.kuyruk,
                fiyat = u.fiyat,
                resimk = u.resimk,
                tecrube = u.tecrube,
                urunadi = u.urunadi,
                yas = u.yas,
                aciklama = u.aciklama,
            });



            }
            ctx.SaveChanges();
            Response.Redirect("/Admin/Siparis?id=" + id);

            return View(u);
        }

    }
}