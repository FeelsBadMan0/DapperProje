using DataAccessLayer.GenericRepository;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace API.Controllers
{
    [Authorize]
    public class UrunlerController : ApiController
    {
        private readonly DapperGenericRepository _repository;

        public UrunlerController()
        {
            _repository = new DapperGenericRepository();
        }

       

        [HttpGet]
        public IEnumerable<Urunler> Listele()
        {
            string sql = "Select * from Urunler where AKTIF=1";
            return _repository.Query<Urunler>(sql);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IHttpActionResult UrunEkLe()
        {
            var dosya = HttpContext.Current.Request.Files.Count > 0 ?
        HttpContext.Current.Request.Files[0] : null;
            var urunler = HttpContext.Current.Request.Form;
            var urun = urunler.GetValues("URUN")[0].ToString();
            var kategori = urunler.GetValues("KATEGORI")[0].ToString();
            var stok =Convert.ToInt32(urunler.GetValues("STOK")[0]);
            var kayitKodu = Guid.NewGuid().ToString();
            var aktif =Convert.ToInt16(1);

            if (dosya != null && dosya.ContentLength > 0 && urun != null && kategori !=null && stok !=0)
            {
                var dosyaAdi = Path.GetFileName(dosya.FileName);

                var yol = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/Images/"),
                    dosyaAdi
                );

                string sql = "Insert into Urunler (URUN,KAYITKODU,STOK,KATEGORI,GORSEL,AKTIF) values (@URUN,@KAYITKODU,@STOK,@KATEGORI,@GORSEL,@AKTIF)";
                object parametreler = new
                {
                    @URUN=urun,
                    @KAYITKODU=kayitKodu,
                    @STOK=stok,
                    @KATEGORI=kategori,
                    @GORSEL=dosyaAdi,
                    @AKTIF=aktif
                };
                dosya.SaveAs(yol);
               int ekleme= _repository.Execute(sql, parametreler);
                if(ekleme != 0)
                {
                    return Ok("Ürün Ekleme İşlemi Başarılı!");
                }
                else
                {
                    return BadRequest("Ürün Eklenirken Bir Hata Oluştu!");
                }
                
               
            }
            else
            {
                return BadRequest("Ürün Alanları Boş Bırakılamaz!");
            }



          

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IHttpActionResult Sil(string kayitKodu)
        {
            if(kayitKodu != null && kayitKodu != "")
            {
                string sql = "Update Urunler set AKTIF=0 where KAYITKODU=@KAYITKODU";
                object parametreler = new
                {
                    @KAYITKODU= kayitKodu
                };
                int sil = _repository.Execute(sql,parametreler);
                if (sil ==1)
                {
                    return Ok("Ürün Başarıyla Silindi!");
                }
                else
                {
                    return BadRequest("Ürün Silinirken Bir Hata Oluştu!");
                }
            }
            else
            {
                return BadRequest("Ürün Kayıt Kodu Boş Olamaz!");
            }
        }

        [HttpGet]
        public IHttpActionResult UrunGetir(int id)
        {
            if(id != 0) 
            {
                string sql = "Select * from Urunler where ID=@ID";
                object parametreler = new
                {
                    @ID=id
                };
                Urunler urunGetir = _repository.QueryFirstOrDefault<Urunler>(sql,parametreler);
                if(urunGetir != null)
                {
                    return Ok(urunGetir);
                }
                else
                {
                    return BadRequest("Ürün Bulunamadı!");
                }
            }
            else
            {
                return BadRequest("Ürün Alanı Boş Geçilemez!");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IHttpActionResult UrunGuncelle()
        {
            var dosya = HttpContext.Current.Request.Files.Count > 0 ?
            HttpContext.Current.Request.Files[0] : null;
            var urunler = HttpContext.Current.Request.Form;
            var id =Convert.ToInt32( urunler.GetValues("ID")[0]);
            var urun = urunler.GetValues("URUN")[0].ToString();
            var kategori = urunler.GetValues("KATEGORI")[0].ToString();
            var stok = Convert.ToInt32(urunler.GetValues("STOK")[0]);

            if (dosya != null && dosya.ContentLength > 0 && urun != null && kategori != null && stok != 0)
            {
                var dosyaAdi = Path.GetFileName(dosya.FileName);

                var yol = Path.Combine(
                    HttpContext.Current.Server.MapPath("~/Images/"),
                    dosyaAdi
                );

                dosya.SaveAs(yol);

                string sql = "Update Urunler set URUN=@URUN,STOK=@STOK,KATEGORI=@KATEGORI,GORSEL=@GORSEL where ID=@ID";

                object parametreler = new
                {
                    @URUN=urun,
                    @STOK=stok,
                    @KATEGORI = kategori,
                    @GORSEL=dosyaAdi,
                    @ID=id
                };

                int guncelle=_repository.Execute(sql,parametreler);
                if (guncelle ==1)
                {
                    return Ok("Ürün Güncelleme İşlemi Başarılı!");
                }
                else
                {
                    return BadRequest("Ürün Güncellenirken Bir Hata Oluştu!");
                }
               
            }
            else
            {
                return BadRequest("Ürün Alanları Boş Bırakılamaz!");
            }
        }

    }
}
