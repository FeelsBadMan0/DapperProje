using DataAccessLayer.GenericRepository;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.CustomAuthorize;

namespace TicariOtomasyon.Controllers
{
    [CustomAuthorize("Admin")]
    public class CarilerController : Controller
    {
        private readonly DapperGenericRepository _repository;

        public CarilerController()
        {
            _repository = new DapperGenericRepository();
        }

        // GET: Cariler
        public ActionResult Index()
        {
            
            ViewBag.baslik = "Cariler";
            return View();
        }

        [HttpPost]
        public JsonResult Listele()
        {
            string sql = "Select * from Cariler where AKTIF=1";
            IEnumerable<Cariler> liste = _repository.Query<Cariler>(sql);
            return Json(liste, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Ekle(Cariler cariler)
        {
            if (cariler.MAIL != "" && cariler.ADSOYAD != "" && cariler.VERGINO != 0)
            {
                cariler.KAYITKODU = Guid.NewGuid().ToString();
                cariler.KAYITTARIHI = DateTime.Now;
                cariler.AKTIF = 1;

                string sql = "Insert into Cariler (ADSOYAD,MAIL,KAYITKODU,KAYITTARIHI,VERGINO,AKTIF) values (@ADSOYAD,@MAIL,@KAYITKODU,@KAYITTARIHI,@VERGINO,@AKTIF)";
                object parametreler = cariler;

                int ekleme =_repository.Execute(sql,parametreler);
                if (ekleme == 1)
                {

                    return new JsonResult { Data = new {status = true}};
                }
                else
                {
                    return new JsonResult { Data = new { status = false } };
                }
            }
            else
            {
                return new JsonResult { Data = new { status = false } };
            }


        }

        [HttpPost]
        public ActionResult Sil(string kayitKodu)
        {
            if (kayitKodu != "" && kayitKodu != null)
            {
                string sql = "Update Cariler set AKTIF=0 where KAYITKODU=@KAYITKODU";
                object parametreler = new
                {
                    @KAYITKODU = kayitKodu
                };
                int durum = _repository.Execute(sql,parametreler);
                if (durum == 1)
                {
                    return new JsonResult { Data = new { status = true } };
                }
                else
                {
                    return new JsonResult { Data = new { status = false } };
                }
            }
            else
            {
                return new JsonResult { Data = new { status = false } };
            }
        }

        [HttpGet]
        public JsonResult Guncelle(Cariler cari)
        {
            string sql = "Select * from Cariler where ID=@ID";
            object parametreler = new
            {
                @ID = cari.ID
            };
            Cariler getir = _repository.QueryFirstOrDefault<Cariler>(sql,parametreler);
            if (getir != null)
            {
                return Json(getir, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(getir, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Guncelle(string adsoyad, string mail, int vergino, int id)
        {
            string sql = "Update Cariler set ADSOYAD=@ADSOYAD,MAIL=@MAIL,VERGINO=@VERGINO WHERE ID=@ID";
            object parametreler = new
            {
                @ADSOYAD=adsoyad,
                @MAIL=mail,
                @VERGINO=vergino,
                @ID=id
            };


            int guncelle = _repository.Execute(sql,parametreler);
            if (guncelle == 1)
            {
                return new JsonResult { Data = new { status = true } };
            }
            else
            {
                return new JsonResult { Data = new { status = false } };
            }
        }
    }
}