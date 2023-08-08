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
    public class SatisHareketleriManeger:ISatisHareketleriService
    {
        private readonly ISatisHareketleriRepository _satisHareketleriRepository;

        public SatisHareketleriManeger(ISatisHareketleriRepository satisHareketleriRepository)
        {
            _satisHareketleriRepository = satisHareketleriRepository;
        }

        public bool Ekle(SatisHareketleri satis)
        {
            return _satisHareketleriRepository.Ekle(satis);
        }

        public bool Guncelle(SatisHareketleri satis)
        {
            return _satisHareketleriRepository.Guncelle(satis);
        }

        public List<SatisHareketleri> Listele()
        {
            return _satisHareketleriRepository.Listele();
        }

        public SatisHareketleri SatisGetir(int id)
        {
            return _satisHareketleriRepository.SatisGetir(id);
        }
    }
}
