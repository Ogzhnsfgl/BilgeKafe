﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BilgeKafe.Data;

namespace BilgeKafe.UI
{
    public partial class SiparisForm : Form
    {
        private readonly KafeVeri db;
        private readonly Siparis siparis;
        private readonly BindingList<SiparisDetay> blSiparisDetay;

        public SiparisForm(KafeVeri db,Siparis siparis )
        {
            this.db = db;
            this.siparis = siparis;
            //Binding listi siparis detay listesine bağladık 
            blSiparisDetay = new BindingList<SiparisDetay>(siparis.SiparisDetaylar);
            InitializeComponent();
            UrunleriListele();
            MasaNoyuGuncelle();
            dgwSiparisDetayları.DataSource = blSiparisDetay;
        }

        private void UrunleriListele()
        {
            cboUrun.DataSource = db.Urunler;
        }

        private void MasaNoyuGuncelle()
        {
            Text = $"Masa {siparis.MasaNo}";
            lblMasaNo.Text = $"{siparis.MasaNo:00}";
            
        }

        private void btnDetayEkle_Click(object sender, EventArgs e)
        {
            Urun urun = (Urun) cboUrun.SelectedItem;
            int adet = (int) nudAdet.Value;
            if (urun==null)
            {
                MessageBox.Show("Önce bir ürün seçmelisiniz!");
                return;
            }

            SiparisDetay sd = new SiparisDetay()
            {
                UrunAd = urun.UrunAd,
                Adet = adet,
                BirimFiyat = urun.BirimFiyat
            };
            //bl'ye eklemek hem sipariş detay listesine hem dgw ye ekleyecek!
            blSiparisDetay.Add(sd);

            //todo: Ödeme tutarı güncellenecek!

        }

    }
}
