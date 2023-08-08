using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ISatisHareketleriService
    {
        List<SatisHareketleri> Listele();
        SatisHareketleri SatisGetir(int id);
        bool Ekle(SatisHareketleri satis);
        bool Guncelle(SatisHareketleri satis);
    }
}
