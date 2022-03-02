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
using Yaris.Library.Enum;

namespace Yaris.Library.Interface
{
    internal interface IOyun
    {
        event EventHandler GecenSureDegisti;
        event EventHandler SkorDegisti;
        event EventHandler SkorKaydet;

        bool DevamEdiyorMu { get; }
        TimeSpan GecenSure { get; }
        int Skor { get; }

        void Baslat();
        void AtesEt();
        void F1LogoHareketEttir(Yon yon);
        void PauseGame();
        void ContinueGame();
    }
}
