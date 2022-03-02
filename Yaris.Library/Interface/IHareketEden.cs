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
using Yaris.Library.Enum;

namespace Yaris.Library.Interface
{
    internal interface IHareketEden
    {
        Size HareketAlaniBoyutlari { get; }

        int HareketMesafesi { get; }
        
        /// <summary>
        /// Cismi istenilen yönde hareket ettirir
        /// </summary>
        /// <param name="yon">Hangi yöne hareket edileceği</param>
        /// <returns>Cisim duvara çaparsa true döndürür.</returns>
        bool HareketEttir(Yon yon);
    }
}
