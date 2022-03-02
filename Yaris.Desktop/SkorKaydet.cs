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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaris.Desktop
{
    public partial class SkorKaydet : Form
    {

        public int Skor = 0;

        public SkorKaydet()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var yol = Application.StartupPath;
            string fileName = yol + @"\Skor.txt";

            string writeText = txtKullaniciAdi.Text + " " + lblSkor.Text;

            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Close();

            var kullanici = txtKullaniciAdi.Text;
            var skor = Convert.ToInt32(lblSkor.Text);
            string sonSkorYazisi = SkorDüzenle(fileName, kullanici, skor);

            File.WriteAllText(fileName, sonSkorYazisi);
            MessageBox.Show("Skorunuz kaydedildi.");
            this.Close();
        }

        private void SkorKaydet_Load(object sender, EventArgs e)
        {
            lblSkor.Text = Skor.ToString();
        }

        private string SkorDüzenle(string fileName, string sonKullanici, double sonSkor)
        {
            string result = "";
            var butunSkorlar = File.ReadAllLines(fileName).ToList();

            string tempKullanici = "";
            double tempSkor = 0;

            bool bulunduMu = false;

            for (int i = 0; i < butunSkorlar.Count; i++)
            {
                if (butunSkorlar[i] != "")
                {
                    var kullanici = butunSkorlar[i].Split(' ')[0];
                    var skor = Convert.ToInt32(butunSkorlar[i].Split(' ')[1]);

                    if (skor < sonSkor && !bulunduMu)
                    {
                        tempKullanici = kullanici;
                        tempSkor = skor;
                        butunSkorlar[i] = sonKullanici + " " + sonSkor;
                        bulunduMu = true;
                    }
                    else if (bulunduMu)
                    {
                        butunSkorlar[i] = tempKullanici + " " + tempSkor;
                        tempKullanici = kullanici;
                        tempSkor = skor;
                    }
                }
            }
            if (butunSkorlar.Count != 0)
            {
                butunSkorlar.Add("deneme 20");
                butunSkorlar[butunSkorlar.Count - 1] = tempKullanici + " " + tempSkor;
            }
            else
            {
                butunSkorlar.Add(sonKullanici + " " + sonSkor);
            }
            int count = 0;
            if (butunSkorlar.Count < 5)
                count = butunSkorlar.Count;
            else
                count = 5;
            for (int i = 0; i < count; i++)
            {
                result += butunSkorlar[i] + Environment.NewLine;
            }

            return result;
        }
    }
}
