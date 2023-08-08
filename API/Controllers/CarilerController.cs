using DataAccessLayer.GenericRepository;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{

    [Authorize]
    public class CarilerController : ApiController
    {
        private readonly DapperGenericRepository _repository;

        public CarilerController()
        {
            _repository = new DapperGenericRepository();
        }

        [HttpGet]
        public IEnumerable<Cariler> Listele()
        {
            string sql = "Select * from Cariler where AKTIF=1";
            return _repository.Query<Cariler>(sql);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public IHttpActionResult CariEkle(Cariler cari)
        {
            if(cari.ADSOYAD != null &&cari.ADSOYAD !="" &&cari.MAIL!=null &&cari.MAIL!=""&&cari.VERGINO != 0)
            {
                string kayitKodu=cari.KAYITKODU = Guid.NewGuid().ToString();
                short vergiNo = cari.AKTIF = 1;
                DateTime kayitTarihi = cari.KAYITTARIHI= DateTime.Now;

                string sql = "Insert into Cariler (ADSOYAD,MAIL,KAYITKODU,KAYITTARIHI,VERGINO,AKTIF) values (@ADSOYAD,@MAIL,@KAYITKODU,@KAYITTARIHI,@VERGINO,@AKTIF)";
                object parametreler = new
                {
                    @ADSOYAD=cari.ADSOYAD,
                    @MAIL=cari.MAIL,
                    @KAYITKODU=cari.KAYITKODU,
                    @KAYITTARIHI=cari.KAYITTARIHI,
                    @VERGINO=cari.VERGINO,
                    @AKTIF=cari.AKTIF
                };
                int ekle = _repository.Execute(sql,parametreler);
                if(ekle==1)
                {
                    
                    return Ok("Kişi başarıyla eklendi!");
                }
                else
                {
                    return BadRequest("Cari Eklenirken Bir Hata Oluştu!");
                }
            }
            else
            {
               return BadRequest("Lütfen Cari Bilgilerini Doldurun!");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IHttpActionResult Sil(string kayitKodu)
        {
            if(kayitKodu !=null && kayitKodu != "")
            {
                string sql = "Update Cariler set AKTIF=0 where KAYITKODU=@KAYITKODU";
                object parametreler = new
                {
                    @KAYITKODU = kayitKodu
                };

                int sil = _repository.Execute(sql,parametreler);
                if (sil==1)
                {
                    return Ok("Kişi Başarıyla Silindi!");
                }
                else
                {
                    return BadRequest("Cari Silinirken Bir Hata Oluştu!");
                }
            }
            else
            {
                return BadRequest("Kayıt Kodu Boş Bırakılamaz!");
            }
        }


        [HttpGet]
        public IHttpActionResult CariGetir(int id)
        {
            if(id != 0)
            {
                string sql = "Select * from Cariler where ID=@ID";
                object parametreler = new
                {
                    @ID=id
                };

                Cariler cari = _repository.QueryFirstOrDefault<Cariler>(sql,parametreler);
                if(cari != null) 
                {
                    return Ok(cari);
                }
                else
                {
                    return BadRequest("Cari Eklenirken Bir Hata Oluştu!");
                }
            }
            else
            {
                return BadRequest("ID Alanı Boş Bırakılamaz!");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IHttpActionResult CariGuncelle(string adsoyad, string mail, int vergino, int id)
        {
            if(adsoyad != null && adsoyad !="" && mail != null && mail !="" && vergino !=0 && id != 0)
            {
                string sql = "Update Cariler set ADSOYAD=@ADSOYAD,MAIL=@MAIL,VERGINO=@VERGINO WHERE ID=@ID";
                object parametreler = new
                {
                    @ADSOYAD =adsoyad,
                    @MAIL=mail,
                    @VERGINO=vergino,
                    @ID=id
                };

                int guncelle = _repository.Execute(sql,parametreler);
                if(guncelle==1)
                {
                    return Ok("Cari Güncelleme Başarılı Bir Şekilde Gerçekleşti!");
                }
                else
                {
                    return BadRequest("Cari Güncellenirken Bir Hata Oluştu!");
                }
            }
            else
            {
                return BadRequest("Cari Bilgileri Boş Bırakılamaz!");
            }
        }
    }
}
