using DataAccessLayer.GenericRepository;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.CustomAuthorize;

namespace TicariOtomasyon.Controllers
{
    public class KategorilerController : Controller
    {
        private readonly DapperGenericRepository _repository;

        public KategorilerController()
        {
            _repository = new DapperGenericRepository();
        }

        // GET: Kategoriler
        public ActionResult Index()
        {
            ViewBag.baslik = "Kategoriler";
            return View();
        }

        [HttpPost]
        public JsonResult DatatableListele()
        {
            string sql = "Select * from Kategoriler WHERE AKTIF=1";
            
            IEnumerable<Kategoriler> liste = _repository.Query<Kategoriler>(sql);
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Ekle(string kategori)
        {
            if (kategori != null && kategori != "")
            {
                string kayitkodu = Guid.NewGuid().ToString();
                short aktif= 1;
                string sql = "Insert into Kategoriler (KATEGORI,KAYITKODU,AKTIF) values (@KATEGORI,@KAYITKODU,@AKTIF)";
                object parametreler = new
                {
                    @KATEGORI=kategori,
                    @KAYITKODU=kayitkodu,
                    @AKTIF=aktif
                };


                int ekle = _repository.Execute(sql,parametreler);
                if (ekle == 1)
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

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Sil(string kayitkodu)
        {
            if (kayitkodu != null)
            {
                string sql = "Update Kategoriler set AKTIF =0 where KAYITKODU=@KAYITKODU";
                object parametreler = new
                {
                    @KAYITKODU=kayitkodu
                };
                int sil = _repository.Execute(sql,parametreler);

                if (sil == 1)
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
        public JsonResult Guncelle(Kategoriler kategori)
        {
            string sql = "Select * from Kategoriler where ID=@ID";
            object parametreler = new
            {
                @ID=kategori.ID
            };
            Kategoriler getir = _repository.QueryFirstOrDefault<Kategoriler>(sql,parametreler);
            if (getir != null)
            {
                return Json(getir, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(getir, JsonRequestBehavior.AllowGet);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Guncelle(string kategori,int id)
        {
            if (kategori !=null && kategori !="" && id !=0)
            {
                string sql = "Update Kategoriler set KATEGORI=@KATEGORI WHERE ID=@ID";
                object parametreler = new
                {
                    @KATEGORI=kategori,
                    @ID = id
                };
                int guncelle = _repository.Execute(sql,parametreler);
                if(guncelle == 1)
                {
                    return new JsonResult { Data = new {status = true} };  
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
    }
}