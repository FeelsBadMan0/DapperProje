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
    public class LogManeger:ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogManeger(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public bool Ekle(string kayitKodu, string controllerAdi, string actionAdi, string ipAdres, DateTime tarih)
        {
            return _logRepository.Ekle(kayitKodu, controllerAdi, actionAdi, ipAdres, tarih);
        }

        public List<Log> Listele()
        {
            return _logRepository.Listele();
        }

        public Log LogGetir(string kayitKodu)
        {
            return _logRepository.LogGetir(kayitKodu);
        }
    }
}
