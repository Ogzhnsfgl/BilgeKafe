﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKafe.Data
{
    [Table("SiparisDetaylar")]
    public class SiparisDetay
    {
        public int Id { get; set; } 
        [Required,MaxLength(100)]
        public string UrunAd { get; set; }
        public  decimal BirimFiyat { get; set; }
        public  int Adet { get; set; }

        //Get Tutar return edecek.
        public int UrunId { get; set; }
        public virtual Urun Urun { get; set; }

        public int SiparisId { get; set; }
        public virtual Siparis Siparis { get; set; }

        [NotMapped]
        public string TutarTL => $"{Tutar()} ₺";

        public decimal Tutar()
        {
            return BirimFiyat * Adet;
        }
    }
}
