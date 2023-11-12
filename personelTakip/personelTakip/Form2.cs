using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;


namespace personelTakip
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       
        private void kullanici_goster()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter kullanicilari_goster = new OleDbDataAdapter
                    ("SELECT tcno AS[TC KİMLİK NO], ad AS [ADI], soyad AS[SOYADI], yetki AS[YETKİ], kullaniciadi AS[KULLANICI ADI], parola AS[PAROLA] FROM Kullanicilar ORDER BY ad ASC",baglanti);
                DataSet dsHafiza = new DataSet();
                kullanicilari_goster.Fill(dsHafiza);
                dataGridView1.DataSource = dsHafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
             
            }
        }



        private void personelleri_goster()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter personelleri_goster = new OleDbDataAdapter
                    ("SELECT tcno AS[TC KİMLİK NO], ad AS [ADI], soyad AS[SOYADI], mezuniyet AS[MEZUNİYETİ], dogumtarihi AS[DOĞUM TARİHİ], gorevi AS[GÖREVİ], gorevyeri AS[GÖREV YERİ], maasi AS[MAAŞI] FROM personeller ORDER BY ad ASC", baglanti);
                DataSet dsHafiza = new DataSet();
                personelleri_goster.Fill(dsHafiza);
                dataGridView2.DataSource = dsHafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "SKY Personel Takip Programı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();

            }
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=personel.accdb");
        private void Form2_Load(object sender, EventArgs e)
        {
           pictureBox1.Height= 150;
            pictureBox1.Width = 150;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + ".jpg");
            }
            catch 
            {
              pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\kullaniciresimler\\" + Form1.tcno + "resimyok.jpg");
            }
            //Kullanıcı işlemleri sekmesi
            this.Text = "YÖNETCİ İŞLEMLERİ";
            label10.ForeColor = Color.DarkRed;
            label10.Text = Form1.adi + " " + Form1.soyadi;
            textBox1.MaxLength = 11;
            textBox4.MaxLength = 8;
            toolTip1.SetToolTip(this.textBox1, "TC Kimlik no 11 haneli olmalı!");
            radioButton1.Checked = true;
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox3.CharacterCasing = CharacterCasing.Upper;
            textBox5.MaxLength = 10;
            textBox6.MaxLength = 10;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            kullanici_goster();
            //Personel sekmesinin şlemleri
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Height = 100;
            pictureBox2.Width = 100;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            maskedTextBox1.Mask = "00000000000";
            maskedTextBox2.Mask = "AA??????????????????";
            maskedTextBox3.Mask = "AA??????????????????";
            maskedTextBox4.Mask = "0000";
            maskedTextBox2.Text.ToUpper();
            maskedTextBox3.Text.ToUpper();
            comboBox1.Items.Add("İlköğretim");
            comboBox1.Items.Add("Ortaöğretim");
            comboBox1.Items.Add("Lise");
            comboBox1.Items.Add("Üniversite");
            comboBox2.Items.Add("Yönetici");
            comboBox2.Items.Add("Memur");
            comboBox2.Items.Add("İşci");
            comboBox2.Items.Add("Şoför");
            comboBox3.Items.Add("ARGE");comboBox3.Items.Add("Bilgi İşlem");comboBox3.Items.Add("Muhasebe");
            comboBox3.Items.Add("Üretim");comboBox3.Items.Add("Paketleme");comboBox3.Items.Add("Nakliye");
            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));
            dateTimePicker1.MinDate = new DateTime(yil-50,1,1);
            dateTimePicker1.MaxDate = new DateTime(yil-18,ay,gun);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            radioButton1.Checked = true;


        }

     
    }
}
