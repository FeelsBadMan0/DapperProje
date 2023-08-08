using DataAccessLayer.GenericRepository;
using EntityLayer;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TicariOtomasyon.Controllers
{
    public class SatisHareketleriController : Controller
    {
        private readonly DapperGenericRepository _repository;

        public SatisHareketleriController()
        {
            _repository = new DapperGenericRepository();
        }

        // GET: SatisHareketleri
        public ActionResult Index()
        {
            ViewBag.baslik = "Satış Hareketleri";
            return View();
        }

        [HttpPost]
        public JsonResult Listele()
        {
            string sql = "Select * from SatisHareketleri";
            IEnumerable<SatisHareketleri> liste = _repository.Query<SatisHareketleri>(sql);
            return Json(liste, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult UrunGetir()
        {

            //'Yürütme Zaman Aşımı Süresi Doldu. Zaman aşımı süresi işlem tamamlanmadan önce doldu veya sunucu yanıt vermiyor.
            //İşlem kullanıcı tarafından iptal edildi
            string sql = "Select * from Urunler where AKTIF=1";
            IEnumerable<Urunler> data = _repository.Query<Urunler>(sql);
            List<SelectListItem> urun = (from x in data
                                         select new SelectListItem
                                         {
                                             Value = x.KAYITKODU,
                                             Text = x.URUN
                                         }).OrderBy(x => x.Text).ToList();
            return Json(urun, JsonRequestBehavior.AllowGet);



        }

        [HttpGet]
        public JsonResult CariGetir()
        {
            string sql = "Select * from Cariler where AKTIF=1";
            IEnumerable<Cariler> data = _repository.Query<Cariler>(sql);
            List<SelectListItem> cari = (from x in data
                                         select new SelectListItem
                                         {
                                             Value = x.KAYITKODU,
                                             Text = x.ADSOYAD
                                         }).OrderBy(x => x.Text).ToList();
            return Json(cari, JsonRequestBehavior.AllowGet);


        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Ekle(SatisHareketleri satis)
        {
            if (satis.CARI != "" && satis.URUN != "" && satis.FIYAT != 0 && satis.CARI != null && satis.URUN != null)
            {
                satis.KAYITKODU = Guid.NewGuid().ToString();
                satis.SATISTARIHI = DateTime.Now;

                string sql = "Insert into SatisHareketleri (URUN,KAYITKODU,CARI,MIKTAR,FIYAT,SATISTARIHI) values (@URUN,@KAYITKODU,@CARI,@MIKTAR,@FIYAT,@SATISTARIHI)";
                object parametreler = new
                {
                    @URUN = satis.URUN,
                    @KAYITKODU = satis.KAYITKODU,
                    @CARI = satis.CARI,
                    @MIKTAR = satis.MIKTAR,
                    @FIYAT = satis.FIYAT,
                    @SATISTARIHI = satis.SATISTARIHI
                };
                int ekleme = _repository.Execute(sql,parametreler);
                if (ekleme !=0)
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