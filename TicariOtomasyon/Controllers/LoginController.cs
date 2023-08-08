using DataAccessLayer.GenericRepository;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace TicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly DapperGenericRepository _repository;

        public LoginController()
        {
            _repository = new DapperGenericRepository();
        }

        // GET: Login
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult GirisYap(string kullaniciAdi,string sifre)
        {
            if(kullaniciAdi != null && kullaniciAdi !="" && sifre!=null && sifre !="") 
            {
                string sql = "Select * from Kullanicilar where KULLANICIADI=@KULLANICIADI and SIFRE=@SIFRE";
                object parametreler = new
                {
                    @KULLANICIADI=kullaniciAdi,
                    @SIFRE=sifre
                };

                Kullanicilar kullanici = _repository.QueryFirstOrDefault<Kullanicilar>(sql,parametreler);
                if(kullanici != null)
                {
                    Session["ID"]=kullanici.ID;
                    Session["AKTIF"] =kullanici.AKTIF;
                    return new JsonResult { Data = new { status = true } };
                }
                else
                {
                    return new JsonResult{ Data = new { status = false } };
                }
            }
            else
            {
                return new JsonResult { Data = new { status = false } };
            }
        }

        public ActionResult CikisYap()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            
            return RedirectToAction("GirisYap", "Login");
        }
    }

    
}

