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
    public class SatisHareketleriController : ApiController
    {
        private readonly DapperGenericRepository _repository;

        public SatisHareketleriController()
        {
            _repository = new DapperGenericRepository();
        }


        [HttpGet]
        public IEnumerable<SatisHareketleri> Listele()
        {
            string sql = "Select * from SatisHareketleri";
            return _repository.Query<SatisHareketleri>(sql);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IHttpActionResult SatisEkle(SatisHareketleri satis)
        {
            if(satis.CARI !=null && satis.CARI!="" &&satis.URUN != "" && satis.URUN !=null && satis.URUN !="" && satis.FIYAT !=0 && satis.MIKTAR != 0)
            {
                satis.KAYITKODU = Guid.NewGuid().ToString();
                satis.SATISTARIHI = DateTime.Now;

                string sql = "Insert into SatisHareketleri (URUN,KAYITKODU,CARI,MIKTAR,FIYAT,SATISTARIHI) values (@URUN,@KAYITKODU,@CARI,@MIKTAR,@FIYAT,@SATISTARIHI)";
                object parametreler = new
                {
                    @URUN=satis.URUN,
                    @KAYITKODU=satis.KAYITKODU,
                    @CARI=satis.CARI,
                    @MIKTAR=satis.MIKTAR,
                    @FIYAT=satis.FIYAT,
                    @SATISTARIHI=satis.SATISTARIHI
                };

                int ekle = _repository.Execute(sql,parametreler);
                if(ekle !=0)
                {
                    return Ok("Satış Ekleme İşlemi Baarılı!");
                }
                else
                {
                    return BadRequest("Satış Yapılırken Bir Hata Oluştu!");
                }
            }
            else
            {
                return BadRequest("Satış Alanları Boş Bırakılamaz!");
            }
        }



        [HttpGet]
        public IHttpActionResult SatisGetir(int id)
        {
            if(id != 0)
            {
                string sql = "Select * from SatisHareketleri where ID=@ID";
                object parametreler = new
                {
                    @ID=id
                };
                SatisHareketleri getir = _repository.QueryFirstOrDefault<SatisHareketleri>(sql,parametreler);
                if (getir !=null)
                {
                    return Ok(getir);
                }
                else
                {
                    return BadRequest("Böyle Bir Satış Bulunamadı!");
                }
            }
            else
            {
                return BadRequest("Böyle Bir Satış ID'si Bulunamadı!");
            }
        }

    }
}
