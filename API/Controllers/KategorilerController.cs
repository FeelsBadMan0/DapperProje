using DataAccessLayer.GenericRepository;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class KategorilerController : ApiController
    {
        private readonly DapperGenericRepository _repository;

        public KategorilerController()
        {
            _repository = new DapperGenericRepository();
        }



        [HttpGet]
        public IEnumerable<Kategoriler> Listele()
        {
            string sql = "Select * from Kategoriler WHERE AKTIF=1";
            return _repository.Query<Kategoriler>(sql);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IHttpActionResult KategoriEkle(Kategoriler kategori)
        {
            if (kategori.KATEGORI !=null && kategori.KATEGORI !="")
            {
                string kayitKodu = kategori.KAYITKODU = Guid.NewGuid().ToString();
                short aktif = kategori.AKTIF = 1;
                kategori.AKTIF = 1;

                string sql = "Insert into Kategoriler (KATEGORI,KAYITKODU,AKTIF) values (@KATEGORI,@KAYITKODU,@AKTIF)";
                object parametreler = new
                {
                    @KATEGORI=kategori.KATEGORI,
                    @KAYITKODU=kategori.KAYITKODU,
                    @AKTIF = kategori.AKTIF
                };

                int kategoriEkle = _repository.Execute(sql, parametreler);
                if (kategoriEkle==1)
                {
                    return Ok("Kategori Başarıyla Eklendi!");
                }
                else
                {
                    return BadRequest("Kategori Eklenrken Bir Hata Oluştu!");
                }
            }
            else
            {
                return BadRequest("Lütfen Kategori Bilgilerini Boş Bırakmayın!");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IHttpActionResult Sil(string kayitkodu)
        {
            if(kayitkodu != null && kayitkodu != "")
            {
                string sql = "Update Kategoriler set AKTIF =0 where KAYITKODU=@KAYITKODU";
                object parametreler = new
                {
                    @KAYITKODU=kayitkodu
                };

                int kategoriSil = _repository.Execute(sql,parametreler);
                if (kategoriSil==1)
                {
                    return Ok("Kategori Başarıya Silindi!");
                }
                else
                {
                    return BadRequest("Böyle Bir Kullanıcı Yok!");
                }
            }
            else
            {
                return BadRequest("Kayıt Kodunu Boş Bırakmayın!");
            }
        }

        [HttpGet]
        public IHttpActionResult KategoriGetir(int id)
        {
            if(id !=0 )
            {
                string sql = "Select * from Kategoriler where ID=@ID";
                object parametreler = new
                {
                    @ID=id
                };

                Kategoriler kategoriGetir = _repository.QueryFirstOrDefault<Kategoriler>(sql,parametreler);
                if(kategoriGetir != null)
                {
                    return Ok(kategoriGetir);
                }
                else
                {
                    return BadRequest("Kullanıcı Bulunamadı!");
                }
            }
            else
            {
                return BadRequest("ID alanını boş bırakmayın!");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IHttpActionResult KategoriGuncelle(string kategori,int id)
        {
            if(id!=0 )
            {
                if(kategori != null && kategori != "")
                {
                    string sql = "Update Kategoriler set KATEGORI=@KATEGORI WHERE ID=@ID";
                    object parametreler = new
                    {
                        @ID=id,
                        @KATEGORI=kategori
                    };

                    int guncelle = _repository.Execute(sql,parametreler);
                    if (guncelle==1)
                    {
                        return Ok("Kategori Başarıyla Güncellendi!");
                    }
                    else
                    {
                        return BadRequest("Kategori Eklenirken Bir Hata Oluştu!");
                    }
                }
                else
                {
                    return BadRequest("Kategori Adı Boş Bırakılamaz!");
                }
            }
            else
            {
                return BadRequest("ID Alanı Boş Bırakılamaz!");
            }
        }
    }
}
