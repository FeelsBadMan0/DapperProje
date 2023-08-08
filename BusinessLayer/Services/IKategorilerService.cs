using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IKategorilerService
    {
        List<Kategoriler> Listele();
        Kategoriler KategoriGetir(int id);
        bool Ekle(string kategori, string kayitkodu, short aktif);
        bool Guncelle(string kategori,int id);
        bool Sil(string kayitkodu);
        List<Kategoriler> KategoriListele();
    }
}
