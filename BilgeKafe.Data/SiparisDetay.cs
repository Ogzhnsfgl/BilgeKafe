using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKafe.Data
{
    public class SiparisDetay
    {
        public string UrunAd { get; set; }
        public  decimal BirimFiyat { get; set; }
        public  int Adet { get; set; }

        //Get Tutar return edecek.
        public string TutarTL => $"{Tutar()} ₺";

        public decimal Tutar()
        {
            return BirimFiyat * Adet;
        }
    }
}
