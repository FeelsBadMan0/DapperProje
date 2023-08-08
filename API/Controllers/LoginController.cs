using API.Jwt;
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
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        private readonly DapperGenericRepository _repository;

        public LoginController()
        {
            _repository = new DapperGenericRepository();
        }


        [HttpPost]
        public IHttpActionResult GirisYap(string kullaniciAdi, string sifre)
        {
            string sql = "Select * from Kullanicilar where KULLANICIADI=@KULLANICIADI and SIFRE=@SIFRE";
            object parametreler = new
            {
                @KULLANICIADI = kullaniciAdi,
                @SIFRE = sifre
            };
            Kullanicilar kullanici= _repository.QueryFirstOrDefault<Kullanicilar>(sql, parametreler);
            if(kullanici !=null)
            {
                var token = JwtManeger.GetToken(kullanici.KULLANICIADI, kullanici.ROL,kullanici.AKTIF,kullanici.ID);
                return Ok(new { kullanici.KULLANICIADI,kullanici.SIFRE,token });
            }
            else
            {
                return BadRequest("Kullanıcı Bulunamadı!");
            }
        }
    }
}
