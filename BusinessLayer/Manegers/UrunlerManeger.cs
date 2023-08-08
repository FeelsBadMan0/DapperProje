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
    public class UrunlerManeger:IUrunlerService
    {
        private readonly IUrunlerRespository _urunlerRepository;

        public UrunlerManeger(IUrunlerRespository urunlerRepository)
        {
            _urunlerRepository = urunlerRepository;
        }

        public bool Ekle(Urunler urun)
        {
           return _urunlerRepository.Ekle(urun);
        }

        public bool EkleApi(string kayitKodu, string urun, string kategori, int stok, string gorsel, short aktif)
        {
            return _urunlerRepository.EkleApi(kayitKodu,urun,kategori,stok,gorsel, aktif);
        }

        public bool Guncelle(int id, string urun, int stok, string kategori)
        {
            return _urunlerRepository.Guncelle(id,urun,stok,kategori);
        }

        public bool GuncelleApi(string urun, string kategori, int stok, string gorsel, int id)
        {
            return _urunlerRepository.GuncelleApi(urun, kategori, stok, gorsel,id);
        }

        public List<Urunler> Listele()
        {
            return _urunlerRepository.Listele();
        }

        public bool Sil(string kayitKodu)
        {
            return _urunlerRepository.Sil(kayitKodu);
        }

        public Urunler UrunGetir(int id)
        {
            return _urunlerRepository.UrunGetir(id);
        }
    }
}
