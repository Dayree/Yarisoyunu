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
using System.Windows.Forms;
using Yaris.Library.Concrete;
using Yaris.Library.Enum;

namespace Yaris.Desktop
{
    public partial class AnaForm : Form
    {
        private readonly Oyun _oyun;

        public AnaForm()
        {
            InitializeComponent();

            _oyun = new Oyun(f1logoPanel, yarisAlaniPanel);
            _oyun.GecenSureDegisti += Oyun_GecenSureDegisti;
            _oyun.SkorDegisti += Oyun_SkorDegisti;
            _oyun.SkorKaydet += Oyun_SkorKaydet;
        }

        private void AnaForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _oyun.Baslat();
                    break;
                case Keys.Right:
                    _oyun.F1LogoHareketEttir(Yon.Saga);
                    break;
                case Keys.Left:
                    _oyun.F1LogoHareketEttir(Yon.Sola);
                    break;
                case Keys.Space:
                    _oyun.AtesEt();
                    break;
                case Keys.P:
                    _oyun.PauseGame();
                    break;
                case Keys.C:
                    _oyun.ContinueGame();
                    break;
                case Keys.S:
                    Oyun_SkorTablosu();
                    break;
            }
        }

        private void Oyun_GecenSureDegisti(object sender, EventArgs e)
        {
            sureLabel.Text = _oyun.GecenSure.ToString(@"m\:ss");
        }

        private void Oyun_SkorDegisti(object sender, EventArgs e)
        {
            lblSkor.Text = _oyun.Skor.ToString();
        }

        private void Oyun_SkorKaydet(object sender, EventArgs e)
        {
            SkorKaydet skorKaydet = new SkorKaydet();
            skorKaydet.Skor = _oyun.Skor;
            skorKaydet.ShowDialog();
        }
        private void Oyun_SkorTablosu()
        {
            SkorGoster skorGoster = new SkorGoster();
            skorGoster.ShowDialog();
        }
    }
}
