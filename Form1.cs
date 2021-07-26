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
using System.Windows.Forms;

namespace Arac_Kayit_Program
{
    public partial class Form1 : Form
    {

        private static Form1 GetForm1;
        public static Form1 Olustur

        {
            get
            {
                if (GetForm1 == null)
                    GetForm1 = new Form1();
                return GetForm1;
            }

            set
            {
                GetForm1 = value;
            }
        }


        private Form1()
        {
            InitializeComponent();

            _araclistesiService = InstanceFactory.GetInstance<IAracListesiService>();
            _kategorilerService = InstanceFactory.GetInstance<IKategorilerService>();
            _musterilerService = InstanceFactory.GetInstance<IMusterilerService>();
            _kasaService = InstanceFactory.GetInstance<IKasaService>();
            _kiraTipService = InstanceFactory.GetInstance<IKiraTipService>();
            _aracDetaylarService= InstanceFactory.GetInstance<IAracDetaylarService>();
            _userService = InstanceFactory.GetInstance<IUserService>();

        }

        private IUserService _userService;

        private IKasaService _kasaService;
        private IAracListesiService _araclistesiService;
        private IKategorilerService _kategorilerService;
        private IMusterilerService _musterilerService;
        private IKiraTipService _kiraTipService;
        private IAracDetaylarService _aracDetaylarService;


        public static int userID;
        
        private void Form1_Load(object sender, EventArgs e)
        {

            userID = SifreGirisForm.userGirisID;
           //User activeUser = _userService.GetUserById(userID);
           //string Username = activeUser.UserName;

           // this.Text = this.Text + "   V:0.1               UserName   :  "+Username;
            //  RandomDay();
            //  ListAllAraclar();
            ListReadyCarsByColor();
            ListALLKategoriler(); 

            // ListCars();
            //ListKategoriler();
            dtpAracKiralamaTarh.Value = DateTime.Now.AddHours(4);
            dtpAracKiraBitis.Value = DateTime.Now.AddHours(6);
            dtpAracKiraTime2.Value = DateTime.Now.AddHours(4);
            dtpAracKiraBitisDate2.Value = DateTime.Now.AddHours(6);
        }

        private void ListALLKategoriler()
        {
            cmbAracSec.DataSource = _kategorilerService.GetAlllAracListesis();
            cmbAracSec.ValueMember = "KategoriId";
            cmbAracSec.DisplayMember = "KategoriAdi";

            cmbAracTip2.DataSource = _kategorilerService.GetAlllAracListesis();
            cmbAracTip2.ValueMember = "KategoriId";
            cmbAracTip2.DisplayMember = "KategoriAdi";


            cmbKiraTipCar.DataSource = _kiraTipService.GetAlllAracListesis();
            cmbKiraTipCar.ValueMember = "ID";
            cmbKiraTipCar.DisplayMember = "KiraTipi";

            cmbKiraTipMus.DataSource = _kiraTipService.GetAlllAracListesis();
            cmbKiraTipMus.ValueMember = "ID";
            cmbKiraTipMus.DisplayMember = "KiraTipi";

        }

        private void ListKategoriNamebyId(int id)
        {
            Kategoriler kat = _kategorilerService.GetSelectedKategoryById(id);
           
            cmbAracSec.DisplayMember = kat.KategoriAdi;
           // cmbAracSec.DisplayMember = Convert.ToString(kat.KategoriAdi);

        }


        private void ListKiraTipNamebyId(int id)
        {
            KiraTip kiratip = _kiraTipService.GetSelectedKiratipById(id);

            cmbAracSec.DisplayMember = kiratip.KiraTipi;
            // cmbAracSec.DisplayMember = Convert.ToString(kat.KategoriAdi);

        }
        private void ListAllAraclar()
        {
            dgwAracListesi.Tag = 1;
          dgwAracListesi.DataSource = _araclistesiService.GetAlllAracListesis();

        }

        private void ListReadyCarsByColor()
        {
           List< AracListesi> araclar = _araclistesiService.GetAlllAracListesis().Where(m=>m.IsActive==true).ToList();

            dgwAracListesi.DataSource = araclar;
            dgwAracListesi.Tag = 1;

         AracListesi[] listem = araclar.ToArray();
            for (int i = 0; i < listem.Count(); i++)
            {

                if (listem[i].IsRent == true && listem[i].IsReserved==true)
                {
                    dgwAracListesi.Rows[i].DefaultCellStyle.ForeColor = Color.DimGray;
                }
               else if (listem[i].IsRent == false && listem[i].IsReserved == false)
                {

                    dgwAracListesi.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGreen;

                }
                else if (listem[i].IsReserved == true && listem[i].IsRent == false)
                {
                    dgwAracListesi.Rows[i].DefaultCellStyle.ForeColor = Color.YellowGreen;
                }

                else
                {
                    dgwAracListesi.Rows[i].DefaultCellStyle.ForeColor = Color.OrangeRed;
                }
            }
           

            foreach (AracListesi item in araclar)
            {
                int siram = item.Id;              
               
            }                                  
        }

        private void ListCarsByKategories(int kategoriId)
        {
            dgwAracListesi.Tag = 1;
            using (ARABALARContext context = new ARABALARContext())
            {
                dgwAracListesi.DataSource = context.AracListesis.Where(x=>x.KategoriId==kategoriId).ToList();
            }
        }

        private void ListKategoriler()
        {
            using (ARABALARContext context = new ARABALARContext())
            {
                cmbAracSec.DataSource = context.Kategorilers.ToList();
                cmbAracSec.ValueMember = "KategoriId";
                cmbAracSec.DisplayMember = "KategoriAdi";

                
            }
        }

        private void cmbAracSec_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   cmbAracTip2.SelectedValue = cmbAracSec.SelectedValue;
           
        }

        private void ListCarsByNameOrPlaka( string plaka)
        {
            dgwAracListesi.Tag = 1;
            using (ARABALARContext context = new ARABALARContext())
            {
                dgwAracListesi.DataSource = context.AracListesis.Where(x =>x.Plaka.ToLower().Contains(plaka.ToLower())).ToList();
               
            }
        }

        //private void ListCarsByNameOrPlaka(string surname,string plaka)
        //{
        //    using (ARABALARContext context = new ARABALARContext())
        //    {
        //        dgwAracListesi.DataSource = context.Musterilers.SingleOrDefault(x => x.Soyad ==surname);

        //    }
        //}

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            
          string key = txtAra.Text;
            if (string.IsNullOrEmpty(key))
            {
                //Button button = btnMusteriler;
                //button.PerformClick();
                ListAllMusteriler();
                // ListCars();
            }
            else
            {
                dgwAracListesi.DataSource = _musterilerService.GetAlllMusterilerByName(txtAra.Text);

              // ListCarsByNameOrPlaka(txtAra.Text);
            }
           
        }

        private void txtAra_MouseClick(object sender, MouseEventArgs e)
        {
            txtAra.Text = "";
        }
        
        private void btnMusteriler_Click(object sender, EventArgs e)
        {
            

            dgwAracListesi.RowsDefaultCellStyle.ForeColor = Color.Green;
            dgwAracListesi.Columns[2].DefaultCellStyle.BackColor = Color.Yellow;
            dgwAracListesi.Columns[3].DefaultCellStyle.BackColor = Color.Yellow;
            dgwAracListesi.Columns[4].DefaultCellStyle.BackColor = Color.Yellow;

            btnMusteriler.BackColor = Color.Green;
            btnAraçlar.BackColor = Color.Gray;
            ListAllActiveMusteriler();
            dgwAracListesi.Tag = 2;

           

        }

        private void ListAllMusteriler()
        {
            dgwAracListesi.Tag = 2;
          dgwAracListesi.DataSource = _musterilerService.GetAlllMusteriler();


        }
        private void ListAllActiveMusteriler()
        {
            dgwAracListesi.Tag = 2;
          dgwAracListesi.DataSource = _musterilerService.GetAlllActiveMusteriler();

           var sira = dgwAracListesi.CurrentRow.Cells;

            AracListesi mycar = new AracListesi();
            mycar = _araclistesiService.GetCarById(Convert.ToInt32(sira[1].Value));

            List<Musteriler> musterilers = _musterilerService.GetAlllActiveMusteriler();



            Musteriler[] listem = _musterilerService.GetAlllActiveMusteriler().ToArray();
            

            for (int i = 0; i < listem.Count(); i++)
            {
                if (listem[i].KiralamaBitisTarihi < DateTime.Now)
                {
                    dgwAracListesi.Rows[i].DefaultCellStyle.ForeColor = Color.SteelBlue;
                }
                else
                {
                    dgwAracListesi.Rows[i].DefaultCellStyle.ForeColor = Color.OrangeRed;
                }
              
            }

        }

        private void btnAraçlar_Click(object sender, EventArgs e)
        {
            dgwAracListesi.Tag = 1;
            btnMusteriler.BackColor = Color.Gray;
            btnAraçlar.BackColor = Color.Green;
            ListReadyCarsByColor();
           
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            
            if(Convert.ToInt32(dgwAracListesi.Tag )== 1)
                /*(dgwAracListesi.CurrentRow.Cells[5].ValueType == typeof(decimal))*/
            {

                AracListesi car = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));

             

                if (car.IsRent == true)//|| dgwAracListesi.CurrentRow.Cells[5].ValueType != typeof(decimal)??
                {


                    MessageBox.Show("BU ARAÇ  ŞU AN ZATEN   KİRALANMIŞTIR!!\n LÜTFEN ÖNCE MÜŞTERİ BİLGİLERİNİ GİRİNİZ SONRA DA ARAÇLAR MENÜSÜNDEN YEŞİL RENKLİ BOŞTAKİ ARAÇLARDAN BİRİNİ SEÇİNİZ !!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    try
                    {


                        _musterilerService.Add(new Musteriler
                        {

                            AracId = car.Id,
                            Ad = txtAd.Text,
                            Soyad = txtSoyad.Text,
                            TCNo = Convert.ToInt32(txtTcno.Text),
                            DogumTarihi = dtpDogumTarihi.Value,
                            Adres = txtAdres.Text,
                            KiraTipi= Convert.ToInt32(cmbKiraTipMus.SelectedValue),
                            Telefon = Convert.ToInt32(txtTel.Text),
                            KiralamaTarihi = dtpAracKiralamaTarh.Value,
                            KiralamaBitisTarihi = dtpAracKiraBitis.Value,
                            Aciklama = txtAciklama.Text,

                            IsaActive = true
                        }


                       );

                       Musteriler[] musteriListem= _musterilerService.GetAlllMusteriler().ToArray();
                        Musteriler musterim = new Musteriler();
                        musterim = musteriListem.Last(); //_musterilerService.GetLastMusteriler();

                        _araclistesiService.Update(new AracListesi {
                            Id = car.Id,

                            KategoriId = car.KategoriId,
                            Marka = car.Marka,
                            Model = car.Model,
                            Yil = car.Yil,
                            BirimFiat = BirimFiatHesapla(car.Id),
                            Plaka = car.Plaka,
                            Km = Convert.ToInt32(mskedTextKm.Text),
                            KiraTipID = Convert.ToInt32(cmbKiraTipCar.SelectedValue),
                            KiralamaTarihi = dtpAracKiralamaTarh.Value,
                            KiralamaBitisTarihi = dtpAracKiraBitis.Value,
                            SonMusteryId =musterim.Id,
                            Aciklama = txtAracAciklama.Text,
                            IsRent = true,
                            IsActive = true

                        }
                        
                        );


                        MessageBox.Show("MÜŞTERİ EKLEME İŞLEMİ  BAŞARILI  !!!!");
                        Button mybutton = btnMusteriler;
                        

                        btnMusteriler.PerformClick();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }

            }
            else
            {
                MessageBox.Show("LÜTFEN ÖNCE MÜŞTERİ BİLGİLERİNİ GİRİNİZ SONRA DA ARAÇLAR MENÜSÜNDEN YEŞİL RENKLİ BOŞTAKİ ARAÇLARDAN BİRİNİ SEÇİNİZ !!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
                       
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
           
            if (Convert.ToInt32(dgwAracListesi.Tag) == 2)
            {

                try
                {

                    _musterilerService.Update(new Musteriler

                    {
                        Id = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value),
                        AracId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value),
                        Ad = txtAd.Text,
                        Soyad = txtSoyad.Text,
                        TCNo = Convert.ToInt32(txtTcno.Text),
                        Adres = txtAdres.Text,
                        DogumTarihi = dtpDogumTarihi.Value,

                        KiraTipi = Convert.ToInt32(cmbKiraTipMus.SelectedValue),
                        Telefon = Convert.ToInt32(txtTel.Text),
                        KiralamaTarihi = dtpAracKiralamaTarh.Value,
                        KiralamaBitisTarihi = dtpAracKiraBitis.Value,
                        Aciklama = txtAciklama.Text,
                        IsaActive = true

                    }
                    );

                    AracListesi car = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value));
                    Musteriler[] musteriListem = _musterilerService.GetAlllMusteriler().ToArray();
                    Musteriler musterim = new Musteriler();
                    musterim = musteriListem.Last(); //_musterilerService.GetLastMusteriler();

                    _araclistesiService.Update(new AracListesi
                    {
                        Id = car.Id,

                        KategoriId = car.KategoriId,
                        Marka = car.Marka,
                        Model = car.Model,
                        Yil = car.Yil,
                        BirimFiat = BirimFiatHesapla(car.Id),
                        Plaka = car.Plaka,
                        Km = Convert.ToInt32(mskedTextKm.Text),
                        KiraTipID = Convert.ToInt32(cmbKiraTipCar.SelectedValue),
                        KiralamaTarihi = dtpAracKiralamaTarh.Value,
                        KiralamaBitisTarihi = dtpAracKiraBitis.Value,
                        SonMusteryId = musterim.Id,
                        Aciklama = txtAracAciklama.Text,
                        IsRent = true,
                        IsActive = true

                    }

                    );


                    MessageBox.Show("GÜNCELLEME   İŞLEMİ  BAŞARILI  !!!!");
                    ListAllActiveMusteriler();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("LÜTFEN MÜŞTERİLER TABLOSUNDAN  MÜŞTERİ SECİNİZ !!!");
            }     
        }

        private void ShowToolTip(object sender, string message)
        {
            new ToolTip().Show(message, this, Cursor.Position.X - this.Location.X, Cursor.Position.Y - this.Location.Y, 1000);
        }


        public static int aracTipim;
        public static string markam;
        public static string modelim;
        public static string yilim;
        public static string birimFiyatım;
        public static string plakam;
        public static DateTime kiraTarihim;
        public static DateTime kiraBitisTarihim;
        public static int SonMusteryIdm;
        public static int kmetrem;
        public static int kiratipCarIdm;
        public static DateTime dogumTarihim;
        public static string kiratipMusteriIdm;




      
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
            string datem = "2000-01-01 " + "" + Convert.ToString(hour) + ":" + Convert.ToString(minute)+":" + Convert.ToString(second) +"." + Convert.ToString(salise);
               dayim=  Convert.ToDateTime(datem);
                return dayim;
              
               // return start.AddDays(gen.Next(range));
            
        }



        public static string Aciklamam;

        private void dgwAracListesi_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            txtAd.ForeColor = Color.Black;
            txtSoyad.ForeColor = Color.Black;
            txtTcno.ForeColor = Color.Black;
            txtAdres.ForeColor = Color.Black;
            txtTel.ForeColor = Color.Black;

            txtAciklama.ForeColor = Color.Black;


            dgwAracListesi.SelectionMode = DataGridViewSelectionMode.CellSelect;

            var sira = dgwAracListesi.CurrentRow;


            if (sira.Cells.Count == 13 && (sira.Cells[5].ValueType == typeof(long)))    // (Convert.ToInt32(dgwAracListesi.Tag)==2) //if (sira.Cells[9].ValueType==typeof(int))

            {

                lblSayac.Text = "";

            txtAd.Text =Convert.ToString (sira.Cells[2].Value);
            txtSoyad.Text = Convert.ToString(sira.Cells[3].Value);
            txtTcno.Text = Convert.ToString(sira.Cells[5].Value);
            txtAdres.Text = Convert.ToString(sira.Cells[6].Value);
            txtTel.Text = Convert.ToString(sira.Cells[4].Value);
            dtpAracKiralamaTarh.Value = Convert.ToDateTime(sira.Cells[7].Value);
            dtpAracKiraBitis.Value = Convert.ToDateTime(sira.Cells[8].Value);
             dtpDogumTarihi.Value= Convert.ToDateTime(sira.Cells[11].Value);
            cmbKiraTipMus.SelectedText = Convert.ToString(sira.Cells[10].Value);
                txtAciklama.Text = Convert.ToString(sira.Cells[9].Value);

                    AracListesi mycar = new AracListesi();
                   mycar= _araclistesiService.GetCarById(Convert.ToInt32(sira.Cells[1].Value));

                //dgwAracListesi.Tag = Convert.ToDecimal(sira.Cells[5].Value);
                   txtMarka.Text = mycar.Marka;
                    txtModel.Text = mycar.Model;
                    txtYil.Text = Convert.ToString(mycar.Yil);
                    txtBirimFiyat.Text = Convert.ToString(mycar.BirimFiat);
                    txtPlaka.Text = mycar.Plaka;
                    dtpAracKiraTime2.Value = Convert.ToDateTime(sira.Cells[7].Value);
                    dtpAracKiraBitisDate2.Value = Convert.ToDateTime(sira.Cells[8].Value);
                    txtSonMustrId.Text = Convert.ToString(mycar.SonMusteryId);
                  mskedTextKm.Text= Convert.ToString(mycar.Km);
                  cmbKiraTipCar.SelectedValue =mycar.KiraTipID;

                cmbAracSec.SelectedValue = mycar.KategoriId;
                    txtAracAciklama.Text = mycar.Aciklama;
                   // mycar.IsActive = true;

                ListKategoriNamebyId(mycar.KategoriId);

                HesapMusteriId = Convert.ToInt32(sira.Cells[0].Value);

                aracTipim = mycar.KategoriId;
                markam = mycar.Marka;
                modelim = mycar.Model;
                yilim = mycar.Yil.ToString();
                birimFiyatım = mycar.BirimFiat.ToString();
                plakam = mycar.Plaka;
                kiraTarihim = mycar.KiralamaTarihi;
                kiraBitisTarihim= DateTime.Now;
                SonMusteryIdm = HesapMusteriId;
                kmetrem = mycar.Km;
                kiratipCarIdm = mycar.KiraTipID;
                kiratipMusteriIdm=Convert.ToString( mycar.KiraTipID);
                dtpDogumTarihi.Value= Convert.ToDateTime(sira.Cells[11].Value);

                Aciklamam = mycar.Aciklama;


                //mskedTextKm.Text = Convert.ToString(sira.Cells[13].Value);
                //cmbKiraTipCar.SelectedValue = Convert.ToDateTime(sira.Cells[14].Value);

            }

            else if (sira.Cells.Count==16 || Convert.ToInt32(dgwAracListesi.Tag) == 1)  // else if(sira.Cells[5].ValueType == typeof(string))
            {
                
                AracDetayiId= Convert.ToInt32(sira.Cells[0].Value);
                HesapMusteriId = Convert.ToInt32(sira.Cells[9].Value);

                DateTime dt = Convert.ToDateTime(sira.Cells[8].Value);
                TimeSpan diff = dt.Subtract(DateTime.Now);

                

                if (diff.Milliseconds>0 && Convert.ToBoolean(sira.Cells[11].Value) == true)
                {
                    lblSayac.Text ="TESLİME "+ Convert.ToString (diff.Days)+" "+"GÜN  VE  " + Convert.ToString(diff.Hours)+" " + "SAAT  KALDI!!";
                    
                }
                else if (diff.Milliseconds <= 0 && Convert.ToBoolean(sira.Cells[11].Value) == true)
                {
                    lblSayac.Text = "UYARI!! TESLİM " + Convert.ToString(diff.Days) + " " + "GÜN  VE  " + Convert.ToString(diff.Hours) + " " + "SAAT  GECİKTİ!!";
                }
                else
                {
                    lblSayac.Text = "";
                }

               
                txtMarka.Text = Convert.ToString(sira.Cells[2].Value);
                txtModel.Text = Convert.ToString(sira.Cells[3].Value);
                txtYil.Text = Convert.ToString(sira.Cells[4].Value);
                txtBirimFiyat.Text = Convert.ToString(sira.Cells[5].Value);
                txtPlaka.Text = Convert.ToString(sira.Cells[6].Value);
                dtpAracKiraTime2.Value = Convert.ToDateTime(sira.Cells[7].Value);
                dtpAracKiraBitisDate2.Value = Convert.ToDateTime(sira.Cells[8].Value);
                txtSonMustrId.Text= Convert.ToString(sira.Cells[9].Value);
                txtAracAciklama.Text = Convert.ToString(sira.Cells[10].Value);
                cmbAracTip2.SelectedValue = sira.Cells[1].Value;
                cmbAracSec.SelectedValue = sira.Cells[1].Value;
                cmbKiraTipCar.SelectedValue= Convert.ToInt32(sira.Cells[14].Value);
                mskedTextKm.Text = Convert.ToString(sira.Cells[13].Value);
                cmbKiraTipMus.SelectedValue= Convert.ToInt32(sira.Cells[14].Value);


                Musteriler mymuster = new Musteriler();
                mymuster = _musterilerService.GetCustomerByCarId(Convert.ToInt32(sira.Cells[0].Value), Convert.ToDateTime(sira.Cells[8].Value));

            
                aracTipim = Convert.ToInt32(sira.Cells[1].Value);
                markam = Convert.ToString(sira.Cells[2].Value);
                modelim = Convert.ToString(sira.Cells[3].Value);
                yilim = Convert.ToString(sira.Cells[4].Value);
                birimFiyatım =  Convert.ToString(sira.Cells[5].Value);
                plakam = Convert.ToString(sira.Cells[6].Value);
                kiraTarihim = Convert.ToDateTime(sira.Cells[7].Value);
                kiraBitisTarihim = DateTime.Now;
                kmetrem = Convert.ToInt32(sira.Cells[13].Value);
                kiratipCarIdm = Convert.ToInt32(sira.Cells[14].Value);


                if (mymuster==null||mymuster.Id<=1)
                {
                    SonMusteryIdm = 1;
                }
                else
                {
                    SonMusteryIdm = mymuster.Id;
                }
                
                Aciklamam = Convert.ToString(sira.Cells[10].Value);


                //burası kiradaki aracınmusteri blgilerini ana forma yazdırmak için

                Musteriler mymusteriNowGotCar = new Musteriler();
                mymusteriNowGotCar = _musterilerService.GetMusteriById(Convert.ToInt32(sira.Cells[9].Value));

                if (mymusteriNowGotCar==null)
                {
                    mymusteriNowGotCar = _musterilerService.GetMusteriById(1);

                }

                if (Convert.ToBoolean(sira.Cells[11].Value) == true && Convert.ToBoolean(sira.Cells[12].Value)==false)
                {
                   

                    txtAd.Text = mymusteriNowGotCar.Ad;
                    txtSoyad.Text = mymusteriNowGotCar.Soyad;
                    txtTcno.Text = Convert.ToString(mymusteriNowGotCar.TCNo);
                    txtAdres.Text = mymusteriNowGotCar.Adres;
                    txtTel.Text =Convert.ToString(mymusteriNowGotCar.Telefon);
                    dtpAracKiralamaTarh.Value = mymusteriNowGotCar.KiralamaTarihi;
                    dtpAracKiraBitis.Value = mymusteriNowGotCar.KiralamaBitisTarihi;
                    txtAciklama.Text = mymusteriNowGotCar.Aciklama;
                    cmbKiraTipMus.SelectedValue = mymusteriNowGotCar.KiraTipi;
                    dtpDogumTarihi.Value = mymusteriNowGotCar.DogumTarihi;
                }
                else if (Convert.ToBoolean(sira.Cells[11].Value) == false && Convert.ToBoolean(sira.Cells[12].Value) == true)
                {
                    txtAd.ForeColor = Color.YellowGreen;
                    txtSoyad.ForeColor = Color.YellowGreen;
                    txtTcno.ForeColor = Color.YellowGreen;
                    txtAdres.ForeColor = Color.YellowGreen;
                    txtTel.ForeColor = Color.YellowGreen;
                    txtSonMustrId.ForeColor= Color.YellowGreen;
                    txtAciklama.ForeColor = Color.YellowGreen;


                    txtAd.Text = mymusteriNowGotCar.Ad;
                    txtSoyad.Text = mymusteriNowGotCar.Soyad;
                    txtTcno.Text = Convert.ToString(mymusteriNowGotCar.TCNo);
                    dtpDogumTarihi.Value = mymusteriNowGotCar.DogumTarihi;
                    txtAdres.Text = mymusteriNowGotCar.Adres;
                    txtTel.Text = Convert.ToString(mymusteriNowGotCar.Telefon);
                    dtpAracKiralamaTarh.Value = mymusteriNowGotCar.KiralamaTarihi;
                    dtpAracKiraBitis.Value = mymusteriNowGotCar.KiralamaBitisTarihi;
                    txtAciklama.Text = mymusteriNowGotCar.Aciklama;
                    cmbKiraTipMus.SelectedValue = cmbKiraTipCar.SelectedValue;
                }
                else if (Convert.ToBoolean(sira.Cells[11].Value) == true && Convert.ToBoolean(sira.Cells[12].Value) == true)
                {

                    txtAd.ForeColor = Color.LightGray;
                    txtSoyad.ForeColor = Color.LightGray;
                    txtTcno.ForeColor = Color.LightGray;
                    txtAdres.ForeColor = Color.LightGray;
                    txtTel.ForeColor = Color.LightGray;
                    txtSonMustrId.ForeColor = Color.Black;
                    txtAciklama.ForeColor = Color.LightGray;


                    txtAd.Text = mymusteriNowGotCar.Ad;
                    txtSoyad.Text = mymusteriNowGotCar.Soyad;
                    txtTcno.Text = Convert.ToString(mymusteriNowGotCar.TCNo);
                    dtpDogumTarihi.Value = mymusteriNowGotCar.DogumTarihi;
                    txtAdres.Text = mymusteriNowGotCar.Adres;
                    txtTel.Text = Convert.ToString(mymusteriNowGotCar.Telefon);
                    dtpAracKiralamaTarh.Value = mymusteriNowGotCar.KiralamaTarihi;
                    dtpAracKiraBitis.Value = mymusteriNowGotCar.KiralamaBitisTarihi;
                    txtAciklama.Text = mymusteriNowGotCar.Aciklama;
                    cmbKiraTipMus.SelectedValue = cmbKiraTipCar.SelectedValue;

                }


            }
            else if   (sira.Cells.Count==13 || Convert.ToInt32(dgwAracListesi.Tag) == 3 ) //  else if (sira.Cells[2].ValueType == typeof(decimal))
            {
                txtAd.ForeColor = Color.Black;
                txtSoyad.ForeColor = Color.Black;
                txtTcno.ForeColor = Color.Black;
                txtAdres.ForeColor = Color.Black;
                txtTel.ForeColor = Color.Black;
                txtSonMustrId.ForeColor = Color.Black;
                txtAciklama.ForeColor = Color.Black;
            }

        }

        private void ShowToolTip(string v)
        {
            MessageBox.Show(v);;
        }

        private void txtPlakaSearch2_TextChanged(object sender, EventArgs e)
        {
            string key = txtPlakaSearch2.Text;
            if (string.IsNullOrEmpty(key))
            {

                Button button = btnAraçlar;
                button.PerformClick();
               
                ListAllAraclar();

                // ListCars();
            }
            else
            {
                dgwAracListesi.DataSource = _araclistesiService.GetAlllAracListesisByPlaka(key).Where(m=>m.IsActive==true).ToList();

                //string veri = "";
                //string[] a = textBox1.Text.Split(' ');
                //for (int i = 0; i < a.Length; i++)
                //{
                //    veri += a[i];
                //}
                //MessageBox.Show(veri);

                // ListCarsByNameOrPlaka(txtAra.Text);
            }
        }

        private void txtPlakaSearch2_MouseClick(object sender, MouseEventArgs e)
        {
            txtPlakaSearch2.Text = "";
        }

        private void btnAracKaydet2_Click(object sender, EventArgs e)
        {
            string key = txtPlaka.Text;
           
            int sonuc =_araclistesiService.GetOneAracListesisByPlaka(key) ;
            if (sonuc>0)
            {

                MessageBox.Show("BU  PLAKA  ZATEN MEVCUTTUR   !!!!");
            }
            else
            {


                try
                {
                    _araclistesiService.Add(new AracListesi
                    {
                        KategoriId = Convert.ToInt32(cmbAracTip2.SelectedValue),
                        KiraTipID = Convert.ToInt32(cmbKiraTipCar.SelectedValue),
                        Km= Convert.ToInt32(mskedTextKm.Text),
                        Marka = txtMarka.Text,
                        Model = txtModel.Text,
                        Yil = Convert.ToInt32(txtYil.Text),
                        BirimFiat = Convert.ToDecimal(txtBirimFiyat.Text),
                        Plaka = txtPlaka.Text,
                        KiralamaTarihi = dtpAracKiraTime2.Value,
                        KiralamaBitisTarihi = dtpAracKiraBitisDate2.Value,
                        SonMusteryId = 1,
                        Aciklama = "EKLEME MÜŞTERİSİ//SANAL",
                        IsRent = false,
                        IsReserved=false,
                        IsActive = true

                    }

                   );
                    MessageBox.Show("EKLEME İŞLEMİ  BAŞARILI  !!!!");
                    MessageBox.Show("DİĞER DETAYLARIDA  EKLEMEK İSTERMİSİNİZ?? \n BÖYLECE ARACINIZI DETAYLI TAKİP EDEBİLİRSİNİZ","ÖNEMLİ !!",MessageBoxButtons.YesNo);


                    if (this.DialogResult == DialogResult.Yes)
                    {
                        AracDetaylarFormu form = new AracDetaylarFormu();
                        this.Hide();
                        form.ShowDialog();
                    }
                    else
                    {
                        Button mybutton = btnAraçlar;
                        mybutton.PerformClick();
                    }
                   
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void btnAracUpdate2_Click(object sender, EventArgs e)
        {
          //  Boolean carIsBeingRepared = false;
            string key = txtPlaka.Text;

            AracDetaylar firstcar = _aracDetaylarService.GetAlllAracListesisByPlaka(key).FirstOrDefault();
            AracListesi firstaracListesi = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));
            int sayi = _araclistesiService.GetAlllAracListesisByPlaka(key).Count();

            int sonuc = _araclistesiService.GetOneAracListesisByPlaka(key);

            //if (firstaracListesi.IsReserved == true && firstaracListesi.IsRent == true) 
            //{
            //    carIsBeingRepared = true;
            //}


            if (sonuc > 0  && firstcar.AracNO!=firstaracListesi.Id)
            {

                MessageBox.Show("BU  PLAKA  ZATEN MEVCUTTUR   !!!!");
            }
            else
            {

                if (dgwAracListesi.CurrentRow.Cells.Count== 16 )
                {

                    try
                    {

                        _araclistesiService.Update(new AracListesi

                        {
                            Id = firstaracListesi.Id,
                            KategoriId = Convert.ToInt32(cmbAracTip2.SelectedValue),
                            KiraTipID = Convert.ToInt32(cmbKiraTipCar.SelectedValue),
                            Km= Convert.ToInt32(mskedTextKm.Text),
                            Marka = txtMarka.Text,
                            Model = txtModel.Text,
                            
                            Yil = Convert.ToInt32(txtYil.Text),
                            BirimFiat =BirimFiatHesapla(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value)),
                            Plaka = txtPlaka.Text,

                            KiralamaTarihi = firstaracListesi.KiralamaTarihi,
                            KiralamaBitisTarihi = firstaracListesi.KiralamaBitisTarihi,
                            SonMusteryId = firstaracListesi.SonMusteryId,
                            IsRent= Convert.ToBoolean(dgwAracListesi.CurrentRow.Cells[11].Value),
                            IsReserved= Convert.ToBoolean(dgwAracListesi.CurrentRow.Cells[12].Value),
                            Aciklama = txtAracAciklama.Text,
                            IsActive = true

                        }
                        );
                        //AracDetaylar firstcar = _aracDetaylarService.GetAlllAracListesisByPlaka(key).FirstOrDefault();
                        //AracListesi firstaracListesi = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));
                       
                       
                        AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById((Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value)));

                       
                            _aracDetaylarService.Update(new AracDetaylar
                            {
                                ID = aracDetaycar.ID,
                                AracNO = Convert.ToInt32((Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value))),
                                Marka = txtMarka.Text,
                                Model = txtModel.Text,
                                Yil = Convert.ToInt32(txtYil.Text),
                                Renk = aracDetaycar.Renk,
                                Km = Convert.ToInt32(mskedTextKm.Text),
                                KategoriId = Convert.ToInt32(cmbAracTip2.SelectedValue),
                                MotorTipi = aracDetaycar.MotorTipi,
                                BeygirGucu = aracDetaycar.BeygirGucu,
                                VitesTipi = aracDetaycar.VitesTipi,
                                YakitTipi = aracDetaycar.YakitTipi,
                                Plaka = txtPlaka.Text,
                                SaseNo = aracDetaycar.SaseNo,
                                BakimKm = aracDetaycar.BakimKm,
                                LastikTam = aracDetaycar.LastikTam,
                                MtvOdendi = aracDetaycar.MtvOdendi,
                                MuayeneVar = aracDetaycar.MuayeneVar,
                                MuayeneBitisTarihi = aracDetaycar.MuayeneBitisTarihi,
                                SigortaVar = aracDetaycar.SigortaVar,
                                SigortaBitisTarihi = aracDetaycar.SigortaBitisTarihi,
                                KaskoVar = aracDetaycar.KaskoVar,
                                KaskoBitisTarihi = aracDetaycar.KaskoBitisTarihi,
                                BakimlarTam = aracDetaycar.BakimlarTam,

                                AracBakimVeTamirdeDegil = aracDetaycar.AracBakimVeTamirdeDegil,
                                TamirBitisTarihi = aracDetaycar.TamirBitisTarihi,
                                Aciklama = txtAracAciklama.Text,
                                IsActive = true

                            }

                            );


                            MessageBox.Show("GÜNCELLEME   İŞLEMİ  BAŞARILI ANCAK; \n TARİHLER VE SON  MUŞTERİ ID  GÜNCELLENMEDİ!!!!");
                        ListAllAraclar();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("LÜTFEN ARAÇLAR TABLOSUNDAN  ARAÇ SECİNİZ !!!");
                }


            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
          
            if (Convert.ToInt32(dgwAracListesi.Tag)==2 )
            {
                AracListesi arac = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value));

                Musteriler activeMusteri = _musterilerService.GetCustomerByCarId(arac.Id,arac.KiralamaBitisTarihi);

                Musteriler musteriler = _musterilerService.GetLastCustomerByCarId(arac.Id);

             
                try
                {
                    if (activeMusteri.KiralamaBitisTarihi>DateTime.Now && arac.IsActive==true)
                    {
                        MessageBox.Show("UYARI !! BU  MÜŞTERİ ŞU ANDA   AKTİF ARAÇ KİRALAMAKTA YADA REZERVASYONDA  GÖZÜKÜYOR !!! \n YİNEDE SİLMEK  İSTİYORMUSUNUZ ???", "ÖNEMLİ !!", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);


                        if (this.DialogResult == DialogResult.Yes)
                        {

                            _musterilerService.Update(new Musteriler

                            {
                                Id = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value),
                                AracId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value),
                                Ad = txtAd.Text,
                                Soyad = txtSoyad.Text,
                                TCNo = Convert.ToInt32(txtTcno.Text),
                                DogumTarihi = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[11].Value),
                                KiraTipi = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[10].Value),
                                Adres = txtAdres.Text,

                                Telefon = Convert.ToInt32(txtTel.Text),
                                KiralamaTarihi = dtpAracKiralamaTarh.Value,
                                KiralamaBitisTarihi = dtpAracKiraBitis.Value,
                                Aciklama = txtAciklama.Text + "--MÜŞTERİ SİLİNDİ " + "->" + Convert.ToString(DateTime.Now),
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
                                Aciklama = arac.Aciklama,
                                IsRent = false,
                                IsReserved = false,
                                IsActive = true

                            }
                            );



                            MessageBox.Show("SİLME   İŞLEMİ  BAŞARILI  !!!!");
                            ListAllMusteriler();
                        }
                        else
                        {
                            _musterilerService.Update(new Musteriler

                            {
                                Id = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value),
                                AracId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value),
                                Ad = txtAd.Text,
                                Soyad = txtSoyad.Text,
                                TCNo = Convert.ToInt32(txtTcno.Text),
                                DogumTarihi = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[11].Value),
                                KiraTipi = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[10].Value),
                                Adres = txtAdres.Text,
                                Telefon = Convert.ToInt32(txtTel.Text),
                                KiralamaTarihi = dtpAracKiralamaTarh.Value,
                                KiralamaBitisTarihi = dtpAracKiraBitis.Value,
                                Aciklama = txtAciklama.Text + "--MÜŞTERİ SİLİNDİ " + "->" + Convert.ToString(DateTime.Now),
                                IsaActive = false
                            }
                            );

                            MessageBox.Show("SİLME   İŞLEMİ  BAŞARILI  !!!!");
                            ListAllMusteriler();
                        }

                    }


                    else
                    {
                           



                    }

                                                              
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                MessageBox.Show("LÜTFEN ÖNCE MÜŞTERİLER TABLOSUNDAN MÜŞTERİ SECİNİZ !!!");
            }
        }

        public  void ActivateDelete()
        {

            AracListesi arac = _araclistesiService.GetCarById(AracDetayiId);

            Musteriler activeMusteri = _musterilerService.GetCustomerByCarId(arac.Id, arac.KiralamaBitisTarihi);

            Musteriler musteriler = _musterilerService.GetLastCustomerByCarId(arac.Id);


            try
            {

                if (arac.IsActive == false)
                {
                    MessageBox.Show("ARAÇ ZATEN SİLİNMİŞTİR !!");
                }

                else if (activeMusteri != null && activeMusteri.KiralamaBitisTarihi > DateTime.Now && arac.IsRent == true || arac.IsReserved == true)
                {

                    _musterilerService.Update(new Musteriler

                    {
                        Id = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value),
                        AracId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value),
                        Ad = txtAd.Text,
                        Soyad = txtSoyad.Text,
                        TCNo = Convert.ToInt32(txtTcno.Text),
                        DogumTarihi = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[11].Value),
                        KiraTipi = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[10].Value),
                        Adres = txtAdres.Text,
                        Telefon = Convert.ToInt32(txtTel.Text),
                        KiralamaTarihi = dtpAracKiralamaTarh.Value,
                        KiralamaBitisTarihi = dtpAracKiraBitis.Value,
                        Aciklama = txtAciklama.Text + "--MÜŞTERİ SİLİNDİ " + "->" + Convert.ToString(DateTime.Now),
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
                        Aciklama = arac.Aciklama,
                        IsRent = false,
                        IsReserved = false,
                        IsActive = false

                    }
                  );

                }
                else if (activeMusteri == null)
                {
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
                        Aciklama = arac.Aciklama,
                        IsRent = false,
                        IsReserved = false,
                        IsActive = false

                    }
                  );


                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

            MessageBox.Show("SİLME   İŞLEMİ  BAŞARILI  !!!!");
            ListAllMusteriler();

        }

        private void btnAracDelete2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult= MessageBox.Show("BU ARACI  SİLMEK ÜZERESİNİZ  ONAY VERİYORMUSUNUZ !!!!", "DİKKAT  !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
       

            if (dialogResult == DialogResult.Yes)
            {
                

                if (Convert.ToInt32(dgwAracListesi.Tag) == 1|| dgwAracListesi.CurrentRow.Cells.Count==16)
                {
                    AracListesi arac = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));

                    Musteriler activeMusteri = _musterilerService.GetCustomerByCarId(arac.Id, arac.KiralamaBitisTarihi);

                    Musteriler musteriler = _musterilerService.GetLastCustomerByCarId(arac.Id);
                    AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));


                    try
                    {

                        if (arac.IsActive == false)
                        {
                            MessageBox.Show("ARAÇ ZATEN SİLİNMİŞTİR !!");
                        }

                        else if (activeMusteri != null && activeMusteri.KiralamaBitisTarihi > DateTime.Now && arac.IsRent == true || arac.IsReserved == true)
                        {

                            #region musteriVarkenDirekSildik
                            //  _musterilerService.Update(new Musteriler

                            //  {
                            //      Id = activeMusteri.Id,
                            //      AracId = arac.Id,
                            //      Ad = txtAd.Text,
                            //      Soyad = txtSoyad.Text,
                            //      TCNo = Convert.ToInt64(txtTcno.Text),
                            //      DogumTarihi = activeMusteri.DogumTarihi,
                            //      KiraTipi = Convert.ToString(arac.KiraTipID),
                            //      Adres = txtAdres.Text,
                            //      Telefon = Convert.ToInt32(txtTel.Text),
                            //      KiralamaTarihi = dtpAracKiralamaTarh.Value,
                            //      KiralamaBitisTarihi = dtpAracKiraBitis.Value,
                            //      Aciklama = txtAciklama.Text + "--MÜŞTERİ SİLİNDİ (UYARI !!!ÇÜNKÜ ARAÇ SİLME İŞLEMİ UYGULANDI !!!!!) " + "->" + Convert.ToString(DateTime.Now),
                            //      IsaActive = false
                            //  }
                            //);

                            //  _araclistesiService.Update(new AracListesi

                            //  {
                            //      Id = arac.Id,
                            //      KategoriId = arac.KategoriId,
                            //      KiraTipID = arac.KiraTipID,
                            //      Km = arac.Km,
                            //      Marka = arac.Marka,
                            //      Model = arac.Model,
                            //      Yil = arac.Yil,
                            //      BirimFiat = arac.BirimFiat,
                            //      Plaka = arac.Plaka,

                            //      KiralamaTarihi = RandomDay(),
                            //      KiralamaBitisTarihi = DateTime.Now,
                            //      SonMusteryId = musteriler.Id,
                            //      Aciklama = arac.Aciklama,
                            //      IsRent = false,
                            //      IsReserved = false,
                            //      IsActive = false

                            //  }
                            //);

                            //  _aracDetaylarService.Update(new AracDetaylar
                            //  {
                            //      ID = aracDetaycar.ID,
                            //      AracNO = (Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value)),
                            //      Marka = txtMarka.Text,
                            //      Model = txtModel.Text,
                            //      Yil = Convert.ToInt32(txtYil.Text),
                            //      Renk = aracDetaycar.Renk,
                            //      Km = Convert.ToInt32(mskedTextKm.Text),
                            //      KategoriId = Convert.ToInt32(cmbAracTip2.SelectedValue),
                            //      MotorTipi = aracDetaycar.MotorTipi,
                            //      BeygirGucu = aracDetaycar.BeygirGucu,
                            //      VitesTipi = aracDetaycar.VitesTipi,
                            //      YakitTipi = aracDetaycar.YakitTipi,
                            //      Plaka = txtPlaka.Text,
                            //      SaseNo = aracDetaycar.SaseNo,
                            //      BakimKm = aracDetaycar.BakimKm,
                            //      LastikTam = aracDetaycar.LastikTam,
                            //      MtvOdendi = aracDetaycar.MtvOdendi,
                            //      MuayeneVar = aracDetaycar.MuayeneVar,
                            //      MuayeneBitisTarihi = aracDetaycar.MuayeneBitisTarihi,
                            //      SigortaVar = aracDetaycar.SigortaVar,
                            //      SigortaBitisTarihi = aracDetaycar.SigortaBitisTarihi,
                            //      KaskoVar = aracDetaycar.KaskoVar,
                            //      KaskoBitisTarihi = aracDetaycar.KaskoBitisTarihi,
                            //      BakimlarTam = aracDetaycar.BakimlarTam,
                            //      AracBakimVeTamirde = aracDetaycar.AracBakimVeTamirde,
                            //      TamirBitisTarihi = aracDetaycar.TamirBitisTarihi,
                            //      Aciklama = txtAracAciklama.Text,
                            //      IsActive = false

                            //  }

                            //    ); 
                            #endregion
                            MessageBox.Show("LÜTFEN ÖNCE ARACIN KİRA/REZERV DURUMUNU DÜZELTİN !!");

                        }
                        else if (activeMusteri == null)
                        {
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
                                Aciklama = arac.Aciklama,
                                IsRent = false,
                                IsReserved = false,
                                IsActive = false

                            }
                          );


                            _aracDetaylarService.Update(new AracDetaylar
                            {
                                ID = aracDetaycar.ID,
                                AracNO = (Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value)),
                                Marka = txtMarka.Text,
                                Model = txtModel.Text,
                                Yil = Convert.ToInt32(txtYil.Text),
                                Renk = aracDetaycar.Renk,
                                Km = Convert.ToInt32(mskedTextKm.Text),
                                KategoriId = Convert.ToInt32(cmbAracTip2.SelectedValue),
                                MotorTipi = aracDetaycar.MotorTipi,
                                BeygirGucu = aracDetaycar.BeygirGucu,
                                VitesTipi = aracDetaycar.VitesTipi,
                                YakitTipi = aracDetaycar.YakitTipi,
                                Plaka = txtPlaka.Text,
                                SaseNo = aracDetaycar.SaseNo,
                                BakimKm = aracDetaycar.BakimKm,
                                LastikTam = aracDetaycar.LastikTam,
                                MtvOdendi = aracDetaycar.MtvOdendi,
                                MuayeneVar = aracDetaycar.MuayeneVar,
                                MuayeneBitisTarihi = aracDetaycar.MuayeneBitisTarihi,
                                SigortaVar = aracDetaycar.SigortaVar,
                                SigortaBitisTarihi = aracDetaycar.SigortaBitisTarihi,
                                KaskoVar = aracDetaycar.KaskoVar,
                                KaskoBitisTarihi = aracDetaycar.KaskoBitisTarihi,
                                BakimlarTam = aracDetaycar.BakimlarTam,
                                AracBakimVeTamirdeDegil = aracDetaycar.AracBakimVeTamirdeDegil,
                                TamirBitisTarihi = aracDetaycar.TamirBitisTarihi,
                                Aciklama = txtAracAciklama.Text+ "UYARI !!ARAÇ SİLME İŞLEMİ  GERÇEKLEŞTİRİLDİ  !!!--> " + " "+Convert.ToString(DateTime.Now),
                                IsActive = false

                            }

                            );

                            MessageBox.Show("SİLME   İŞLEMİ  BAŞARILI  !!!!");
                            ListAllMusteriler();
                        }


                    }
                    catch (Exception)
                    {

                        throw;

                    }
                   
                }
                else
                {
                    MessageBox.Show("LÜTFEN ÖNCE ARAÇLAR TABLOSUNDAN ARAÇ  SECİNİZ !!!");
                }

            }

            else
            {

            }
           
        }


        public static decimal tumBorc;
        public static decimal BirimFiyat;
        public static bool CarIsRent;
        public static bool CarIsReserved;
        public static int seciliKasaDetayId;
        public static decimal AnlikTopBorc;
        public static int gunSimdi;
        public static int HesapMusteriId;
        public static int HesapAraciId;
        public static int AracDetayiId;
        public static decimal OdemeMiktari;
        public static decimal IndirimMiktari;
        public static decimal Kalan;


        public decimal BirimFiatHesapla(int aracTip)
        {
            if (string.IsNullOrEmpty(txtBirimFiyat.Text))
            {
                txtBirimFiyat.Text = "0";
            }

            decimal textFiati = Convert.ToDecimal(txtBirimFiyat.Text);
            decimal BirimFiyatim = new decimal();
                if (aracTip == 1 )
                {
                    BirimFiyat = 200;
                }
                else if (aracTip == 2)
                {
                    BirimFiyat = 300;
                }
                else if (aracTip == 3)
                {
                    BirimFiyat = 600;
                }
                else if (aracTip == 4)
                {
                    BirimFiyat = 400;
                }
            if (textFiati==BirimFiyat)
            {
                return BirimFiyatim;
            }
            else
            {
                return textFiati;
            }

           
        } 
        private void btnHesapKes_Click(object sender, EventArgs e) // ÖDEME İŞLEMLERİİİ
        {
                       
          //  decimal hesap;
            int gun;
            int gunfark;

           

            if (Convert.ToInt32 (dgwAracListesi.Tag)==1)
            {
                AracListesi arac = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));


                if (arac.IsRent == true && arac.IsReserved == true)
                {
                  
                    DialogResult sonuc = new DialogResult();
                    sonuc = MessageBox.Show(" DİER KASA İŞLEMLERİ İÇİN TAMAM' I SEÇİNİZ", "UYARI !!! Araç Aktif DEĞİL! Tamir / Bakım İşlemi var !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (sonuc == DialogResult.Yes)
                    {

                        OdemeFormu btnM = new OdemeFormu();
                        this.Hide();
                        btnM.ShowDialog();
                    }
                    else
                    {

                    }
                }
                else if (arac.IsRent == false && arac.IsReserved == false)
                {
                    DialogResult sonuc = new DialogResult();
                    sonuc = MessageBox.Show(" DİER KASA İŞLEMLERİ İÇİN TAMAM' I SEÇİNİZ", "UYARI !!! Araç ZATEN   BOŞTADIR !!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (sonuc == DialogResult.Yes)
                    {

                        OdemeFormu btnM = new OdemeFormu();
                        this.Hide();
                        btnM.ShowDialog();
                    }
                    else
                    {

                    }

                }
                else if (arac.IsRent == true && arac.IsReserved == false)// ARAC KİRADAA
                {
                    DateTime dt1 = new DateTime();
                    DateTime dt2 = new DateTime();

                    DateTime dt3 = DateTime.Today;


                    dt1 = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[8].Value);
                    dt2 = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[7].Value);


                    TimeSpan diff = dt1.Subtract(DateTime.Now);
                    TimeSpan diff2 = dt2.Subtract(DateTime.Now);
                    int gunfarkSimdi = diff2.Days;

                    gun = (dt1.Day < DateTime.Now.Day && dt2.Day < DateTime.Now.Day) ? GunFarkikBul(dt2, DateTime.Now) : GunFarkikBul(dt2, dt1);

                   
                    gunSimdi = (dt2 <= DateTime.Now) ? GunFarkikBul(dt2, DateTime.Now) : GunFarkikBul(dt1, DateTime.Now);

                    gunfark = Convert.ToInt32(dt2.Day - dt3.Day);


                    decimal birimFiat1 = BirimFiatHesapla(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value));
                    decimal birimFiat2 = Convert.ToDecimal(dgwAracListesi.CurrentRow.Cells[5].Value);
                    if (birimFiat1 == birimFiat2)
                    {
                        BirimFiyat = birimFiat1;
                    }
                    else
                    {
                        BirimFiyat = birimFiat2;
                    }


                    BirimFiyat = BirimFiatHesapla( Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[14].Value));

                    tumBorc = Convert.ToDecimal(dgwAracListesi.CurrentRow.Cells[5].Value) * gun;

                    AnlikTopBorc = Convert.ToDecimal(dgwAracListesi.CurrentRow.Cells[5].Value) * gunSimdi;
                    CarIsRent = Convert.ToBoolean(dgwAracListesi.CurrentRow.Cells[11].Value);
                    CarIsReserved = Convert.ToBoolean(dgwAracListesi.CurrentRow.Cells[12].Value);
                    HesapAraciId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value);
                    HesapMusteriId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[9].Value);


                    dgwAracListesi.CurrentRow.Cells[8].Style.ForeColor = Color.Green;
                    dgwAracListesi.CurrentRow.Cells[7].Style.ForeColor = Color.Green;


                    //  MessageBox.Show("SEÇİLİ ARAÇ BEDELİ  :    \n"+hesap.ToString()+"    "+gunfark.ToString());


                    if (gunfark < 3)
                    {
                        dgwAracListesi.CurrentRow.Cells[8].Style.ForeColor = Color.LightYellow;
                        dgwAracListesi.CurrentRow.Cells[7].Style.ForeColor = Color.LightYellow;
                    }

                }
                else if (arac.IsRent == false && arac.IsReserved == true)//ARAC REZERVE
                {
                    DateTime dt1 = new DateTime();
                    DateTime dt2 = new DateTime();

                    DateTime dt3 = DateTime.Today;


                    dt1 = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[8].Value);
                    dt2 = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[7].Value);


                    TimeSpan diff = dt1.Subtract(DateTime.Now);
                    TimeSpan diff2 = dt2.Subtract(DateTime.Now);
                    int gunfarkSimdi = diff2.Days;

                    gun = (dt1.Day < DateTime.Now.Day && dt2.Day < DateTime.Now.Day) ? GunFarkikBul(dt2, DateTime.Now) : GunFarkikBul(dt2, dt1);

                   
                    gunSimdi = (dt2 <= DateTime.Now) ? GunFarkikBul(dt2, DateTime.Now) : GunFarkikBul(dt1, DateTime.Now);

                    gunfark = Convert.ToInt32(dt2.Day - dt3.Day);


                    decimal birimFiat1 = BirimFiatHesapla(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value));
                    decimal birimFiat2 = Convert.ToDecimal(dgwAracListesi.CurrentRow.Cells[5].Value);
                    if (birimFiat1 == birimFiat2)
                    {
                        BirimFiyat = birimFiat1;
                    }
                    else
                    {
                        BirimFiyat = birimFiat2;
                    }


                    BirimFiyat = BirimFiatHesapla(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[14].Value));

                    tumBorc = Convert.ToDecimal(dgwAracListesi.CurrentRow.Cells[5].Value) * gun;

                    AnlikTopBorc = Convert.ToDecimal(dgwAracListesi.CurrentRow.Cells[5].Value) * gunSimdi;
                    CarIsRent = Convert.ToBoolean(dgwAracListesi.CurrentRow.Cells[11].Value);
                    CarIsReserved = Convert.ToBoolean(dgwAracListesi.CurrentRow.Cells[12].Value);
                    HesapAraciId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value);
                    HesapMusteriId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[9].Value);


                    dgwAracListesi.CurrentRow.Cells[8].Style.ForeColor = Color.Green;
                    dgwAracListesi.CurrentRow.Cells[7].Style.ForeColor = Color.Green;


                    //  MessageBox.Show("SEÇİLİ ARAÇ BEDELİ  :    \n"+hesap.ToString()+"    "+gunfark.ToString());


                    if (gunfark < 3)
                    {
                        dgwAracListesi.CurrentRow.Cells[8].Style.ForeColor = Color.LightYellow;
                        dgwAracListesi.CurrentRow.Cells[7].Style.ForeColor = Color.LightYellow;
                    }

                }

                OdemeFormu btnmm = new OdemeFormu();
                this.Hide();
                btnmm.ShowDialog();
            }
            else  if (Convert.ToInt32(dgwAracListesi.Tag) ==2  )
                {

                AracListesi arac = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value));

                Musteriler activeMusteri = _musterilerService.GetCustomerByCarId(arac.Id, arac.KiralamaBitisTarihi);

                Musteriler musteriler = _musterilerService.GetLastCustomerByCarId(arac.Id);


               
                    if  (arac.IsRent == true && arac.IsReserved == false)// ARAC KİRADAA
                    {

                    
                    DateTime dt3 = DateTime.Today;


                    DateTime dt1 = arac.KiralamaBitisTarihi;
                    DateTime dt2 = arac.KiralamaTarihi;


                    TimeSpan diff = dt1.Subtract(DateTime.Now);
                    TimeSpan diff2 = dt2.Subtract(DateTime.Now);
                    int gunfarkSimdi = diff2.Days;


                    gun = (dt1.Day < DateTime.Now.Day && dt2.Day < DateTime.Now.Day) ? GunFarkikBul(dt2, DateTime.Now) : GunFarkikBul(dt2, dt1);


                    gunSimdi = (dt2 <= DateTime.Now) ? GunFarkikBul(dt2, DateTime.Now) : GunFarkikBul(dt1, DateTime.Now);


                    gunfark = Convert.ToInt32(dt2.Day - dt3.Day);



                    decimal birimFiat1 = BirimFiatHesapla(arac.KategoriId);
                    decimal birimFiat2 = arac.BirimFiat;
                    if (birimFiat1 == birimFiat2)
                    {
                        BirimFiyat = birimFiat1;
                    }
                    else
                    {
                        BirimFiyat = birimFiat2;
                    }


                    BirimFiyat = BirimFiatHesapla(arac.KiraTipID);
                    tumBorc =arac.BirimFiat * gun;
                    AnlikTopBorc = arac.BirimFiat * gunSimdi;
                    CarIsRent = arac.IsRent;
                    CarIsReserved = arac.IsReserved;
                    HesapAraciId = arac.Id;
                    HesapMusteriId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value);


                    //  MessageBox.Show("SEÇİLİ ARAÇ BEDELİ  :    \n"+hesap.ToString()+"    "+gunfark.ToString());

                    }
                    else if (arac.IsRent == false && arac.IsReserved == true)// ARAC REZERVE
                    {
                        


                Musteriler musterim = _musterilerService.GetCustomerByCarId(arac.Id, arac.KiralamaBitisTarihi);



                DateTime dt1 = new DateTime();
                DateTime dt2 = new DateTime();

                dt1 = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[8].Value);
                dt2 = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[7].Value);


                    gun = (dt1.Day < DateTime.Now.Day && dt2.Day < DateTime.Now.Day) ? GunFarkikBul(dt2, DateTime.Now) : GunFarkikBul(dt2, dt1);

                    if (true)
                    {

                    }
                    gunSimdi = (dt1.Day > DateTime.Now.Day) ? GunFarkikBul(dt2, DateTime.Now) : GunFarkikBul(dt2, DateTime.Now);


                gunfark = GunFarkikBul(dt1, DateTime.Now);

                BirimFiyat = arac.BirimFiat;
                tumBorc = BirimFiyat * gun;
                AnlikTopBorc = Convert.ToDecimal(dgwAracListesi.CurrentRow.Cells[5].Value) * gunSimdi;
                CarIsRent = arac.IsRent;
                CarIsReserved = arac.IsReserved;
                    HesapMusteriId = musterim.Id;
                HesapAraciId = arac.Id;//Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value);
               // HesapMusteriId=



                dgwAracListesi.CurrentRow.Cells[8].Style.ForeColor = Color.Green;
                dgwAracListesi.CurrentRow.Cells[7].Style.ForeColor = Color.Green;


              //  MessageBox.Show("SEÇİLİ ARAÇ BEDELİ  :    \n" + hesap.ToString());


                         if (gunfark < 3)
                         {
                         dgwAracListesi.CurrentRow.Cells[8].Style.ForeColor = Color.LightYellow;
                         dgwAracListesi.CurrentRow.Cells[7].Style.ForeColor = Color.LightYellow;
                         }


                    }


               

                //  MessageBox.Show("LÜTFEN ÖNCE ARAÇ SEÇİNİZ !");

                OdemeFormu btnm = new OdemeFormu();
                this.Hide();
                btnm.ShowDialog();
            }



            else if (Convert.ToInt32(dgwAracListesi.Tag) == 3)
            {
                if (dgwAracListesi.Rows.Count>0)
                {
                    seciliKasaDetayId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value);
                    HesapAraciId= Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[2].Value);
                    HesapMusteriId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value);
                  tumBorc= Convert.ToDecimal(dgwAracListesi.CurrentRow.Cells[4].Value);
                    OdemeMiktari= Convert.ToDecimal(dgwAracListesi.CurrentRow.Cells[6].Value);
                    Kalan = Convert.ToDecimal(dgwAracListesi.CurrentRow.Cells[7].Value);
                    IndirimMiktari = Convert.ToDecimal(dgwAracListesi.CurrentRow.Cells[5].Value);

                    OdemeFormu btn = new OdemeFormu();
                    this.Hide();
                    btn.ShowDialog();
                }
                else
                {
                   MessageBox.Show("ARAÇLAR  TABLOSUNDAN  VEYA  MUŞTERİLERDEN  TABLOSUNDAN  KİRADA  OLANI  SEÇİNİZ!!  ");
                }
                                               
            }
            
         
        }

        public int GunFarkikBul(DateTime dt1, DateTime dt2)

        {

            TimeSpan zaman = new TimeSpan(); // zaman farkını bulmak adına kullanılacak olan nesne

            zaman = dt1 - dt2;//metoda gelen 2 tarih arasındaki fark

            return Math.Abs(zaman.Days); // 2 tarih arasındaki farkın kaç gün olduğu döndürülüyor.

        }

        private void cmbAracSec_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnMusteriler.BackColor = Color.Gray;
            btnAraçlar.BackColor = Color.Green;
            cmbAracTip2.SelectedValue = cmbAracSec.SelectedValue;

            try
            {
                dgwAracListesi.DataSource = _araclistesiService.GetAlllByKategorisAracListesis(Convert.ToInt32(cmbAracSec.SelectedValue));
                // ListCarsByKategories(Convert.ToInt32(cmbAracSec.SelectedValue));
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void BtnKayitAra_Click(object sender, EventArgs e)
        {

        }

        private void dgwAracListesi_MouseLeave(object sender, EventArgs e)
        {
            lblSayac.Text = "";
        }

        private   void btnKasa_Click(object sender, EventArgs e)
        {

            dgwAracListesi.Tag = 3;
            btnAraçlar.BackColor = Color.Gray;
            btnMusteriler.BackColor = Color.Gray;


        
            List<Kasa> araclar = _kasaService.GetALLActiveBills();
            dgwAracListesi.DataSource = _kasaService.GetALLActiveBills();



            Kasa[] listem = araclar.ToArray();
            for (int i = 0; i < listem.Count(); i++)
            {
                if (listem[i].Id %2 == 0)
                {

                    dgwAracListesi.Rows[i].DefaultCellStyle.ForeColor = Color.DarkGreen;

                }
                else
                {
                    dgwAracListesi.Rows[i].DefaultCellStyle.ForeColor = Color.OrangeRed;
                }
            }

        }

        public static void button1_Click(object sender, EventArgs e)
        {

        }

       

        private void btnRezervet_Click(object sender, EventArgs e)
        {

            if ( Convert.ToInt32(dgwAracListesi.Tag) == 1)//dgwAracListesi.CurrentRow.Cells[5].ValueType == typeof(decimal) &&
            {

                AracListesi car = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));



                if (car.IsRent == true&&car.IsReserved==false)//|| dgwAracListesi.CurrentRow.Cells[5].ValueType != typeof(decimal)??
                {


                    MessageBox.Show("LÜTFEN ÖNCE MÜŞTERİ BİLGİLERİNİ GİRİNİZ SONRA DA ARAÇLAR MENÜSÜNDEN YEŞİL RENKLİ BOŞTAKİ ARAÇLARDAN BİRİNİ SEÇİNİZ !!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


               else if (car.IsRent == false && car.IsReserved == true)//|| dgwAracListesi.CurrentRow.Cells[5].ValueType != typeof(decimal)??
                {


                    MessageBox.Show("LÜTFEN ÖNCE MÜŞTERİ BİLGİLERİNİ GİRİNİZ SONRA DA ARAÇLAR MENÜSÜNDEN YEŞİL RENKLİ BOŞTAKİ ARAÇLARDAN BİRİNİ SEÇİNİZ !!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                else if (car.IsRent == true && car.IsReserved == true)//|| dgwAracListesi.CurrentRow.Cells[5].ValueType != typeof(decimal)??
                {


                    MessageBox.Show("LÜTFEN ÖNCE MÜŞTERİ BİLGİLERİNİ GİRİNİZ SONRA DA ARAÇLAR MENÜSÜNDEN YEŞİL RENKLİ BOŞTAKİ ARAÇLARDAN BİRİNİ SEÇİNİZ !!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }


                else
                {
                    try
                    {

                        _musterilerService.Add(new Musteriler
                        {

                            AracId = car.Id,
                            Ad = txtAd.Text,
                            Soyad = txtSoyad.Text,
                            TCNo = Convert.ToInt64(txtTcno.Text),
                            DogumTarihi=dtpDogumTarihi.Value,
                            KiraTipi= Convert.ToInt32(cmbKiraTipMus.SelectedValue),
                            Adres = txtAdres.Text,
                            Telefon = Convert.ToInt32(txtTel.Text),
                            KiralamaTarihi = dtpAracKiralamaTarh.Value,
                            KiralamaBitisTarihi = dtpAracKiraBitis.Value,

                            Aciklama = txtAciklama.Text,

                            IsaActive = true
                        }


                       );

                        _musterilerService.GetAlllMusteriler();
                        Musteriler musterim = new Musteriler();
                        musterim = _musterilerService.GetLastMusteriler();

                        _araclistesiService.Update(new AracListesi
                        {
                            Id = car.Id,

                            KategoriId = car.KategoriId,
                            Marka = car.Marka,
                            Model = car.Model,
                            Yil = car.Yil,
                            BirimFiat = car.BirimFiat,
                            Plaka = car.Plaka,
                            KiraTipID = Convert.ToInt32(cmbKiraTipMus.SelectedValue),
                            Km = Convert.ToInt32(mskedTextKm.Text),

                            KiralamaTarihi = dtpAracKiralamaTarh.Value,
                            KiralamaBitisTarihi = dtpAracKiraBitis.Value,
                            SonMusteryId = musterim.Id,
                            Aciklama = txtAracAciklama.Text,
                            IsRent = false,
                            IsReserved = true,
                            IsActive = true

                        }

                        );


                        MessageBox.Show("MÜŞTERİ REZERVASYON İŞLEMİ  BAŞARILI  !!!!");
                        Button mybutton = btnMusteriler;


                        btnMusteriler.PerformClick();

                    }
                    catch (Exception )
                    {

                        throw;
                    }

                }

            }
            else
            {
                MessageBox.Show("LÜTFEN ÖNCE MÜŞTERİ BİLGİLERİNİ GİRİNİZ SONRA DA ARAÇLAR MENÜSÜNDEN YEŞİL RENKLİ BOŞTAKİ ARAÇLARDAN BİRİNİ SEÇİNİZ !!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {


            Application.Exit();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void toolStripDetayGoster_Click(object sender, EventArgs e)
        {
            if (true)
            {

            }
        }

        private void dgwAracListesi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (true)
            {

            }
        }

        private void toolStripTekrarActiveEt_Click(object sender, EventArgs e)
        {
            var sira = dgwAracListesi.CurrentRow;

            if (dgwAracListesi.Rows.Count>0)
            {
                if (sira.Cells.Count == 16)
                {
                    AracListesi mycar = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));


                    if (mycar.IsRent == true && mycar.IsReserved == true)
                    {

                        try
                        {
                            _araclistesiService.Update(new AracListesi
                            {
                                Id = mycar.Id,

                                KategoriId = mycar.KategoriId,
                                Marka = mycar.Marka,
                                Model = mycar.Model,
                                Yil = mycar.Yil,
                                BirimFiat = mycar.BirimFiat,
                                Plaka = mycar.Plaka,
                                KiraTipID=mycar.KiraTipID,
                                Km=mycar.Km,
                                KiralamaTarihi = RandomDay(),
                                KiralamaBitisTarihi =RandomDay2(),
                                SonMusteryId = mycar.SonMusteryId,
                                Aciklama = mycar.Aciklama + "   ARAÇ BAKIMDAN / TAMİRDEN GELDİ , AKTİF   !!!--" + Convert.ToString(DateTime.Now),
                                IsRent = false,
                                IsReserved = false,
                                IsActive = true

                            }

                             );


                            AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById((Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value)));


                            _aracDetaylarService.Update(new AracDetaylar
                            {
                                ID = aracDetaycar.ID,
                                AracNO = Convert.ToInt32((Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value))),
                                Marka = txtMarka.Text,
                                Model = txtModel.Text,
                                Yil = Convert.ToInt32(txtYil.Text),
                                Renk = aracDetaycar.Renk,
                                Km = Convert.ToInt32(mskedTextKm.Text),
                                KategoriId = Convert.ToInt32(cmbAracTip2.SelectedValue),
                                MotorTipi = aracDetaycar.MotorTipi,
                                BeygirGucu = aracDetaycar.BeygirGucu,
                                VitesTipi = aracDetaycar.VitesTipi,
                                YakitTipi = aracDetaycar.YakitTipi,
                                Plaka = txtPlaka.Text,
                                SaseNo = aracDetaycar.SaseNo,
                                BakimKm = aracDetaycar.BakimKm,
                                LastikTam = aracDetaycar.LastikTam,
                                MtvOdendi = aracDetaycar.MtvOdendi,
                                MuayeneVar = aracDetaycar.MuayeneVar,
                                MuayeneBitisTarihi = aracDetaycar.MuayeneBitisTarihi,
                                SigortaVar = aracDetaycar.SigortaVar,
                                SigortaBitisTarihi = aracDetaycar.SigortaBitisTarihi,
                                KaskoVar = aracDetaycar.KaskoVar,
                                KaskoBitisTarihi = aracDetaycar.KaskoBitisTarihi,
                                BakimlarTam = aracDetaycar.BakimlarTam,

                                AracBakimVeTamirdeDegil = true,
                                TamirBitisTarihi = Convert.ToDateTime("01.01.2000"),
                                Aciklama = txtAracAciklama.Text,
                                //  IsActive = true

                            }

                            );



                            MessageBox.Show("ARAÇ BAŞARILI BİR ŞEKİLDE AKTİVE EDİLDİ !");
                            ListAllAraclar();
                        }
                        catch (Exception )
                        {

                            throw;// MessageBox.Show(ex.Message);
                        }

                    }
                    else
                    {
                        MessageBox.Show("ARAÇ ZATEN AKTİF HALDE  !!");
                    }

                }
                else
                {

                    MessageBox.Show("LÜTFEN ÖNCE  ARAÇLAR TABLOSUNDAN  ARAÇ SEÇİNİZ !!! ");
                }
            }
            else
            {
                MessageBox.Show("LÜTFEN ÖNCE  ARAÇLAR TABLOSUNDAN  ARAÇ SEÇİNİZ !!! ");
            }

          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IPTALETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sira = dgwAracListesi.CurrentRow;
            

            if (dgwAracListesi.Columns.Count == 16)
            {
                Musteriler[] mymusterler = _musterilerService.GetCustomerssByCarId(Convert.ToInt32(sira.Cells[0].Value)).ToArray();
                Musteriler[] mymusterler2 = mymusterler.OrderByDescending(m => m.Id).ToArray();

                

                if (dgwAracListesi.Rows.Count>0 )
                {
                   
                    Musteriler mymuster = _musterilerService.GetLastCustomerByCarId(Convert.ToInt32(sira.Cells[0].Value));// ----->>>>>>>ARAÇ İPTALINDE BUNU KULLANIYORUZ SON MUŞTERİ ID  İÇİN  !!!

                   // Musteriler mymusterson = mymusterler2[0];// ----->>>>>>> ŞU ANKİ  MÜŞTERİYİ SILMEK İÇİN BU !!!
                    Musteriler mymusterson = _musterilerService.GetCustomerssByCarId(Convert.ToInt32(sira.Cells[0].Value)).Last();
                   

                    AracListesi mycar = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));


                    if (mycar.IsRent == false && mycar.IsReserved == false)
                    {
                        MessageBox.Show("ARAC  ZATEN  BOŞTA  !!!");

                    }

                    //AracListesi aracim = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));


                    else if (mycar.IsRent == true && mycar.IsReserved == true)
                    {
                        MessageBox.Show("ARAÇ ŞU AN  TAMİR / BAKIMDA LÜTFEN UYGUN BİR ARAÇ SEÇİNİZ !! ");

                    }

                    else 
                    {

                        try
                        {

                            _araclistesiService.Update(new AracListesi
                            {
                                Id = mycar.Id,

                                KategoriId = mycar.KategoriId,
                                Marka = mycar.Marka,
                                Model = mycar.Model,
                                Yil = mycar.Yil,
                                BirimFiat = mycar.BirimFiat,
                                Plaka = mycar.Plaka,
                                Km=mycar.Km,
                                KiraTipID=mycar.KiraTipID,
                                KiralamaTarihi =RandomDay(),
                                KiralamaBitisTarihi =DateTime.Now,// RandomDay(),// Convert.ToDateTime("01.01.2000"),
                                SonMusteryId = mymuster.Id,

                                Aciklama = mycar.Aciklama +
                                "  OTOKİRALAMA//REZERVASYON İPTAL EDİLDİ !!-->"+ Convert.ToDateTime(DateTime.Now),
                                IsRent = false,
                                IsReserved = false,
                                IsActive = true

                            }

                           );

                            _musterilerService.Update(new Musteriler
                            {
                                Id = mymusterson.Id,
                                AracId = mymusterson.AracId,
                                Ad = mymusterson.Ad,
                                Soyad = mymusterson.Soyad,
                                TCNo = Convert.ToInt32(mymusterson.TCNo),
                                DogumTarihi = mymusterson.DogumTarihi,
                                KiraTipi=mymusterson.KiraTipi,
                                Adres = mymusterson.Adres,
                                Telefon = Convert.ToInt32(mymusterson.Telefon),
                                KiralamaTarihi = mymusterson.KiralamaTarihi,
                                KiralamaBitisTarihi = mymusterson.KiralamaBitisTarihi,

                                Aciklama = mymusterson.Aciklama +
                                "  OTOKİRALAMA//REZERVASYON İPTAL EDİLDİ !!--> " + Convert.ToDateTime(DateTime.Now),
                                IsaActive = false
                            }


                           );

                            MessageBox.Show("MÜŞTERİ SATIŞ / REZERVASYON İŞLEMİ İPTAL EDİLDİ  !!");
                            Button mybutton = btnAraçlar;


                            btnAraçlar.PerformClick();

                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }

                    }
                                      
                }
                else
                {
                    MessageBox.Show("LÜTFEN BİR ARAÇ SEÇİNİZ !!");
                }

               
            }
            else if(Convert.ToInt32(dgwAracListesi.Tag)==2)//(dgwAracListesi.Columns.Count == 13 && sira.Cells[5].Value.GetType()==typeof(long))
            {

                 Musteriler mymuster = _musterilerService.GetMusteriById(Convert.ToInt32(sira.Cells[0].Value));


                Musteriler[] mymusterler = _musterilerService.GetCustomerssByCarId(Convert.ToInt32(sira.Cells[1].Value)).ToArray();
                Musteriler[] mymusterler2 = mymusterler.OrderByDescending(m => m.Id).ToArray();

                Musteriler mymuster2 = _musterilerService.GetLastCustomerByCarId(Convert.ToInt32(sira.Cells[0].Value));



                AracListesi mycar = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value));


                if (mymuster.KiralamaBitisTarihi>DateTime.Now || mycar.KiralamaBitisTarihi==mymuster.KiralamaBitisTarihi && mycar.IsActive==true)
                {

                    try
                    {
                        _araclistesiService.Update(new AracListesi
                        {
                            Id = mycar.Id,

                            KategoriId = mycar.KategoriId,
                            Marka = mycar.Marka,
                            Model = mycar.Model,
                            Yil = mycar.Yil,
                            BirimFiat = mycar.BirimFiat,
                            Plaka = mycar.Plaka,
                            Km=mycar.Km,
                            KiraTipID=mycar.KiraTipID,
                            KiralamaTarihi = RandomDay(),
                            KiralamaBitisTarihi = DateTime.Now,
                            SonMusteryId = mymuster2.Id,
                            Aciklama = mycar.Aciklama+ "   OTOKİRALAMA//REZERVASYON İPTAL EDİLDİ !!--> " + Convert.ToDateTime(DateTime.Now),
                            IsRent = false,
                            IsReserved = false,
                            IsActive = true
                            
                        }

                       );

                        _musterilerService.Update(new Musteriler
                        {
                            Id = mymuster.Id,
                            AracId = mymuster.AracId,
                            Ad = mymuster.Ad,
                            Soyad = mymuster.Soyad,
                            TCNo = Convert.ToInt32(mymuster.TCNo),
                            DogumTarihi=mymuster.DogumTarihi,
                            KiraTipi=mymuster.KiraTipi,
                            Adres = mymuster.Adres,
                            Telefon = Convert.ToInt32(mymuster.Telefon),
                            KiralamaTarihi = mymuster.KiralamaTarihi,
                            KiralamaBitisTarihi = mymuster.KiralamaBitisTarihi,

                            Aciklama = mymuster.Aciklama + " + OTOKİRALAMA//REZERVASYON İPTAL EDİLDİ!! --> " + Convert.ToDateTime(DateTime.Now),
                            IsaActive = false
                        }

                       );

                        MessageBox.Show("MÜŞTERİ OTOKİRALAMA // REZERVASYON İŞLEMİ İPTAL EDİLDİ  !!");
                        Button mybutton = btnMusteriler;


                        btnMusteriler.PerformClick();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("LÜTFEN LİSTEDEN KİRADA  YADA  REZERVASYONLU BİR MÜŞTERİ SEÇİNİZ !!");
                }
            }

            else if   (Convert.ToInt32(dgwAracListesi.Tag) == 3) //(dgwAracListesi.Columns.Count == 13  && sira.Cells[5].Value.GetType() != typeof(long))
            {
                int idMusteri = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value);
                int idCar= Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[2].Value);
                Kasa kasam = _kasaService.GetOneKasaBillByCarIdAndCustomerId(idCar,idMusteri);

                try
                {
                    _kasaService.Update(new Kasa
                    {
                        Id=kasam.Id,
                        MusteriId=kasam.MusteriId,
                        AracNo=kasam.AracNo,
                        BirimFiyat= kasam.BirimFiyat,
                        TumBorc= kasam.TumBorc,
                        IndirimMiktari= kasam.IndirimMiktari,
                        OdemeMiktari= kasam.OdemeMiktari,
                        KalanUcret= kasam.KalanUcret,
                        OdemeTipi= kasam.OdemeTipi,
                        OdemeTarihi= kasam.OdemeTarihi,
                        DierKasaIslemi= kasam.DierKasaIslemi,
                        Aciklama= kasam.Aciklama + " KASADA  SİLME /  İPTAL İŞLEMİ YAPILDI !!--> "+Convert.ToDateTime(DateTime.Now),
                        IsActive= false

                    }

               );
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show(" KASA İŞLEMİ İPTAL EDİLDİ !!");
            }
        }
        
        private void tamireBakimaAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
          var  sira = dgwAracListesi.CurrentRow;

            if (dgwAracListesi.Rows.Count>0)
            {

                if (sira.Cells.Count == 16)
                {
                    AracListesi mycar = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));

                    

                    if (mycar.IsRent == false && mycar.IsReserved == false)
                    {

                        try
                        {
                            _araclistesiService.Update(new AracListesi
                            {
                                Id = mycar.Id,

                                KategoriId = mycar.KategoriId,
                                Marka = mycar.Marka,
                                Model = mycar.Model,
                                Yil = mycar.Yil,
                                BirimFiat = mycar.BirimFiat,
                                Plaka = mycar.Plaka,
                                Km=mycar.Km,
                                KiraTipID=mycar.KiraTipID,

                                KiralamaTarihi =RandomDay(),
                                KiralamaBitisTarihi = RandomDay2(),
                                SonMusteryId = mycar.SonMusteryId,
                                Aciklama = mycar.Aciklama + "   ARAÇ BAKIMA / TAMİRATA  ALINDI  !!---" + Convert.ToString(DateTime.Now),
                                IsRent = true,
                                IsReserved = true,
                                IsActive = true

                            }

                             );


                            AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById((Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value)));


                            _aracDetaylarService.Update(new AracDetaylar
                            {
                                ID = aracDetaycar.ID,
                                AracNO = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value),
                                Marka = txtMarka.Text,
                                Model = txtModel.Text,
                                Yil = Convert.ToInt32(txtYil.Text),
                                Renk = aracDetaycar.Renk,
                                Km = Convert.ToInt32(mskedTextKm.Text),
                                KategoriId = Convert.ToInt32(cmbAracTip2.SelectedValue),
                                MotorTipi = aracDetaycar.MotorTipi,
                                BeygirGucu = aracDetaycar.BeygirGucu,
                                VitesTipi = aracDetaycar.VitesTipi,
                                YakitTipi = aracDetaycar.YakitTipi,
                                Plaka = txtPlaka.Text,
                                SaseNo = aracDetaycar.SaseNo,
                                BakimKm = aracDetaycar.BakimKm,
                                LastikTam = aracDetaycar.LastikTam,
                                MtvOdendi = aracDetaycar.MtvOdendi,
                                MuayeneVar = aracDetaycar.MuayeneVar,
                                MuayeneBitisTarihi = aracDetaycar.MuayeneBitisTarihi,
                                SigortaVar = aracDetaycar.SigortaVar,
                                SigortaBitisTarihi = aracDetaycar.SigortaBitisTarihi,
                                KaskoVar = aracDetaycar.KaskoVar,
                                KaskoBitisTarihi = aracDetaycar.KaskoBitisTarihi,
                                BakimlarTam = aracDetaycar.BakimlarTam,

                                AracBakimVeTamirdeDegil = false,
                                TamirBitisTarihi = DateTime.Today.AddDays(3),
                                Aciklama = txtAracAciklama.Text,
                                //  IsActive = true

                            }

                            );





                            MessageBox.Show(" ARAÇ BAŞARIYLA  TAMİRATA /BAKIMA  ALINDI  !!\n\n  ARAÇ TAMİR  DÖNÜŞ TARİHİ OTOMATİK  OLARAK  3 GÜN  SONRAYA  ALINDI !!");
                            ListAllAraclar();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }

                    }
                    else if (mycar.IsRent == true && mycar.IsReserved == true)
                    {
                        MessageBox.Show("ARAÇ ZATEN TAMİR / BAKIM DURUNDA  !!");
                    }
                    else 
                    {
                        MessageBox.Show("LÜTFEN ÖNCE  ARAÇLAR TABLOSUNDAN  BOŞTAKİ BİR ARACI SEÇİNİZ \n YADA ARACIN KİRALİK/REZERVE DURUMUNU  İPTAL EDİNİZ !!! ");
                    }
                }
                else
                {

                    MessageBox.Show("LÜTFEN ÖNCE  ARAÇLAR TABLOSUNDAN  BOŞTAKİ BİR ARACI SEÇİNİZ \n YADA ARACIN KİRALİK/REZERVE DURUMUNU  İPTAL EDİNİZ !!! ");
                }

            }
            else
            {
                MessageBox.Show("LÜTFEN ÖNCE  ARAÇLAR TABLOSUNDAN  BOŞTAKİ BİR ARACI SEÇİNİZ \n YADA ARACIN KİRALİK/REZERVE DURUMUNU  İPTAL EDİNİZ !!! ");
            }

        }

        private DateTime RandomDay2()
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

        private void detayGosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sira = dgwAracListesi.CurrentRow;

            if (dgwAracListesi.Rows.Count > 0 && sira.Cells.Count == 16&&AracDetayiId>0)
            {
               
                    AracListesi mycar = _araclistesiService.GetCarById(Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value));
                      

                            MessageBox.Show(mycar.Aciklama+ "  Son muşteryID : "+Convert.ToString(mycar.SonMusteryId));


                AracDetaylarFormu form = new AracDetaylarFormu();
                this.Hide();
               
                form.Show();

            }
            else
            {
                MessageBox.Show("LÜTFEN ÖNCE  ARAÇLAR TABLOSUNDAN  ARAÇ SEÇİNİZ !!! ");

            }
           

        }

        private void btnUyari_Click(object sender, EventArgs e)
        {
            if (AracDetayiId<1)
            {
                MessageBox.Show("LÜTFEN ARAÇLAR  TABLOSUNDAN  BİR ARAÇ  SEÇİNİZ !!!");
            }
            else
            {

              AracDetaylarFormu newForm = new AracDetaylarFormu();

            this.Hide();
            newForm.ShowDialog();
            }

           
        }

        private void dgwAracListesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
             btnAracDelete2.PerformClick();
            //Button carDeleteButton = new Button();
            //carDeleteButton =
        }

        private void cmbKiraTipMus_SelectedIndexChanged(object sender, EventArgs e)
        {
           // cmbKiraTipCar.SelectedValue = cmbKiraTipMus.SelectedValue;
        }

        private void dtpAracKiralamaTarh_ValueChanged(object sender, EventArgs e)
        {
            dtpAracKiraTime2.Value = dtpAracKiralamaTarh.Value;
        }

        private void dtpAracKiraBitis_ValueChanged(object sender, EventArgs e)
        {
           dtpAracKiraBitisDate2.Value = dtpAracKiraBitis.Value;
        }

        private void cmbKiraTipMus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbKiraTipCar.SelectedValue = cmbKiraTipMus.SelectedValue;
        }
    }
}
