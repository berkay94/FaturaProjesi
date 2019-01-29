using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatura
{
    public class SecilenUrun
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public decimal Miktar { get; set; }
        public decimal UrunFiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public decimal KDV { get; set; }
    }
}
