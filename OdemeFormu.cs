using Arac_Kayit_Program.Entities;
using OtoTakip.Business.Abstract;
using OtoTakip.Business.DependencyResolvers.Ninject;
using OtoTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kayit_Program
{
    public partial class OdemeFormu : Form
    {
        public OdemeFormu()
        {
            InitializeComponent();
            _araclistesiService = InstanceFactory.GetInstance<IAracListesiService>();
            _kategorilerService = InstanceFactory.GetInstance<IKategorilerService>();
            _musterilerService = InstanceFactory.GetInstance<IMusterilerService>();
            _kasaService = InstanceFactory.GetInstance<IKasaService>();
        }

        private IKasaService _kasaService;
        private IAracListesiService _araclistesiService;
        private IKategorilerService _kategorilerService;
        private IMusterilerService _musterilerService;



        private void OdemeFormu_Load(object sender, EventArgs e)
        {
            Form1 btn = Form1.Olustur;


            if (_kasaService.GetKasaBillById(Form1.seciliKasaDetayId) != null)
            {
                txtAracno.Text = Convert.ToString(Form1.HesapAraciId);
                txtMusterino.Text = Convert.ToString(Form1.HesapMusteriId);
                txtToplamBorc.Text = Convert.ToString(Form1.tumBorc);
                txtOdenenMiktar.Text = Convert.ToString(Form1.OdemeMiktari);
                if (Form1.IndirimMiktari > 0)
                {
                    checkIndirim.Checked = true;
                    txtIndirim.Text = Convert.ToString(Form1.IndirimMiktari);
                }
                txtKalan.Text = Convert.ToString(Form1.Kalan);

                dgwAracListesi.DataSource = _kasaService.GetKasaBillById(Form1.seciliKasaDetayId);
            }
            //else
            //{
            //    dgwAracListesi.DataSource = _kasaService.GetALLBills();
            //}




           else if (Form1.CarIsRent==true &&Form1.CarIsReserved==false)
            {


                if (_kasaService.GetKasaBillById(Form1.seciliKasaDetayId)!=null)
                {
                    txtAracno.Text = Convert.ToString(Form1.HesapAraciId);
                    txtMusterino.Text = Convert.ToString(Form1.HesapMusteriId);
                    txtToplamBorc.Text = Convert.ToString(Form1.tumBorc);
                    txtOdenenMiktar.Text = Convert.ToString(Form1.OdemeMiktari);
                    if (Form1.IndirimMiktari>0)
                    {
                        checkIndirim.Checked = true;
                        txtIndirim.Text = Convert.ToString(Form1.IndirimMiktari);
                    }
                    txtKalan.Text = Convert.ToString(Form1.Kalan);

                    dgwAracListesi.DataSource = _kasaService.GetKasaBillById(Form1.seciliKasaDetayId);
                }
                else 
                {
                    dgwAracListesi.DataSource = _kasaService.GetALLBills();
                }

                txtToplamBorc.Text = Convert.ToString(Form1.tumBorc);
                txtOdenenMiktar.Text = Convert.ToString(Form1.tumBorc);


                //decimal hesap;
                //int gun;
                //int gunfark;

                if (checkIndirim.Checked == true)
                {
                    txtIndirim.Visible = true;
                    
                    Indirim = txtIndirim.Text;
                    kalan = Convert.ToDecimal(Indirim);
                }


                DateTime dt1 = new DateTime();
                //  DateTime dt2 = new DateTime();
                DateTime dt3 = DateTime.Today;
                TimeSpan diff = dt1.Subtract(DateTime.Now);

                // label1.Text = string.Format("{0:00}:{1:00}:{2:00}", diff.Days, diff.Hours, diff.Minutes);

                //using (ARABALARContext contex= new ARABALARContext())
                //{
                //  AracListesi aracim = contex.AracListesis.SingleOrDefault(o => o.Id == Convert.ToInt32(dgwAracListesi2.CurrentRow.Cells[1].Value;               

                //}



            }
            else if (Form1.CarIsRent == false && Form1.CarIsReserved == true)
            {

                if (_kasaService.GetKasaBillById(Form1.seciliKasaDetayId) != null)
                {
                    dgwAracListesi.DataSource = _kasaService.GetKasaBillById(Form1.seciliKasaDetayId);
                }
                else
                {
                    dgwAracListesi.DataSource = _kasaService.GetALLBills();
                }

                txtToplamBorc.Text = Convert.ToString(Form1.tumBorc);
                txtOdenenMiktar.Text = Convert.ToString(Form1.tumBorc);


                //decimal hesap;
                //int gun;
                //int gunfark;

                if (checkIndirim.Checked == true)
                {
                    txtIndirim.Visible = true;
                    Indirim = txtIndirim.Text;
                    kalan = Convert.ToDecimal(Indirim);
                }


                DateTime dt1 = new DateTime();
                //  DateTime dt2 = new DateTime();
                DateTime dt3 = DateTime.Today;
                TimeSpan diff = dt1.Subtract(DateTime.Now);

                // label1.Text = string.Format("{0:00}:{1:00}:{2:00}", diff.Days, diff.Hours, diff.Minutes);

                //using (ARABALARContext contex= new ARABALARContext())
                //{
                //  AracListesi aracim = contex.AracListesis.SingleOrDefault(o => o.Id == Convert.ToInt32(dgwAracListesi2.CurrentRow.Cells[1].Value;               

                //}




                //MessageBox.Show("LÜTFEN KİRALANMIŞ ARAÇ SEÇİNİZ !!!!");
                //Form1 frm = new Form1();
                //this.Hide();
                //frm.ShowDialog();

            }
            else
            {
                dgwAracListesi.DataSource = _kasaService.GetLastTenBills();
            }

          
        }


        public static decimal  kalan;
        public static decimal odenenMiktar;
        public static string aciklamaMoney;
        public static string odemeTipi;
        public static string Indirim;



        private void label4_Click(object sender, EventArgs e)
        {
            dgwAracListesi.DataSource = _kasaService.GetKasaBillByCarIdAndCustomerId(Form1.HesapAraciId, Form1.HesapMusteriId);


            if (txtIndirim.Text == null || txtIndirim.Text == "")
            {
                txtIndirim.Text = "0";
                //kalan = Convert.ToDecimal(txtToplamBorc.Text) - Convert.ToDecimal(txtOdenenMiktar.Text) - Convert.ToDecimal(txtIndirim.Text);
            }

            decimal TumBorcu = Convert.ToDecimal(txtToplamBorc.Text);

            odenenMiktar = Convert.ToDecimal(txtOdenenMiktar.Text);

            decimal fark = TumBorcu - odenenMiktar;
            decimal indirim = Convert.ToDecimal(txtIndirim.Text);

            if (TumBorcu >= odenenMiktar && fark>=indirim)
            {
                txtKalan.Text = Convert.ToString(fark - indirim);
            }

            if (fark < 0)
            {
                MessageBox.Show("Odenen Ücret TümBorçdan Fazla  olamaz!");
                txtOdenenMiktar.Text = "0";
                txtKalan.Text = TumBorcu.ToString();
                txtIndirim.Text = "0";

            }
            if (fark<indirim)
            {
                MessageBox.Show(" indirim  Odenen Ücret ten  fazla  olamaz!");
                txtOdenenMiktar.Text = "0";
                txtKalan.Text = TumBorcu.ToString();
                txtIndirim.Text = "0";
            }
            kalan = TumBorcu-odenenMiktar-indirim;
            kalan = Convert.ToDecimal(txtKalan.Text);
        }

        private void txtIndirim_TextChanged(object sender, EventArgs e)
        {


            dgwAracListesi.DataSource = _kasaService.GetKasaBillByCarIdAndCustomerId(Form1.HesapAraciId, Form1.HesapMusteriId);


            if (txtIndirim.Text == null || txtIndirim.Text == "")
            {
                txtIndirim.Text = "0";
                //kalan = Convert.ToDecimal(txtToplamBorc.Text) - Convert.ToDecimal(txtOdenenMiktar.Text) - Convert.ToDecimal(txtIndirim.Text);
            }

            decimal TumBorcu = Convert.ToDecimal(txtToplamBorc.Text);

            odenenMiktar = Convert.ToDecimal(txtOdenenMiktar.Text);

            decimal fark = TumBorcu - odenenMiktar;
            decimal indirim = Convert.ToDecimal(txtIndirim.Text);
            txtKalan.Text = Convert.ToString(fark - indirim);
            //if (TumBorcu >= odenenMiktar && fark >= indirim)
            //{
            //    txtKalan.Text = Convert.ToString(fark - indirim);
            //}

            //if (fark < 0)
            //{
            //    MessageBox.Show("Odenen Ücret TümBorçdan Fazla  olamaz!");
            //    txtOdenenMiktar.Text = "0";
            //    txtKalan.Text = TumBorcu.ToString();
            //    txtIndirim.Text = "0";

            //}
            //if (fark < indirim)
            //{
            //    MessageBox.Show(" indirim  Odenen Ücret ten  fazla  olamaz!");
            //    txtOdenenMiktar.Text = "0";
            //    txtKalan.Text = TumBorcu.ToString();
            //    txtIndirim.Text = "0";
            //}
            //kalan = TumBorcu - odenenMiktar - indirim;
            //kalan = Convert.ToDecimal(txtKalan.Text);


          



            //  if (txtIndirim.Text == null || txtIndirim.Text == "")
            //  {
            //      txtIndirim.Text = "0";
            //      //kalan = Convert.ToDecimal(txtToplamBorc.Text) - Convert.ToDecimal(txtOdenenMiktar.Text) - Convert.ToDecimal(txtIndirim.Text);
            //  }

            //   if(Convert.ToDecimal(txtIndirim.Text)>0)
            //  {

            //      if (Convert.ToDecimal(txtKalan.Text)< Convert.ToDecimal(txtIndirim.Text))
            //      {
            //          MessageBox.Show("indirim kalan ucreti  geçemez !!");
            //          txtIndirim.Text = "0";
            //          kalan = Convert.ToDecimal(txtToplamBorc.Text) - Convert.ToDecimal(txtOdenenMiktar.Text);
            //          txtKalan.Text = kalan.ToString();
            //      }
            //      else
            //      {
            //          kalan = Convert.ToDecimal(txtToplamBorc.Text) - Convert.ToDecimal(txtOdenenMiktar.Text) - Convert.ToDecimal(txtIndirim.Text);

            //      }

            //  }
            //// kalan = Convert.ToDecimal(txtToplamBorc.Text) - Convert.ToDecimal(txtOdenenMiktar.Text) - Convert.ToDecimal(txtIndirim.Text);
            //  txtKalan.Text = kalan.ToString();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public int GunFarkikBul(DateTime dt1, DateTime dt2)

        {

            TimeSpan zaman = new TimeSpan(); // zaman farkını bulmak adına kullanılacak olan nesne

            zaman = dt1 - dt2;//metoda gelen 2 tarih arasındaki fark

            return Math.Abs(zaman.Days); // 2 tarih arasındaki farkın kaç gün olduğu döndürülüyor.

        }

        private void txtOdenenMiktar_TextChanged(object sender, EventArgs e)
        {
            dgwAracListesi.DataSource = _kasaService.GetKasaBillByCarIdAndCustomerId(Form1.HesapAraciId, Form1.HesapMusteriId);


            if (txtOdenenMiktar.Text=="" || txtOdenenMiktar.Text ==null)
            {
                txtOdenenMiktar.Text = "0";
            }

            decimal TumBorcu = Convert.ToDecimal(txtToplamBorc.Text);

            odenenMiktar = Convert.ToDecimal(txtOdenenMiktar.Text);

            decimal fark = TumBorcu - odenenMiktar;
            decimal indirim = Convert.ToDecimal(txtIndirim.Text);
            txtKalan.Text = Convert.ToString(fark - indirim);

            //decimal TumBorcu = Convert.ToDecimal(txtToplamBorc.Text);

            //odenenMiktar = Convert.ToDecimal(txtOdenenMiktar.Text);

            //decimal fark = TumBorcu - odenenMiktar;

            //if (TumBorcu > odenenMiktar)
            //{
            //    txtKalan.Text = Convert.ToString(fark - Convert.ToDecimal(txtIndirim.Text));
            //}

            //if (fark<0)
            //   {
            //    MessageBox.Show("Odenen Ücret TümBorçdan Fazla  olamaz!");
            //    txtOdenenMiktar.Text = "0";
            //    txtKalan.Text = TumBorcu.ToString();

            //   }

            //  kalan = Convert.ToDecimal(txtKalan.Text);
        }

        private void checkIndirim_Click(object sender, EventArgs e)
        {
            if (checkIndirim.Checked == true)
            {
                txtIndirim.Visible = true;
                Indirim = txtIndirim.Text;
                // kalan =kalan- Convert.ToDecimal(Indirim);
            }
            else
            {
                txtIndirim.Visible = false;
                txtIndirim.Text = "0";
            }
        }

        private void txtIndirim_Leave(object sender, EventArgs e)
        {
            decimal TumBorcu = Convert.ToDecimal(txtToplamBorc.Text);
            decimal indirim = Convert.ToDecimal(txtIndirim.Text);
             decimal fark = TumBorcu - odenenMiktar;

            txtKalan.Text = Convert.ToString(fark - indirim);
            if ((TumBorcu >= odenenMiktar && fark >= indirim))
            {
                txtKalan.Text = Convert.ToString(fark - indirim);
            }

           else if ((TumBorcu >= odenenMiktar && fark < indirim) ||Convert.ToDecimal(txtKalan.Text) < 0)
            {
                MessageBox.Show("KALAN  ÜCRET  -   OLAMAZ !!");
                txtOdenenMiktar.Text = "0";
                txtKalan.Text = TumBorcu.ToString();
                txtIndirim.Text = "0";

            }
            //odenenMiktar = Convert.ToDecimal(txtOdenenMiktar.Text);
            //kalan = Convert.ToDecimal(txtKalan.Text);
        }

        private void txtKalan_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkboksKart_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chkboksNakit_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkboksNakit.Checked)
            {
                checkboksKart.CheckState = CheckState.Unchecked;
            }
            else if (chkboksNakit.CheckState==CheckState.Unchecked) 
            {
                checkboksKart.CheckState = CheckState.Checked;
            }
        }

        private void checkboksKart_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkboksKart.Checked)
            {
                chkboksNakit.CheckState = CheckState.Unchecked;
            }
            else if (checkboksKart.CheckState == CheckState.Unchecked)
            {
                chkboksNakit.CheckState = CheckState.Checked;
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Form1 frm = Form1.Olustur;
            this.Hide();
            Form1.Olustur.Show();
        }


        private void btnOde_Click(object sender, EventArgs e)
        {
            
            bool sonucDigerIslem = false;


            decimal TumBorcu = Convert.ToDecimal(txtToplamBorc.Text);

            decimal odeme = Convert.ToDecimal(txtOdenenMiktar.Text);


            aciklamaMoney = Convert.ToString(txtAciklama.Text);

            kalan = TumBorcu - odenenMiktar;



            if (checkIndirim.Checked == true)
            {

                if (kalan < Convert.ToDecimal(txtIndirim.Text))
                {
                    MessageBox.Show(" indirim  Odenen Ücret ten  fazla  olamaz!");
                    txtOdenenMiktar.Text = "0";
                    txtKalan.Text = TumBorcu.ToString();
                    txtIndirim.Text = "0";
                }
                else
                {
                    txtIndirim.Visible = true;
                    Indirim = txtIndirim.Text;
                    kalan = kalan - Convert.ToDecimal(Indirim);
                }
              
            }
            if (checkboksKart.Checked == true)
            {
                odemeTipi = "Kartla";
            }
            else if (chkboksNakit.Checked == true)
            {
                odemeTipi = "Nakit";
            }
           
            else if(rdbDierKasaIslem.Checked == true)
            {
                sonucDigerIslem = true;
            }

            Indirim = txtIndirim.Text;
            aciklamaMoney = txtAciklama.Text;

            odenenMiktar =Convert.ToDecimal (txtOdenenMiktar.Text);
            decimal kal = kalan;


          Musteriler musterim=  _musterilerService.GetMusteriById(Form1.HesapMusteriId);


            Form1 frm = Form1.Olustur;
           
                

            if (rdbDierKasaIslem.Checked == true)
            {
                sonucDigerIslem = true;



                try
                {
                    _kasaService.Add(new Kasa
                    {
                        MusteriId =Convert.ToInt32(txtMusterino.Text),
                        AracNo = Convert.ToInt32(txtAracno.Text),
                        BirimFiyat =0,
                        TumBorc =Convert.ToDecimal(txtToplamBorc.Text),
                        IndirimMiktari = Convert.ToDecimal(txtIndirim.Text),
                        OdemeMiktari = odeme,
                        KalanUcret = kalan,
                        OdemeTipi = odemeTipi,
                        OdemeTarihi = DateTime.Now,//+ user ıd !!!!!!!!!!!!!
                        DierKasaIslemi = true,
                        Aciklama = txtAciklama.Text,
                        IsActive = true

                    }

                    );
                    MessageBox.Show("EKLEME İŞLEMİ  BAŞARILI  !!!!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
            else //if(rdbDierKasaIslem.Checked==false )
            {
                try
                {
                    _kasaService.Add(new Kasa
                    {
                        MusteriId = Form1.HesapMusteriId,
                        AracNo = Form1.HesapAraciId,
                        BirimFiyat = Form1.BirimFiyat,
                        TumBorc = Form1.tumBorc,
                        IndirimMiktari = Convert.ToDecimal(Indirim),
                        OdemeMiktari = odeme,
                        KalanUcret = kalan,
                        OdemeTipi = odemeTipi,
                        OdemeTarihi = DateTime.Now,//+ userıd
                        DierKasaIslemi = sonucDigerIslem,
                        Aciklama = txtAciklama.Text,
                        IsActive = true

                    }

                    );//????????????????????????????????????????????????????????????? aşşası neden?

                   // _araclistesiService.Update(new AracListesi
                   // {
                   //     Id = Form1.HesapAraciId,

                   //     KategoriId = Form1.aracTipim,
                   //     Marka = Form1.markam,
                   //     Model = Form1.modelim,
                   //     Yil = Convert.ToInt32(Form1.yilim),
                   //     BirimFiat = Convert.ToDecimal(Form1.birimFiyatım),
                   //     Plaka = Form1.plakam,

                   //     KiralamaTarihi = Form1.kiraTarihim,
                   //     KiralamaBitisTarihi = Form1.kiraBitisTarihim,
                   //     SonMusteryId = Form1.SonMusteryIdm,
                   //     Aciklama = Form1.Aciklamam,
                   //     IsRent = false,
                   //     IsActive = true

                   // }

                   //);

                   // _musterilerService.Update(new Musteriler

                   // {
                   //     Id = musterim.Id,
                   //     AracId = musterim.AracId,
                   //     Ad = musterim.Ad,
                   //     Soyad = musterim.Soyad,
                   //     TCNo = Convert.ToInt32(musterim.TCNo),
                   //     Adres = musterim.Adres,
                   //     Telefon = Convert.ToInt32(musterim.Telefon),
                   //     KiralamaTarihi = Convert.ToDateTime("2000/01/01 00:00"),
                   //     KiralamaBitisTarihi = Form1.kiraBitisTarihim,
                   //     Aciklama = musterim.Aciklama,
                   //     IsaActive = true

                   // }
                   // );


                    MessageBox.Show("KASA  EKLEME İŞLEMİ  BAŞARILI  !!!!");
                }

                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            AracListesi arac = _araclistesiService.GetCarById(Form1.HesapAraciId);

            Musteriler activeMusteri = _musterilerService.GetMusteriById(Form1.HesapMusteriId);

            Musteriler musteriler = _musterilerService.GetLastCustomerByCarId(Form1.HesapAraciId);

           // _kasaService.GetCountByCustomerId(musterim.Id);

              if (rdbDierKasaIslem.Checked == false && activeMusteri.KiralamaBitisTarihi > DateTime.Now && arac.IsActive == true && kalan==0)
            {
                DialogResult sonuc = new DialogResult();
              sonuc=  MessageBox.Show("ARAC ÜCRETİ  ÖDENDİ ARAÇ VE MÜŞTERİ BOŞA ÇIKSINMI ??","UYARI !!! ",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (sonuc==DialogResult.Yes)
                {
                    try
                    {
                        if (activeMusteri.KiralamaBitisTarihi > DateTime.Now && arac.IsActive == true)
                        {

                            _musterilerService.Update(new Musteriler

                            {
                                Id =activeMusteri.Id,
                                AracId = arac.Id,
                                Ad = activeMusteri.Ad,
                                Soyad = activeMusteri.Soyad,
                                TCNo = activeMusteri.TCNo,
                                DogumTarihi = activeMusteri.DogumTarihi,
                                KiraTipi = activeMusteri.KiraTipi,
                                Adres = activeMusteri.Adres,

                                Telefon = activeMusteri.Telefon,
                                KiralamaTarihi = activeMusteri.KiralamaTarihi,
                                KiralamaBitisTarihi = activeMusteri.KiralamaBitisTarihi,
                                Aciklama = txtAciklama.Text + "--MÜŞTERİ (kasa tarafından)SİLİNDİ " + "->" + Convert.ToString(DateTime.Now),
                                IsaActive = false
                            }
                          );

                            _araclistesiService.Update(new AracListesi

                            {
                                Id = arac.Id,
                                KategoriId = arac.KategoriId,
                                KiraTipID = arac.KiraTipID,
                                Km = arac.Km,
                                Marka = arac.Marka,
                                Model = arac.Model,
                                Yil = arac.Yil,
                                BirimFiat = arac.BirimFiat,
                                Plaka = arac.Plaka,

                                KiralamaTarihi = RandomDay(),
                                KiralamaBitisTarihi = DateTime.Now,
                                SonMusteryId = musteriler.Id,
                                Aciklama = arac.Aciklama + "--ARAÇ ÜCRETİ ODENDİ " + "->" + Convert.ToString(DateTime.Now),
                                IsRent = false,
                                IsReserved = false,
                                IsActive = true

                            }
                          );

                            MessageBox.Show("SİLME   İŞLEMİ  BAŞARILI  !!!!");
                     
                        }
                        else
                        {
                           
                            MessageBox.Show("SİLME   İŞLEMİ  BAŞARILI  !!!!");
                          
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {

                }
            }                      
        }

        private Random gen = new Random();
        private Random gen1 = new Random();

        private Random gen2 = new Random();

        private Random gen3 = new Random();

        private Random gen4 = new Random();


        DateTime RandomDay()
        {
            DateTime dayim;

            int minute = gen1.Next(1, 59);
            int hour = gen2.Next(1, 23);
            int second = gen3.Next(1, 54);
            int salise = gen4.Next(1, 900);
            //DateTime start = new DateTime(1900, 1, 1);
            //int range = (Convert.ToDateTime("1999,12,30") - start).Days;
            string datem = "2000-02-01 " + "" + Convert.ToString(hour) + ":" + Convert.ToString(minute) + ":" + Convert.ToString(second) + "." + Convert.ToString(salise);
            dayim = Convert.ToDateTime(datem);
            return dayim;

            // return start.AddDays(gen.Next(range));

        }


        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string key = txtAra.Text;
            
            string[] dizim = new string[] { "","0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
           
            bool var = false;
            foreach (char item in key.ToCharArray())
            {

                for (int i = 0; i < dizim.Length; i++)
                {
                    if (dizim[i].Contains(item) == true)
                    {
                        var = true;
                    }
                }

            }

            if (var == false && key != "")
            {
                MessageBox.Show("LÜTFEN BİR  MÜŞTERİ NUMARASI  GİRİNİZ !!");
            }
           
            else
            {
                dgwAracListesi.Columns[1].HeaderCell.Style.ForeColor = Color.DarkSlateBlue;
                try
                {
                    dgwAracListesi.DataSource = _kasaService.GetCountsByCustomerId(Convert.ToInt32(txtAra.Text)).ToList();
                }
                catch 
                {
                    dgwAracListesi.DataSource = _kasaService.GetALLActiveBills();

                }
              

                // ListCarsByNameOrPlaka(txtAra.Text);
            }
        }



        private void txtAra_MouseClick(object sender, MouseEventArgs e)
        {
            txtAra.Text = "";
        }


        
        private void btnKasaGuncell_Click(object sender, EventArgs e)
        {
            var seciliSira = dgwAracListesi.CurrentRow.Cells;

            if (seciliSira == null)
            {
                MessageBox.Show("Test");
            }
            try
            {
               

                Kasa kasaGuncel = _kasaService.GetKasaBillById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));
            }
            catch 
            {

                MessageBox.Show("LÜTFEN  KASA TABLOSUNDAN  BİR  KASA  İŞLEMİ  SEÇİNİZ !!");
            }

           
            if (cellChanged==true)
            {
               // var seciliSira = dgwAracListesi.CurrentRow.Cells;
                try
                {
                    _kasaService.Update(new Kasa {

                       ////// Id= 4,
                        MusteriId= Convert.ToInt32(seciliSira[1].Value),
                        AracNo= Convert.ToInt32(seciliSira[2].Value),
                        BirimFiyat= Convert.ToDecimal(seciliSira[3].Value),
                        TumBorc = Convert.ToDecimal(seciliSira[4].Value),
                        IndirimMiktari = Convert.ToDecimal(seciliSira[5].Value),
                        OdemeMiktari = Convert.ToDecimal(seciliSira[6].Value),
                        KalanUcret = Convert.ToDecimal(seciliSira[7].Value),
                        OdemeTipi = Convert.ToString(seciliSira[8].Value),
                        OdemeTarihi = Convert.ToDateTime(seciliSira[9].Value),
                        DierKasaIslemi = Convert.ToBoolean(seciliSira[10].Value),
                        Aciklama= Convert.ToString(seciliSira[11].Value),
                        IsActive= Convert.ToBoolean(seciliSira[12].Value),
                        
                    }
                    );

                    MessageBox.Show("KASA  İŞLEMİNDE   DEĞİŞİKLİK   YAPILDI !!");
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("KASA  İŞLEMİNDE  DEĞİŞİKLİK  YAPILMADI !!");
            }

        }

        private void btnArsiv_Click(object sender, EventArgs e)
        {
            dgwAracListesi.DataSource = _kasaService.GetALLBills();
            dgwAracListesi.Columns[1].Visible = false;
          //  MessageBox.Show(dgwAracListesi.Columns.Count.ToString());
        }

       

        private void txtAracno_MouseClick(object sender, MouseEventArgs e)
        {
            txtAra.Text = "";
        }

        private void txtMusterino_MouseClick(object sender, MouseEventArgs e)
        {
            txtMusterino.Text = "";
           
           
        }
       
        private void OdemeFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Form1.Olustur.Show();
        }

        private void txtAracno_TextChanged(object sender, EventArgs e)
        {
            TextControlNumbers();

        }

        private void TextControlNumbers()
        {
            string deger = txtAracno.Text;
            string[] dizim = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool result = false;
            foreach (char item in deger.ToCharArray())
            {

                for (int i = 0; i < dizim.Length; i++)
                {
                    if (dizim[i].Contains(item) == true)
                    {
                        result = true;
                    }
                }

            }
            try
            {
               bool result2 = _araclistesiService.CheckCarNumber(Convert.ToInt32(deger));
                if (result == false || result2 == false || Convert.ToInt32(deger) > 5000)
                {
                    MessageBox.Show("LÜTFEN GEÇERLİ BİR ARAÇ NUMARASI GİRİNİZ !! (EN FAZLA 500 !)");
                   
                }
            }
            catch
            {

                MessageBox.Show(" SAYI GİRİNİZ !! (EN FAZLA 500 !)");
               
            }
        }
     
        private void txtMusterino_TextChanged(object sender, EventArgs e)
        {
            //Metod();
            DEGERM = txtMusterino.Text;

           // Beklet.BekletMetod();
            string deger = DEGERM;
            string[] dizim = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            bool var = false;
            foreach (char item in deger.ToCharArray())
            {

                for (int i = 0; i < dizim.Length; i++)
                {
                    if (dizim[i].Contains(item) == true)
                    {
                        var = true;
                    }
                }

            }
            try
            {
                bool var2 = _musterilerService.CheckCostumerNumber(Convert.ToInt32(deger));
                if (var == false || var2 == false || Convert.ToInt32(deger) > 50000)
                {
                    MessageBox.Show("LÜTFEN GEÇERLİ BİR MÜŞTERİ NUMARASI GİRİNİZ !! (EN FAZLA 500 !)");

                }
            }
            catch
            {

                //MessageBox.Show("LÜTFEN GEÇERLİ BİR MÜŞTERİ NUMARASI GİRİNİZ !! (EN FAZLA 500 !)");

            }

        }

        private void txtIndirim_Enter(object sender, EventArgs e)
        {

        }

        

        private void txtMusterino_MouseEnter(object sender, EventArgs e)
        {

        }
        static async Task Bekle(int ms)
        {
            await Task.Delay(ms);
        }

        static async void Metod()
        {
           
            await Bekle(600);// DEGERM = DEGERM2;
        }
        public static String DEGERM;
        public static String DEGERM2;



        public static bool cellChanged = false;
        private void dgwAracListesi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cellChanged = true;
        }

       


        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dgwAracListesi.DataSource = _kasaService.GetKasaBilssBetweenDates(dtpSearchStart.Value, dtpSearchFinish.Value);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dgwAracListesi.DataSource = _kasaService.GetKasaBilssBetweenDates(dtpSearchStart.Value, dtpSearchFinish.Value);

        }

        private void dgwAracListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chkDateSearh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDateSearh.Checked == true)
            {
                dtpSearchStart.Visible = true;
                dtpSearchStart.Value = DateTime.Now.AddMonths(-1);
                dtpSearchStart.Enabled = true;

                dtpSearchFinish.Visible = true; dtpSearchFinish.Enabled = true;
                dtpSearchFinish.Value = DateTime.Now;

                btnGetCountsByDate.Visible = true; btnGetCountsByDate.Enabled = true;


                dgwAracListesi.DataSource = _kasaService.GetKasaBilssBetweenDates(dtpSearchStart.Value,dtpSearchFinish.Value);
            }
            else
            {
                dtpSearchStart.Visible = false;
                dtpSearchStart.Enabled = false;
                dtpSearchStart.Value = DateTime.Now.AddMonths(-1);

                dtpSearchFinish.Visible = false;
                dtpSearchFinish.Enabled = false;
                dtpSearchFinish.Value = DateTime.Now;

                btnGetCountsByDate.Visible = false; btnGetCountsByDate.Enabled = false;
            }
        }

        private void txtCountSearhByCarNo_TextChanged(object sender, EventArgs e)
        {
          

            string key =  txtCountSearhByCarNo.Text;

            string[] dizim = new string[] {"", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            bool varmi = false;
            foreach (char item in key.ToCharArray())
            {

                for (int i = 0; i < dizim.Length; i++)
                {
                    if (dizim[i].Contains(item) == true)
                    {
                        varmi = true;
                        i = dizim.Length - 1;
                    }
                }

            }

            if ( varmi == false&&key!="")
            {
                MessageBox.Show("LÜTFEN BİR ARAÇ  NUMARASI  GİRİNİZ !!");
                // dgwAracListesi.DataSource = _kasaService.GetALLBills();
                dgwAracListesi.DataSource = _kasaService.GetALLActiveBills();
            }
            else
            {
               

                try
                {
                    dgwAracListesi.DataSource = _kasaService.GetKasaBilssByCarId(Convert.ToInt32(txtCountSearhByCarNo.Text));
                }
                catch
                {
                    dgwAracListesi.DataSource = _kasaService.GetALLActiveBills();
                    dgwAracListesi.Rows[1].Selected = true;
                    dgwAracListesi.Columns[2].HeaderCell.Style.BackColor = Color.DarkRed;
                    dgwAracListesi.CurrentRow.HeaderCell.Style.ForeColor = Color.Green;
                   

                }
                //if (_kasaService.GetKasaBilssByCarId(Convert.ToInt32(txtCountSearhByCarNo.Text))!=null)
                //{
                //    dgwAracListesi.DataSource = _kasaService.GetKasaBilssByCarId(Convert.ToInt32(txtCountSearhByCarNo.Text));
                //}

                //dgwAracListesi.DataSource = _kasaService.GetALLActiveBills();

                // ListCarsByNameOrPlaka(txtAra.Text);
              //  dgwAracListesi.CurrentRow.HeaderCell.Style.BackColor = Color.DarkRed;
            }
        }

        private void txtCountSearhByCarNo_Click(object sender, EventArgs e)
        {
            txtCountSearhByCarNo.Text = "";  dgwAracListesi.DataSource = _kasaService.GetALLActiveBills();
        }

        private void txtCountSearhByCarNo_Validated(object sender, EventArgs e)
        {

        }

        private void txtMusterino_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lblAracno_Click(object sender, EventArgs e)
        {

        }

        private void txtAracno_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lblMusteriNo_Click(object sender, EventArgs e)
        {

        }

       

        private void rdbNormalKasaIslem_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNormalKasaIslem.Checked == true)
            {

                lblAracno.BackColor = Color.LightBlue;
                lblMusteriNo.BackColor = Color.LightBlue;

                txtMusterino.Text = "1";
            }
            else
            {
                
                lblAracno.BackColor = Color.LightGray;
                lblMusteriNo.BackColor = Color.LightGray;

            }
        }

        private void rdbDierKasaIslem_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDierKasaIslem.Checked == true)
            {
              

                lblAracno.BackColor = Color.FromArgb(255, 224, 192);
                lblMusteriNo.BackColor = Color.FromArgb(255, 224, 192);
                txtToplamBorc.ReadOnly = false;


                txtMusterino.Text = "1";
            }
            else
            {
                rdbDierKasaIslem.Checked = false;
                txtToplamBorc.ReadOnly = true;
                lblAracno.BackColor = Color.LightGray;
                lblMusteriNo.BackColor = Color.LightGray;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            //AracListesi arac = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value));

            //Musteriler activeMusteri = _musterilerService.GetCustomerByCarId(arac.Id, arac.KiralamaBitisTarihi);

            //Musteriler musteriler = _musterilerService.GetLastCustomerByCarId(arac.Id);


            //try
            //{
            //    if (activeMusteri.KiralamaBitisTarihi > DateTime.Now && arac.IsActive == true)
            //    {

            //        _musterilerService.Update(new Musteriler

            //        {
            //            Id = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value),
            //            AracId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value),
            //            Ad = txtAd.Text,
            //            Soyad = txtSoyad.Text,
            //            TCNo = Convert.ToInt32(txtTcno.Text),
            //            DogumTarihi = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[11].Value),
            //            KiraTipi = Convert.ToString(dgwAracListesi.CurrentRow.Cells[10].Value),
            //            Adres = txtAdres.Text,

            //            Telefon = Convert.ToInt32(txtTel.Text),
            //            KiralamaTarihi = dtpAracKiralamaTarh.Value,
            //            KiralamaBitisTarihi = dtpAracKiraBitis.Value,
            //            Aciklama = txtAciklama.Text + "--MÜŞTERİ SİLİNDİ " + "->" + Convert.ToString(DateTime.Now),
            //            IsaActive = false
            //        }
            //      );

            //        _araclistesiService.Update(new AracListesi

            //        {
            //            Id = arac.Id,
            //            KategoriId = arac.KategoriId,
            //            KiraTipID = arac.KiraTipID,
            //            Km = arac.Km,
            //            Marka = arac.Marka,
            //            Model = arac.Model,
            //            Yil = arac.Yil,
            //            BirimFiat = arac.BirimFiat,
            //            Plaka = arac.Plaka,

            //            KiralamaTarihi = RandomDay(),
            //            KiralamaBitisTarihi = DateTime.Now,
            //            SonMusteryId = musteriler.Id,
            //            Aciklama = arac.Aciklama,
            //            IsRent = false,
            //            IsReserved = false,
            //            IsActive = true

            //        }
            //      );



            //        MessageBox.Show("SİLME   İŞLEMİ  BAŞARILI  !!!!");
            //        ListAllMusteriler();
            //    }
            //    else
            //    {
            //        _musterilerService.Update(new Musteriler

            //        {
            //            Id = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value),
            //            AracId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value),
            //            Ad = txtAd.Text,
            //            Soyad = txtSoyad.Text,
            //            TCNo = Convert.ToInt32(txtTcno.Text),
            //            DogumTarihi = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[11].Value),
            //            KiraTipi = Convert.ToString(dgwAracListesi.CurrentRow.Cells[10].Value),
            //            Adres = txtAdres.Text,
            //            Telefon = Convert.ToInt32(txtTel.Text),
            //            KiralamaTarihi = dtpAracKiralamaTarh.Value,
            //            KiralamaBitisTarihi = dtpAracKiraBitis.Value,
            //            Aciklama = txtAciklama.Text + "--MÜŞTERİ SİLİNDİ " + "->" + Convert.ToString(DateTime.Now),
            //            IsaActive = false
            //        }
            //    );

            //        MessageBox.Show("SİLME   İŞLEMİ  BAŞARILI  !!!!");
            //        ListAllMusteriler();
            //    }

            //}
            //catch (Exception)
            //{

            //    throw;
            //}



            //AracListesi arac= _araclistesiService.GetCarById(Convert.ToInt32 (dgwAracListesi.CurrentRow.Cells[1].Value));
            //// dgwAracListesi.Tag = arac.Id;
            //Musteriler musterim = _musterilerService.GetCustomerByCarId(arac.Id, arac.KiralamaBitisTarihi);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            //button1.PerformClick();
            //timer1.Enabled = false;
        }

        private void txtOdenenMiktar_Leave(object sender, EventArgs e)
        {
            decimal TumBorcu = Convert.ToDecimal(txtToplamBorc.Text);

            odenenMiktar = Convert.ToDecimal(txtOdenenMiktar.Text);

            decimal fark = TumBorcu - odenenMiktar;

            if (TumBorcu >= odenenMiktar)
            {
                txtKalan.Text = Convert.ToString(fark - Convert.ToDecimal(txtIndirim.Text));
            }

            if (fark < 0)
            {
                MessageBox.Show("Odenen Ücret TümBorçdan Fazla  olamaz!");
                txtOdenenMiktar.Text = "0";
                txtKalan.Text = TumBorcu.ToString();

            }

            kalan = Convert.ToDecimal(txtKalan.Text);
           
        }
    }
}
