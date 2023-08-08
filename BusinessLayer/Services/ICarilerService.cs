using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ICarilerService
    {
        List<Cariler> Listele();
        Cariler CariGetir(int id);
        bool Ekle(Cariler cari);
        bool Guncelle(string adsoyad, string mail, int vergino, int id);
        bool Sil(string kayitKodu);
    }
}
