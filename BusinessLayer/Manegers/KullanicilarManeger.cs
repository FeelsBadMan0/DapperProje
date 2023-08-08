using BusinessLayer.Services;
using DataAccessLayer.Interfaces;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Manegers
{
    public class KullanicilarManeger:IKullanicilarService
    {
        private readonly IKullanicilarRepository _kullanicilarRepository;

        public KullanicilarManeger(IKullanicilarRepository kullanicilarRepository)
        {
            _kullanicilarRepository = kullanicilarRepository;
        }

        public bool Ekle(Kullanicilar kullanici)
        {
            return _kullanicilarRepository.Ekle(kullanici);
        }

        public bool Guncelle(Kullanicilar kullanici)
        {
            return _kullanicilarRepository.Guncelle(kullanici);
        }

        public Kullanicilar KullaniciGetir(int id)
        {
            return _kullanicilarRepository.KullaniciGetir(id);
        }

        public Kullanicilar KullaniciKontrol(string kullaniciadi, string sifre)
        {
            return _kullanicilarRepository.KullaniciKontrol(kullaniciadi,sifre);
        }

        public List<Kullanicilar> Listele()
        {
            return _kullanicilarRepository.Listele();
        }

        public Kullanicilar RolGetir(int id, string rol, short aktif)
        {
            return _kullanicilarRepository.RolGetir(id,rol,aktif);
        }

        public Kullanicilar RolGetirApi(string kullaniciAdi)
        {
            return _kullanicilarRepository.RolGetirApi(kullaniciAdi);
        }

        public bool Sil(string kayitkodu)
        {
            return _kullanicilarRepository.Sil(kayitkodu);
        }
    }
}
