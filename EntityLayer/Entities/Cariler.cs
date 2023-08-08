using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Cariler
    {
        public int ID { get; set; }
        public string ADSOYAD { get; set; }
        public string MAIL { get; set; }
        public string KAYITKODU { get; set; }
        public DateTime KAYITTARIHI { get; set; }
        public int VERGINO { get; set; }
        public short AKTIF { get; set; }

        public List<SatisHareketleri> SatisHareketleris { get; set; }
    }
}
