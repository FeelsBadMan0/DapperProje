using BusinessLayer.Services;
using DataAccessLayer.Interfaces;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Manegers
{
    public class CarilerManeger:ICarilerService
    {
        private readonly ICarilerRepository _carilerRepository;

        public CarilerManeger(ICarilerRepository carilerRepository)
        {
            _carilerRepository = carilerRepository;
        }

        public Cariler CariGetir(int id)
        {
            return _carilerRepository.CariGetir(id);
        }

        public bool Ekle(Cariler cari)
        {
            return _carilerRepository.Ekle(cari);
        }

        public bool Guncelle(string adsoyad,string mail, int vergino, int id)
        {
            return _carilerRepository.Guncelle(adsoyad,mail,vergino,id);
        }

        public List<Cariler> Listele()
        {
            return _carilerRepository.Listele();    
        }

        public bool Sil(string kayitKodu)
        {
            return _carilerRepository.Sil(kayitKodu);
        }
    }
}
