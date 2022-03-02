/**
 SAKARYA ÜNİVERSİTESİ
 BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
 BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
 NESNEYE DAYALI PROGRAMLAMA DERSİ
 2020-2021 BAHAR DÖNEMİ

 ÖDEV NUMARASI..........:Proje Ödevi
 ÖĞRENCİ ADI............:Ayşe Tuba Kahraman
 ÖĞRENCİ NUMARASI.......:b191200025
 DERSİN ALINDIĞI GRUP...:1.Öğretim A
**/

using System.Drawing;
using Yaris.Library.Abstract;

namespace Yaris.Library.Concrete
{
    internal class F1Car : Cisim
    {
        public F1Car(Size hareketAlaniBoyutlari, int namluOrtasiX) : base(hareketAlaniBoyutlari)
        {
            BaslangicKonumunuAyarla(namluOrtasiX);
            HareketMesafesi = (int)(Height * 1.5);
        }

        private void BaslangicKonumunuAyarla(int namluOrtasiX)
        {
            Bottom = HareketAlaniBoyutlari.Height;
            Center = namluOrtasiX;
        }
    }
}
