using DataAccessLayer.GenericRepository;
using EntityLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.CustomAuthorize;

namespace TicariOtomasyon.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly DapperGenericRepository _repository;

        public UrunlerController()
        {
            _repository = new DapperGenericRepository();
        }

        // GET: Urunler
        public ActionResult Index()
        {
            ViewBag.baslik = "Ürünler";
            return View();
        }


        [HttpPost]
        public JsonResult Listele()
        {
            string sql = "Select * from Urunler where AKTIF=1";
            IEnumerable<Urunler> liste = _repository.Query<Urunler>(sql);
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SelectList()
        {
            string sql = "Select * from Kategoriler WHERE AKTIF=1";
            IEnumerable<Kategoriler> data = _repository.Query<Kategoriler>(sql);

            List<SelectListItem> deger1 = (from x in data
                                           select new SelectListItem
                                           {
                                               Value = x.KAYITKODU,
                                               Text = x.KATEGORI
                                           }).OrderBy(x => x.Text).ToList();
            return Json(deger1, JsonRequestBehavior.AllowGet);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Ekle(Urunler urunler)
        {
            if (urunler != null && Request.Files.Count>0)
            {
                urunler.GORSEL = "";
                HttpFileCollectionBase files = Request.Files;
                for(int i =0; i < files.Count; i++)
                {
                    HttpPostedFileBase file = files[i];
                    string dosyaAdi = file.FileName;
                    urunler.GORSEL = file.FileName;

                    dosyaAdi = Path.Combine(Server.MapPath("~/Images/"), dosyaAdi);
                    file.SaveAs(dosyaAdi);
                }

                urunler.KAYITKODU = Guid.NewGuid().ToString();
                urunler.AKTIF = 1;

                string sql = "Insert into Urunler (URUN,KAYITKODU,STOK,KATEGORI,GORSEL,AKTIF) values (@URUN,@KAYITKODU,@STOK,@KATEGORI,@GORSEL,@AKTIF)";
                object parametreler = new
                {
                    @URUN=urunler.URUN,
                    @KAYITKODU=urunler.KAYITKODU,
                    @STOK=urunler.STOK,
                    @KATEGORI=urunler.KATEGORI,
                    @GORSEL= urunler.GORSEL,
                    @AKTIF=urunler.AKTIF
                };

                int ekleme = _repository.Execute(sql,parametreler);
                if (ekleme==1)
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
        public ActionResult Sil(string kayitKodu)
        {
            if (kayitKodu != null && kayitKodu != "")
            {
                string sql = "Update Urunler set AKTIF=0 where KAYITKODU=@KAYITKODU";
                object parametreler = new
                {
                    @KAYITKODU = kayitKodu
                };
                int sil = _repository.Execute(sql,parametreler);

                if (sil==1)
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
        public JsonResult Guncelle(Urunler urun)
        {
            string sql = "Select * from Urunler where ID=@ID";
            object parametreler = new
            {
                @ID=urun.ID
            };
            Urunler getir = _repository.QueryFirstOrDefault<Urunler>(sql,parametreler);
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
        public ActionResult Guncelle(int id,string urun,int stok,string kategori)
        {
            if (id != 0 && urun != "" && stok != 0 && kategori != "")
            {
                string sql = "Update Urunler set URUN=@URUN,STOK=@STOK,KATEGORI=@KATEGORI WHERE ID=@ID";
                object parametreler = new
                {
                    @URUN=urun,
                    @STOK=stok,
                    @KATEGORI=kategori,
                    @ID=id
                };
                int guncelle = _repository.Execute(sql,parametreler);
                if (guncelle==1)
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
    }
}