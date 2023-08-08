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
    public class KategorilerManeger:IKategorilerService
    {
        private readonly IKategorilerRepository _kategorilerrepository;

        public KategorilerManeger(IKategorilerRepository kategorilerrepository)
        {
            _kategorilerrepository = kategorilerrepository;
        }

        public bool Ekle(string kategori,string kayitkodu,short aktif)
        {
           return _kategorilerrepository.Ekle(kategori, kayitkodu, aktif);
        }

        public bool Guncelle(string kategori, int id)
        {
           return _kategorilerrepository.Guncelle(kategori,id);
        }

        public Kategoriler KategoriGetir(int id)
        {
            return _kategorilerrepository.KategoriGetir(id);
        }

        public List<Kategoriler> KategoriListele()
        {
            return _kategorilerrepository.KategoriListele();
        }

        public List<Kategoriler> Listele()
        {
           return _kategorilerrepository.Listele();
        }

        public bool Sil(string kayitkodu)
        {
            return _kategorilerrepository.Sil(kayitkodu);   
        }
    }
}
