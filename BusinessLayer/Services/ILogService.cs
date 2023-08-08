using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface ILogService
    {
        List<Log> Listele();
        Log LogGetir(string kayitKodu);
        bool Ekle(string kayitKodu, string controllerAdi, string actionAdi, string ipAdres, DateTime tarih);
    }
}
