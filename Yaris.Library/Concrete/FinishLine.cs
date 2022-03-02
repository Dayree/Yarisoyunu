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

using System;
using System.Collections.Generic;
using System.Drawing;
using Yaris.Library.Abstract;

namespace Yaris.Library.Concrete
{
    internal class FinishLine : Cisim
    {
        private static readonly Random Random = new Random();

        public FinishLine(Size hareketAlaniBoyutlari) : base(hareketAlaniBoyutlari)
        {
            HareketMesafesi = (int)(Height * .1);
            Left = Random.Next(hareketAlaniBoyutlari.Width - Width + 1);
        }

        public F1Car VurulduMu(List<F1Car> f1Cars)
        {
            foreach (var f1Car in f1Cars)
            {
                var vurulduMu = f1Car.Top < Bottom && f1Car.Right > Left && f1Car.Left < Right;
                if (vurulduMu) return f1Car;
            }

            return null;
        }
    }
}
