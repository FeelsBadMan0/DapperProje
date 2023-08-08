using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public  interface IKullanicilarService
    {
        List<Kullanicilar> Listele();
        Kullanicilar KullaniciGetir(int id);
        bool Ekle(Kullanicilar kullanici);
        bool Sil(string kayitkodu);
        bool Guncelle(Kullanicilar kullanici);
        Kullanicilar RolGetir(int id, string rol, short aktif);
        Kullanicilar KullaniciKontrol(string kullaniciadi, string sifre);
        Kullanicilar RolGetirApi(string kullaniciAdi);
    }
}
