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
using System.Windows.Forms;
using Yaris.Library.Enum;
using Yaris.Library.Interface;

namespace Yaris.Library.Concrete
{
    public class Oyun : IOyun
    {
        #region Alanlar

        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };
        private readonly Timer _hareketTimer = new Timer { Interval = 100 };
        private readonly Timer _finishLineOlusturmaTimer = new Timer { Interval = 2000 };
        private TimeSpan _gecenSure;
        private readonly Panel _f1logoPanel;
        private readonly Panel _yarisAlaniPanel;
        private F1Logo _f1logo;
        private readonly List<F1Car> _F1Cars = new List<F1Car>();
        private readonly List<FinishLine> _finishLines = new List<FinishLine>();
        private int _skor;
        #endregion

        #region Olaylar

        public event EventHandler GecenSureDegisti;
        public event EventHandler SkorDegisti;
        public event EventHandler SkorKaydet;

        #endregion

        #region Özellikler

        public bool DevamEdiyorMu { get; private set; }

        public TimeSpan GecenSure
        {
            get => _gecenSure;
            private set
            {
                _gecenSure = value;

                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }

        public int Skor
        {
            get => _skor;
            private set
            {
                _skor = value;
                SkorDegisti?.Invoke(this, EventArgs.Empty);
                if (_skor != 0 && _hareketTimer.Interval != 0 && _hareketTimer.Interval > 5)
                {
                    int results = _hareketTimer.Interval - (_hareketTimer.Interval * 5 / 100);
                    _hareketTimer.Interval = results;
                }
                if (_skor != 0 && _finishLineOlusturmaTimer.Interval != 0 && _finishLineOlusturmaTimer.Interval > 25)
                {
                    int results = _finishLineOlusturmaTimer.Interval - (_finishLineOlusturmaTimer.Interval * 5 / 100);
                    _finishLineOlusturmaTimer.Interval = results;
                }
            }
        }

        #endregion

        #region Metotlar

        public Oyun(Panel f1LogoPanel, Panel yarisAlaniPanel)
        {
            _f1logoPanel = f1LogoPanel;
            _yarisAlaniPanel = yarisAlaniPanel;

            _gecenSureTimer.Tick += GecenSureTimer_Tick;
            _hareketTimer.Tick += HareketTimer_Tick;
            _finishLineOlusturmaTimer.Tick += FinishLineOlusturmaTimer_Tick;
        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }

        private void HareketTimer_Tick(object sender, EventArgs e)
        {
            F1CarsHareketEttir();
            FinishLineHareketEttir();
            VurulanFinishLineCikar();
        }

        private void VurulanFinishLineCikar()
        {
            for (var i = _finishLines.Count - 1; i >= 0; i--)
            {
                var finishLine = _finishLines[i];

                var vuranF1Car = finishLine.VurulduMu(_F1Cars);
                if (vuranF1Car is null) continue;

                _finishLines.Remove(finishLine);
                _F1Cars.Remove(vuranF1Car);
                _yarisAlaniPanel.Controls.Remove(finishLine);
                _yarisAlaniPanel.Controls.Remove(vuranF1Car);
                Skor += 7;
            }
        }

        private void FinishLineHareketEttir()
        {
            foreach (var finishLine in _finishLines)
            {
                var carptiMi = finishLine.HareketEttir(Yon.Asagi);
                if (!carptiMi) continue;

                Bitir();
                break;
            }
        }

        private void FinishLineOlusturmaTimer_Tick(object sender, EventArgs e)
        {
            FinishLineOlustur();
        }

        private void F1CarsHareketEttir()
        {
            for (int i = _F1Cars.Count - 1; i >= 0; i--)
            {
                var f1car = _F1Cars[i];
                var carptiMi = f1car.HareketEttir(Yon.Yukari);
                if (carptiMi)
                {
                    _F1Cars.Remove(f1car);
                    _yarisAlaniPanel.Controls.Remove(f1car);
                }
            }
        }

        public void Baslat()
        {
            if (DevamEdiyorMu) return;

            DevamEdiyorMu = true;

            ZamanlayicilariBaslat();

            SkorSureTemizle();
            FinishLineTemizle();

            F1LogoOlustur();
            FinishLineOlustur();
        }

        private void FinishLineOlustur()
        {
            var finishLine = new FinishLine(_yarisAlaniPanel.Size);
            _finishLines.Add(finishLine);
            _yarisAlaniPanel.Controls.Add(finishLine);
        }

        private void FinishLineTemizle()
        {
            _finishLines.Clear();
            _yarisAlaniPanel.Controls.Clear();
        }

        private void SkorSureTemizle()
        {
            Skor = 0;
            GecenSure = new TimeSpan();
        }

        private void ZamanlayicilariBaslat()
        {
            _gecenSureTimer.Interval = 1000;
            _hareketTimer.Interval = 100;
            _finishLineOlusturmaTimer.Interval = 2000;

            _gecenSureTimer.Start();
            _hareketTimer.Start();
            _finishLineOlusturmaTimer.Start();
        }

        private void F1LogoOlustur()
        {
            if (_f1logoPanel.Controls.Count == 0)
            {
                _f1logo = new F1Logo(_f1logoPanel.Width, _f1logoPanel.Size);
                _f1logoPanel.Controls.Add(_f1logo);
            }
        }

        private void Bitir()
        {
            if (!DevamEdiyorMu) return;

            DevamEdiyorMu = false;
            ZamanlayicilariDurdur();
            SkorKaydet?.Invoke(this, EventArgs.Empty);
        }

        private void ZamanlayicilariDurdur()
        {
            _gecenSureTimer.Stop();
            _hareketTimer.Stop();
            _finishLineOlusturmaTimer.Stop();
        }

        public void AtesEt()
        {
            if (!DevamEdiyorMu) return;

            var f1car = new F1Car(_yarisAlaniPanel.Size, _f1logo.Center);
            _F1Cars.Add(f1car);
            _yarisAlaniPanel.Controls.Add(f1car);
        }

        public void F1LogoHareketEttir(Yon yon)
        {
            if (!DevamEdiyorMu) return;

            _f1logo.HareketEttir(yon);
        }

        public void PauseGame()
        {
            _hareketTimer.Stop();
            _gecenSureTimer.Stop();
            _finishLineOlusturmaTimer.Stop();
        }

        public void ContinueGame()
        {
            _hareketTimer.Start();
            _gecenSureTimer.Start();
            _finishLineOlusturmaTimer.Start();
        }

        #endregion
    }
}
