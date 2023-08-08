using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IUrunlerService
    {
        List<Urunler> Listele();
        Urunler UrunGetir(int id);
        bool Ekle(Urunler urun);
        bool Guncelle(int id, string urun, int stok, string kategori);
        bool Sil(string kayitKodu);
        bool EkleApi(string kayitKodu, string urun, string kategori, int stok, string gorsel, short aktif);
        bool GuncelleApi(string urun, string kategori, int stok, string gorsel,int id);
    }
}
