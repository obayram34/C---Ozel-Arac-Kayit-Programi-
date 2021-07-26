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
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kayit_Program
{
    public partial class AracDetaylarFormu : Form
    {
        public AracDetaylarFormu()
        {
            InitializeComponent();

            _araclistesiService = InstanceFactory.GetInstance<IAracListesiService>();
            _kategorilerService = InstanceFactory.GetInstance<IKategorilerService>();
            _musterilerService = InstanceFactory.GetInstance<IMusterilerService>();
            _kasaService = InstanceFactory.GetInstance<IKasaService>();
            _kiraTipService = InstanceFactory.GetInstance<IKiraTipService>();
            _aracDetaylarService = InstanceFactory.GetInstance<IAracDetaylarService>();

        }

        private IKasaService _kasaService;
        private IAracListesiService _araclistesiService;
        private IKategorilerService _kategorilerService;
        private IMusterilerService _musterilerService;
        private IKiraTipService _kiraTipService;
        private IAracDetaylarService _aracDetaylarService;



        private void AracDetaylarFormu_Load(object sender, EventArgs e)
        {
            // Control.CheckForIllegalCrossThreadCalls = false;

            
            ListALLKategoriler();


            int carId = Form1.AracDetayiId;
            if (carId < 1)
            {
                carId = 1; Form1.AracDetayiId = 1;
            }


            //if (carId < 1)
            //{
            //    MessageBox.Show("LÜTFEN  ÖNCE  ARAÇLAR   TABLOSUNDAN   BİR  ARAÇ  SEÇİNİZ !!");
            //    this.Hide();
            //    Form1.Olustur.Show();
            //}

            AracListesi car = _araclistesiService.GetCarById(carId);

            List<AracListesi> allCars = _araclistesiService.GetAlllAracListesis().ToList();

            FillCarDetayListByCars2(allCars);

            FormuDoldur(carId);

            pictureBox1.Image = GetCarPicture();

            TimeCounter(dtpMuayeneBitTar, txtMuayneBitAcikla, chkBMuayene, false);
            TimeCounter(dtpSigortaBit, txtSigortBitAcikla, chkBSigortaVar, false);
            TimeCounter(dtpKaskoBit, txtKaskoBitAcikla, chkKaskoVar, false);
           
               // chkBAracTamirBakimdaDegil.Checked = false;
            TimeCounter(dtpTamirBakimBitTar, txtBakimTamirBitAcikla, chkBAracTamirBakimdaDegil, true);
           

        }

        private void FormuDoldur(int carId)
        {
            AracListesi car = _araclistesiService.GetCarById(carId);

            AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById(carId);

            txtAracNo.Text = Convert.ToString(car.Id);
            txtMarka.Text = car.Marka;
            txtModel.Text = car.Model;
            txtYil.Text = Convert.ToString(car.Yil);
            if (aracDetaycar.Renk == null)
            {
                txtRenk.Text = "KIRMIZI-BEYAZ";
            }
            txtRenk.Text = aracDetaycar.Renk;
            mskedTextKm.Text = Convert.ToString(car.Km);
            cmbAracTip2.SelectedValue = car.KategoriId;
            txtMotorTipi.Text = aracDetaycar.MotorTipi;
            txtBeygirGuc.Text = Convert.ToString(aracDetaycar.BeygirGucu);
            txtVitesTipi.Text = aracDetaycar.VitesTipi;
            txtYakitTipi.Text = aracDetaycar.YakitTipi;
            txtPlaka.Text = car.Plaka;
            txtSaseNo.Text = aracDetaycar.SaseNo;
            maskedTextBakimKm.Text = Convert.ToString(aracDetaycar.BakimKm);
            chkBLastikTam.Checked = aracDetaycar.LastikTam;
            checkBMtvOdendi.Checked = aracDetaycar.MtvOdendi;
            chkBMuayene.Checked = aracDetaycar.MuayeneVar;
            dtpMuayeneBitTar.Value = aracDetaycar.MuayeneBitisTarihi;
            chkBSigortaVar.Checked = aracDetaycar.SigortaVar;
            dtpSigortaBit.Value = aracDetaycar.SigortaBitisTarihi;
            chkKaskoVar.Checked = aracDetaycar.KaskoVar;
            dtpKaskoBit.Value = aracDetaycar.KaskoBitisTarihi;
            chkBBakimlarTam.Checked = aracDetaycar.BakimlarTam;
            chkBAracTamirBakimdaDegil.Checked = aracDetaycar.AracBakimVeTamirdeDegil;
            dtpTamirBakimBitTar.Value = aracDetaycar.TamirBitisTarihi;
            txtAracAciklama.Text = aracDetaycar.Aciklama;
        }

        private static void TimeCounter(DateTimePicker timePicker,TextBox textBox,CheckBox checkBox,bool tamirmi)
        {
          

            DateTime dt = timePicker.Value;
            TimeSpan diff = dt.Subtract(DateTime.Now);
            timePicker.CalendarForeColor = Color.Black;
            checkBox.BackColor = (checkBox.Checked == true) ?  Color.FromArgb(0, 250, 154) : Color.Pink;



            if (diff.Milliseconds > 0 &&diff.Days>10 && tamirmi==false) //&& Convert.ToBoolean(sira.Cells[11].Value) == true)
            {
                textBox.Text = Convert.ToString(diff.Days)  + "GÜN  " + Convert.ToString(diff.Hours)  + "SAAT KALDI!";
                checkBox.CheckState =CheckState.Checked;
              checkBox.BackColor = Color.FromArgb(0, 250, 154);
            }
            else if (diff.Milliseconds <= 0 &&tamirmi==false ) //&& Convert.ToBoolean(sira.Cells[11].Value) == true)
            {
                checkBox.CheckState = CheckState.Unchecked;
                textBox.ForeColor = Color.Red; 
                checkBox.BackColor = Color.Pink; timePicker.CalendarForeColor = Color.Black;
                textBox.Text = "!! " + Convert.ToString(diff.Days) + "GÜN  " + Convert.ToString(diff.Hours)  + "SAAT GEÇTİ!";
            }



           else if (diff.Milliseconds > 0 && diff.Days < 10 && tamirmi == false) //&& Convert.ToBoolean(sira.Cells[11].Value) == true)
            {
                textBox.ForeColor = Color.OrangeRed;
                checkBox.BackColor = Color.Yellow;
                textBox.Text = Convert.ToString(diff.Days) + "GÜN VE " + Convert.ToString(diff.Hours) + "SAAT KALDI!";
                checkBox.Checked = true; timePicker.CalendarForeColor = Color.Black;
                // checkBox.BackColor = Color.GreenMediumSpringGreen;
            }
           

            else  if (diff.Milliseconds > 0 && tamirmi == true) //&& Convert.ToBoolean(sira.Cells[11].Value) == true)
            {
                textBox.Text = Convert.ToString(diff.Days) + "GÜN  " + Convert.ToString(diff.Hours) + "SAAT KALDI!";
                checkBox.Text = "ARAÇ SANAYİDE !!";
                checkBox.Checked = false;
                textBox.ForeColor = Color.YellowGreen;textBox.BackColor = Color.White;
                checkBox.BackColor = Color.Pink; timePicker.CalendarForeColor = Color.Black;
                // checkBox.BackColor = Color.GreenMediumSpringGreen;
            }
            else if (diff.Milliseconds <= 0 &&diff.Days>-100 && tamirmi == true) //&& Convert.ToBoolean(sira.Cells[11].Value) == true)
            {
                checkBox.Text = "ARAÇ HALA SANAYİDE!";
                checkBox.Checked = false;
                checkBox.BackColor = Color.Pink;
                textBox.ForeColor = Color.Red;
                textBox.Text = "TAMİR!" + Convert.ToString(diff.Days) + "GÜN " + Convert.ToString(diff.Hours) + "SAAT GECİKT!";
                timePicker.CalendarForeColor = Color.Black;
            }
           


            else if (diff.Milliseconds <= 0 && diff.Days < -100 && tamirmi == true) //&& Convert.ToBoolean(sira.Cells[11].Value) == true)
            {
                timePicker.CalendarForeColor = Color.LightGreen;
                checkBox.Checked = true;
                checkBox.BackColor = Color.FromArgb(0, 250, 154);
                textBox.Text = "";//"!! " + Convert.ToString(diff.Days) + "GÜN  " + Convert.ToString(diff.Hours) + "SAAT GEÇTİ!";
                checkBox.Text = "ARAÇ AKTİF/HİMETTE!";
               
            }

            else
            {
                textBox.ForeColor = Color.DeepSkyBlue;
                checkBox.CheckState = CheckState.Checked;
               // timePicker.CalendarForeColor = Color.Black;
                textBox.Text = "";
            }
        }

        public void FillCardetailsWithNextId()
        {
           
            int carId = Convert.ToInt32(txtAracNo.Text);

            AracListesi car = _araclistesiService.GetNextBigIdCar(carId);
                    
            AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById(car.Id);

            txtAracNo.Text = Convert.ToString(car.Id);
            txtMarka.Text = car.Marka;
            txtModel.Text = car.Model;
            txtYil.Text = Convert.ToString(car.Yil);
            if (aracDetaycar.Renk == null)
            {
                txtRenk.Text = "KIRMIZI-BEYAZ";
            }
            txtRenk.Text = aracDetaycar.Renk;
            mskedTextKm.Text = Convert.ToString(car.Km);
            cmbAracTip2.SelectedValue = car.KategoriId;
            txtMotorTipi.Text = aracDetaycar.MotorTipi;
            txtBeygirGuc.Text = Convert.ToString(aracDetaycar.BeygirGucu);
            txtVitesTipi.Text = aracDetaycar.VitesTipi;
            txtYakitTipi.Text = aracDetaycar.YakitTipi;
            txtPlaka.Text = car.Plaka;
            txtSaseNo.Text = aracDetaycar.SaseNo;
            maskedTextBakimKm.Text = Convert.ToString(aracDetaycar.BakimKm);
            chkBLastikTam.Checked = aracDetaycar.LastikTam;
            checkBMtvOdendi.Checked = aracDetaycar.MtvOdendi;
            chkBMuayene.Checked = aracDetaycar.MuayeneVar;
            dtpMuayeneBitTar.Value = aracDetaycar.MuayeneBitisTarihi;
            chkBSigortaVar.Checked = aracDetaycar.SigortaVar;
            dtpSigortaBit.Value = aracDetaycar.SigortaBitisTarihi;
            chkKaskoVar.Checked = aracDetaycar.KaskoVar;
            dtpKaskoBit.Value = aracDetaycar.KaskoBitisTarihi;
            chkBBakimlarTam.Checked = aracDetaycar.BakimlarTam;
            chkBAracTamirBakimdaDegil.Checked = aracDetaycar.AracBakimVeTamirdeDegil;
            dtpTamirBakimBitTar.Value = aracDetaycar.TamirBitisTarihi;
            txtAracAciklama.Text = aracDetaycar.Aciklama;



            pictureBox1.Image = GetCarPicture();

        }

        public void FillCardetailsWithNextReadyId()
        {

            int carId = Convert.ToInt32(txtAracNo.Text);
            int carTip = Convert.ToInt32(cmbAracTip2.SelectedValue);

            AracListesi car = _araclistesiService.GetNextBigReadyCarId(carId,carTip);

            AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById(car.Id);

            txtAracNo.Text = Convert.ToString(car.Id);
            txtMarka.Text = car.Marka;
            txtModel.Text = car.Model;
            txtYil.Text = Convert.ToString(car.Yil);
            if (aracDetaycar.Renk == null)
            {
                txtRenk.Text = "KIRMIZI-BEYAZ";
            }
            txtRenk.Text = aracDetaycar.Renk;
            mskedTextKm.Text = Convert.ToString(car.Km);
            cmbAracTip2.SelectedValue = car.KategoriId;
            txtMotorTipi.Text = aracDetaycar.MotorTipi;
            txtBeygirGuc.Text = Convert.ToString(aracDetaycar.BeygirGucu);
            txtVitesTipi.Text = aracDetaycar.VitesTipi;
            txtYakitTipi.Text = aracDetaycar.YakitTipi;
            txtPlaka.Text = car.Plaka;
            txtSaseNo.Text = aracDetaycar.SaseNo;
            maskedTextBakimKm.Text = Convert.ToString(aracDetaycar.BakimKm);
            chkBLastikTam.Checked = aracDetaycar.LastikTam;
            checkBMtvOdendi.Checked = aracDetaycar.MtvOdendi;
            chkBMuayene.Checked = aracDetaycar.MuayeneVar;
            dtpMuayeneBitTar.Value = aracDetaycar.MuayeneBitisTarihi;
            chkBSigortaVar.Checked = aracDetaycar.SigortaVar;
            dtpSigortaBit.Value = aracDetaycar.SigortaBitisTarihi;
            chkKaskoVar.Checked = aracDetaycar.KaskoVar;
            dtpKaskoBit.Value = aracDetaycar.KaskoBitisTarihi;
            chkBBakimlarTam.Checked = aracDetaycar.BakimlarTam;
            chkBAracTamirBakimdaDegil.Checked = aracDetaycar.AracBakimVeTamirdeDegil;
            dtpTamirBakimBitTar.Value = aracDetaycar.TamirBitisTarihi;
            txtAracAciklama.Text = aracDetaycar.Aciklama;



            pictureBox1.Image = GetCarPicture();

        }


        public Image GetCarPicture()
        {
            string pictureCarFilePath = "C: \\Users\\bayramlar\\Desktop\\ARAÇRESİM\\";
            string pictureCarNo = txtAracNo.Text +".jpg";
           
          
          string  carpath = pictureCarFilePath + pictureCarNo;

            try
            {
                pictureBox1.Image = Image.FromFile(carpath);
                return pictureBox1.Image;
                
            }
            catch
            {

                return Image.FromFile("C: \\Users\\bayramlar\\Desktop\\ARAÇRESİM\\pert2.jpg");
            //C: \Users\bayramlar\Desktop\ARAÇRESİM    selam nab er
            }
           

            //if (pictureBox1.Image==null)
            //{
            //    return Image.FromFile("C: \\Users\\user\\Desktop\\ARAÇRESİM\\pert.jpg");

            //}
            //else
            //{
            //    return Image.FromFile(carpath);// ("C: \\Users\\user\\Desktop\\ARAÇRESİM\\pert.jpg");
            //}
        }


        public void FillCarDetayListByCars2(List<AracListesi> list)
        {

            foreach (AracListesi car in list)
            {

                AracDetaylar aracDetaylar = _aracDetaylarService.GetCarById(car.Id);
                if (aracDetaylar == null) //aracNolar.Contains(Convert.ToString(car.Id)) ==
                {

                    _aracDetaylarService.Add(new AracDetaylar
                    {

                        AracNO = car.Id,
                        Marka = car.Marka,
                        Model = car.Model,
                        Yil = car.Yil,
                        Renk = "RENK ??",
                        Km = car.Km,
                        KategoriId = car.KategoriId,
                        MotorTipi = "1.8",
                        BeygirGucu = 110,
                        VitesTipi = "MANUEL VİTES",
                        YakitTipi = "BENZİN",
                        Plaka = car.Plaka,
                        SaseNo = "AERTERTYUXZMKLL56",
                        BakimKm = 80000,
                        LastikTam = true,
                        MtvOdendi = true,
                        MuayeneVar = true,
                        MuayeneBitisTarihi = Convert.ToDateTime("01.01.2020"),
                        SigortaVar = true,
                        SigortaBitisTarihi = Convert.ToDateTime("12.12.2019"),
                        KaskoVar = true,
                        KaskoBitisTarihi = Convert.ToDateTime("11.10.2019"),
                        BakimlarTam = true,
                        AracBakimVeTamirdeDegil = false,
                        TamirBitisTarihi = Convert.ToDateTime("01.01.2000"),
                        Aciklama = "ARAÇ İYİ DURUMDA , LASTİKLER YAZ SONU DEİŞMELİ!!",
                        IsActive = car.IsActive

                    }

                     );

                    MessageBox.Show("UYARI !! TÜM  ARAÇ  DETAYLARI  EKLENDİ.   ANCAK!!!\n  EKSİK  BİLGİLER  OTOMATİK  EKLENDİ. BU  KISIMLARI  GÜNCELLEYİNİZ !!!!");
                }


                else
                {

                }
            }

        }


        public void  FillCarDetayListByCars( List<AracListesi> list)
        {
            AracListesi[] allCars = list.ToArray();// _araclistesiService.GetAlllAracListesis().ToArray();


            string[] aracNolar = new string[allCars.Count()];
            string[] aracNolarchekh = new string[allCars.Count()];
            int aracdetaycarsNumbers = _aracDetaylarService.GetAllDetailCars().Count();
           

            for (int i = 0; i < allCars.Count(); i++)
            {
                aracNolar[i] = Convert.ToString( allCars[i].Id);
            }

            bool az = true;
            if (aracdetaycarsNumbers < allCars.Count())
            {
                az = false;
            }
           
           
            
            foreach (AracListesi car in allCars)  // foreach (AracListesi car in list)
            {
                bool ekle = false;
                
                for (int i = 1; i <= allCars.Count();i++)  //foreach (AracListesi car in allCars)// for (int i = 0; i < list.Count(); i++)
                {
                    if (ekle == true )
                    {
                        aracNolarchekh[i-1] = Convert.ToString(car.Id);
                    }

                    if ( aracNolarchekh.Contains(Convert.ToString(car.Id))==false && az==false) //aracNolar.Contains(Convert.ToString(car.Id)) ==
                    {

                       
                        _aracDetaylarService.Add(new AracDetaylar
                        {

                            AracNO = car.Id,
                            Marka = car.Marka,
                            Model = car.Model,
                            Yil = car.Yil,
                            Renk = "RENK ??",
                            Km = car.Km,
                            KategoriId = car.KategoriId,
                            MotorTipi = "1.8",
                            BeygirGucu = 110,
                            VitesTipi = "MANUEL VİTES",
                            YakitTipi = "BENZİN",
                            Plaka = car.Plaka,
                            SaseNo = "AERTERTYUXZMKLL56",
                            BakimKm = 80000,
                            LastikTam = true,
                            MtvOdendi = true,
                            MuayeneVar = true,
                            MuayeneBitisTarihi = Convert.ToDateTime("01.01.2020"),
                            SigortaVar = true,
                            SigortaBitisTarihi = Convert.ToDateTime("12.12.2019"),
                            KaskoVar = true,
                            KaskoBitisTarihi = Convert.ToDateTime("11.10.2019"),
                            BakimlarTam = true,
                            AracBakimVeTamirdeDegil = false,
                            TamirBitisTarihi = Convert.ToDateTime("01.01.2000"),
                            Aciklama = "ARAÇ İYİ DURUMDA , LASTİKLER YAZ SONU DEİŞMELİ!!",
                            IsActive = car.IsActive

                        }

                        );
                       

                        aracdetaycarsNumbers = _aracDetaylarService.GetAllDetailCars().Count();

                        ekle = true;


                        if (aracdetaycarsNumbers == aracNolarchekh.Count())
                        {
                            az = true;
                        }
                    }


                  else  if (i> aracdetaycarsNumbers  && aracNolarchekh.Contains(Convert.ToString(car.Id)) == false ) //&& az ==true   aracNolar.Contains(Convert.ToString(car.Id)) ==
                    {
                         
                       
                        _aracDetaylarService.Add(new AracDetaylar
                        {

                            AracNO = car.Id,
                            Marka = car.Marka,
                            Model = car.Model,
                            Yil = car.Yil,
                            Renk = "RENK ??",
                            Km = car.Km,
                            KategoriId = car.KategoriId,
                            MotorTipi = "1.8",
                            BeygirGucu = 110,
                            VitesTipi = "MANUEL VİTES",
                            YakitTipi = "BENZİN",
                            Plaka = car.Plaka,
                            SaseNo = "AERTERTYUXZMKLL56",
                            BakimKm = 80000,
                            LastikTam = true,
                            MtvOdendi = true,
                            MuayeneVar = true,
                            MuayeneBitisTarihi = Convert.ToDateTime("01.01.2020"),
                            SigortaVar = true,
                            SigortaBitisTarihi = Convert.ToDateTime("12.12.2019"),
                            KaskoVar = true,
                            KaskoBitisTarihi = Convert.ToDateTime("11.10.2019"),
                            BakimlarTam = true,
                            AracBakimVeTamirdeDegil = false,
                            TamirBitisTarihi = Convert.ToDateTime("01.01.2000"),
                            Aciklama = "ARAÇ İYİ DURUMDA , LASTİKLER YAZ SONU DEİŞMELİ!!",
                            IsActive = car.IsActive

                        }

                        );
                      
                       
                        aracdetaycarsNumbers = _aracDetaylarService.GetAllDetailCars().Count();
                        ekle = true;


                        if (aracdetaycarsNumbers == aracNolarchekh.Count())
                        {
                            az = false;
                        }
                    }


                    else
                    {

                    }
                }
                
            }
        }

       

        private void AracDetaylarFormu_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Form1 newForm = new Form1();
           // Form1.Olustur.SH;

            this.Hide();
            Form1.Olustur.Show();
        }

        private void btnAracKaydet_Click(object sender, EventArgs e)
        {
            int carId = Form1.AracDetayiId;
            AracListesi car = _araclistesiService.GetCarById(carId);
            AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById(carId);
            try
            {
                _aracDetaylarService.Update(new AracDetaylar
                {
                    ID = aracDetaycar.ID,
                    AracNO = carId,
                    Marka = txtMarka.Text,
                    Model = txtModel.Text,
                    Yil = Convert.ToInt32(txtYil.Text),
                    Renk = txtRenk.Text,
                    Km = Convert.ToInt32(mskedTextKm.Text),
                    KategoriId = Convert.ToInt32(cmbAracTip2.SelectedValue),
                    MotorTipi = txtMotorTipi.Text,
                    BeygirGucu = Convert.ToInt32(txtBeygirGuc.Text),
                    VitesTipi = txtVitesTipi.Text,
                    YakitTipi = txtYakitTipi.Text,
                    Plaka = txtPlaka.Text,
                    SaseNo = txtSaseNo.Text,
                    BakimKm = Convert.ToInt32(maskedTextBakimKm.Text),
                    LastikTam = chkBLastikTam.Checked,
                    MtvOdendi = checkBMtvOdendi.Checked,
                    MuayeneVar = chkBMuayene.Checked,
                    MuayeneBitisTarihi = dtpMuayeneBitTar.Value,
                    SigortaVar = chkBSigortaVar.Checked,
                    SigortaBitisTarihi = dtpSigortaBit.Value,
                    KaskoVar = chkKaskoVar.Checked,
                    KaskoBitisTarihi = dtpKaskoBit.Value,
                    BakimlarTam = chkBBakimlarTam.Checked,
                    AracBakimVeTamirdeDegil = chkBAracTamirBakimdaDegil.Checked,
                    TamirBitisTarihi = dtpTamirBakimBitTar.Value,
                    Aciklama = txtAracAciklama.Text,
                    IsActive = aracDetaycar.IsActive

                }
                
                );

                MessageBox.Show("ARAÇ DETAYLARI  KAYDEDİLDİ !! ");
            }
            catch (Exception)
            {

                throw;
            }
        

        }

        private void btnAracUpdate_Click(object sender, EventArgs e)
        {

            int carId = Convert.ToInt32(txtAracNo.Text);
            AracListesi car = _araclistesiService.GetCarById(carId);
            AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById(carId);
            try
            {
                _aracDetaylarService.Update(new AracDetaylar
                {
                    ID = aracDetaycar.ID,
                    AracNO = Convert.ToInt32(txtAracNo.Text),
                    Marka = txtMarka.Text,
                    Model = txtModel.Text,
                    Yil = Convert.ToInt32(txtYil.Text),
                    Renk = txtRenk.Text,
                    Km = Convert.ToInt32(mskedTextKm.Text),
                    KategoriId = Convert.ToInt32(cmbAracTip2.SelectedValue),
                    MotorTipi = txtMotorTipi.Text,
                    BeygirGucu = Convert.ToInt32(txtBeygirGuc.Text),
                    VitesTipi = txtVitesTipi.Text,
                    YakitTipi = txtYakitTipi.Text,
                    Plaka = txtPlaka.Text,
                    SaseNo = txtSaseNo.Text,
                    BakimKm = Convert.ToInt32(maskedTextBakimKm.Text),
                    LastikTam = chkBLastikTam.Checked,
                    MtvOdendi = checkBMtvOdendi.Checked,
                    MuayeneVar = chkBMuayene.Checked,
                    MuayeneBitisTarihi = dtpMuayeneBitTar.Value,
                    SigortaVar = chkBSigortaVar.Checked,
                    SigortaBitisTarihi = dtpSigortaBit.Value,
                    KaskoVar = chkKaskoVar.Checked,
                    KaskoBitisTarihi = dtpKaskoBit.Value,
                    BakimlarTam = chkBBakimlarTam.Checked,
                    AracBakimVeTamirdeDegil = chkBAracTamirBakimdaDegil.Checked,
                    TamirBitisTarihi = dtpTamirBakimBitTar.Value,
                    Aciklama = txtAracAciklama.Text,
                    IsActive = true

                }

                );

                MessageBox.Show("ARAÇ DETAYLARI  GÜNCELLENDİ!! ");
            }
            catch (Exception)
            {

                throw;
            }
        

        }

        private void btnAracDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BU ARACI  SİLMEK ÜZERESİNİZ  ONAY VERİYORMUSUNUZ !!!!", "DİKKAT  !!", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);


            if (this.DialogResult == DialogResult.Yes)
            {
                int carId = Form1.AracDetayiId;
                AracListesi arac = _araclistesiService.GetCarById(carId);
                Musteriler musteriler = _musterilerService.GetLastCustomerByCarId(arac.Id);
                AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById(carId);
                try
                {
                    _aracDetaylarService.Update(new AracDetaylar
                    {
                        ID=aracDetaycar.ID,
                        AracNO = Convert.ToInt32(txtAracNo.Text),
                        Marka = txtMarka.Text,
                        Model = txtModel.Text,
                        Yil = Convert.ToInt32(txtYil.Text),
                        Renk = txtRenk.Text,
                        Km = Convert.ToInt32(mskedTextKm.Text),
                        KategoriId = Convert.ToInt32(cmbAracTip2.SelectedValue),
                        MotorTipi = txtMotorTipi.Text,
                        BeygirGucu= Convert.ToInt32(txtBeygirGuc.Text),
                        VitesTipi = txtVitesTipi.Text,
                        YakitTipi = txtYakitTipi.Text,
                        Plaka = txtPlaka.Text,
                        SaseNo = txtSaseNo.Text,
                        BakimKm = Convert.ToInt32(maskedTextBakimKm.Text),
                        LastikTam = chkBLastikTam.Checked,
                        MtvOdendi = checkBMtvOdendi.Checked,
                        MuayeneVar = chkBMuayene.Checked,
                        MuayeneBitisTarihi = dtpMuayeneBitTar.Value,
                        SigortaVar = chkBSigortaVar.Checked,
                        SigortaBitisTarihi = dtpSigortaBit.Value,
                        KaskoVar = chkKaskoVar.Checked,
                        KaskoBitisTarihi = dtpKaskoBit.Value,
                        BakimlarTam = chkBBakimlarTam.Checked,
                        AracBakimVeTamirdeDegil = chkBAracTamirBakimdaDegil.Checked,
                        TamirBitisTarihi = dtpTamirBakimBitTar.Value,
                        Aciklama = txtAracAciklama.Text,
                        IsActive = false

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


                    MessageBox.Show("ARAÇ SİLME İŞLEMİ  GERÇEKLEŞTİRİLDİ  !!! ");
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

        private void btnSililkForm_Click(object sender, EventArgs e)
        {
            //  Form1 anaform = (Form1)Application.OpenForms["Form1"];
            //  ((Form1)Application.OpenForms["Form1"]).ActivateDelete();
            Form1 f1 = (Form1)Application.OpenForms["Form1"];
            f1.ActivateDelete();

            //AracListesi arac = _araclistesiService.GetCarById(Form1.AracDetayiId);

            //    Musteriler activeMusteri = _musterilerService.GetCustomerByCarId(arac.Id, arac.KiralamaBitisTarihi);

            //    Musteriler musteriler = _musterilerService.GetLastCustomerByCarId(arac.Id);


            //    try
            //    {

            //        if (arac.IsActive == false)
            //        {
            //            MessageBox.Show("ARAÇ ZATEN SİLİNMİŞTİR !!");
            //        }

            //        else if (activeMusteri != null && activeMusteri.KiralamaBitisTarihi > DateTime.Now && arac.IsRent == true || arac.IsReserved == true)
            //        {

            //            _musterilerService.Update(new Musteriler

            //            {
            //                Id = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[0].Value),
            //                AracId = Convert.ToInt32(dgwAracListesi.CurrentRow.Cells[1].Value),
            //                Ad = txtAd.Text,
            //                Soyad = txtSoyad.Text,
            //                TCNo = Convert.ToInt32(txtTcno.Text),
            //                DogumTarihi = Convert.ToDateTime(dgwAracListesi.CurrentRow.Cells[11].Value),
            //                KiraTipi = Convert.ToString(dgwAracListesi.CurrentRow.Cells[10].Value),
            //                Adres = txtAdres.Text,
            //                Telefon = Convert.ToInt32(txtTel.Text),
            //                KiralamaTarihi = dtpAracKiralamaTarh.Value,
            //                KiralamaBitisTarihi = dtpAracKiraBitis.Value,
            //                Aciklama = txtAciklama.Text + "--MÜŞTERİ SİLİNDİ " + "->" + Convert.ToString(DateTime.Now),
            //                IsaActive = false
            //            }
            //          );

            //            _araclistesiService.Update(new AracListesi

            //            {
            //                Id = arac.Id,
            //                KategoriId = arac.KategoriId,
            //                KiraTipID = arac.KiraTipID,
            //                Km = arac.Km,
            //                Marka = arac.Marka,
            //                Model = arac.Model,
            //                Yil = arac.Yil,
            //                BirimFiat = arac.BirimFiat,
            //                Plaka = arac.Plaka,

            //                KiralamaTarihi = RandomDay(),
            //                KiralamaBitisTarihi = DateTime.Now,
            //                SonMusteryId = musteriler.Id,
            //                Aciklama = arac.Aciklama,
            //                IsRent = false,
            //                IsReserved = false,
            //                IsActive = false

            //            }
            //          );

            //        }
            //        else if (activeMusteri == null)
            //        {
            //            _araclistesiService.Update(new AracListesi

            //            {
            //                Id = arac.Id,
            //                KategoriId = arac.KategoriId,
            //                KiraTipID = arac.KiraTipID,
            //                Km = arac.Km,
            //                Marka = arac.Marka,
            //                Model = arac.Model,
            //                Yil = arac.Yil,
            //                BirimFiat = arac.BirimFiat,
            //                Plaka = arac.Plaka,

            //                KiralamaTarihi = RandomDay(),
            //                KiralamaBitisTarihi = DateTime.Now,
            //                SonMusteryId = musteriler.Id,
            //                Aciklama = arac.Aciklama,
            //                IsRent = false,
            //                IsReserved = false,
            //                IsActive = false

            //            }
            //          );


            //        }


            //    }
            //    catch (Exception ex)
            //    {

            //        MessageBox.Show(ex.Message);

            //    }

            //    MessageBox.Show("SİLME   İŞLEMİ  BAŞARILI  !!!!");
                          
        }
        private void ListALLKategoriler()
        {
            

            cmbAracTip2.DataSource = _kategorilerService.GetAlllAracListesis();
            cmbAracTip2.ValueMember = "KategoriId";
            cmbAracTip2.DisplayMember = "KategoriAdi";



        }
        private void cmbAracTip2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSonrakiArac_Click(object sender, EventArgs e)
        {
            txtBakimTamirBitAcikla.ForeColor = Color.MidnightBlue;
            txtKaskoBitAcikla.ForeColor = Color.MidnightBlue;
            txtSigortBitAcikla.ForeColor = Color.MidnightBlue;
            txtMuayneBitAcikla.ForeColor = Color.MidnightBlue;

            txtBakimTamirBitAcikla.Text = "";
            txtKaskoBitAcikla.Text = "";
            txtSigortBitAcikla.Text = "";
            txtMuayneBitAcikla.Text = "";
           // chkBAracTamirBakimdaDegil.BackColor = Color.DarkSeaGreen;

            if (rdbBosAraclar.Checked==true)
            {
                FillCardetailsWithNextReadyId();
            }
            else
            {

              FillCardetailsWithNextId();
            
            }

            FormuDoldur(Convert.ToInt32(txtAracNo.Text));

            TimeCounter(dtpMuayeneBitTar, txtMuayneBitAcikla, chkBMuayene, false);
            TimeCounter(dtpSigortaBit, txtSigortBitAcikla, chkBSigortaVar, false);
            TimeCounter(dtpKaskoBit, txtKaskoBitAcikla, chkKaskoVar, false);
            
                //chkBAracTamirBakimdaDegil.Checked = false;
            TimeCounter(dtpTamirBakimBitTar, txtBakimTamirBitAcikla, chkBAracTamirBakimdaDegil, true);
            
        }



        public void FillCardetailsWithPreviousId()
        {
            int carId = Convert.ToInt32(txtAracNo.Text);

            AracListesi car = _araclistesiService.GetPreviousBigId(carId);

            AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById(car.Id);

            txtAracNo.Text = Convert.ToString(car.Id);
            txtMarka.Text = car.Marka;
            txtModel.Text = car.Model;
            txtYil.Text = Convert.ToString(car.Yil);
            if (aracDetaycar.Renk == null)
            {
                txtRenk.Text = "KIRMIZI-BEYAZ";
            }
            txtRenk.Text = aracDetaycar.Renk;
            mskedTextKm.Text = Convert.ToString(car.Km);
            cmbAracTip2.SelectedValue = car.KategoriId;
            txtMotorTipi.Text = aracDetaycar.MotorTipi;
            txtBeygirGuc.Text = Convert.ToString(aracDetaycar.BeygirGucu);
            txtVitesTipi.Text = aracDetaycar.VitesTipi;
            txtYakitTipi.Text = aracDetaycar.YakitTipi;
            txtPlaka.Text = car.Plaka;
            txtSaseNo.Text = aracDetaycar.SaseNo;
            maskedTextBakimKm.Text = Convert.ToString(aracDetaycar.BakimKm);
            chkBLastikTam.Checked = aracDetaycar.LastikTam;
            checkBMtvOdendi.Checked = aracDetaycar.MtvOdendi;
            chkBMuayene.Checked = aracDetaycar.MuayeneVar;
            dtpMuayeneBitTar.Value = aracDetaycar.MuayeneBitisTarihi;
            chkBSigortaVar.Checked = aracDetaycar.SigortaVar;
            dtpSigortaBit.Value = aracDetaycar.SigortaBitisTarihi;
            chkKaskoVar.Checked = aracDetaycar.KaskoVar;
            dtpKaskoBit.Value = aracDetaycar.KaskoBitisTarihi;
            chkBBakimlarTam.Checked = aracDetaycar.BakimlarTam;
            chkBAracTamirBakimdaDegil.Checked = aracDetaycar.AracBakimVeTamirdeDegil;
            dtpTamirBakimBitTar.Value = aracDetaycar.TamirBitisTarihi;
            txtAracAciklama.Text = aracDetaycar.Aciklama;



            pictureBox1.Image = GetCarPicture();
        }

        private void btnOncekiArac_Click(object sender, EventArgs e)
        {
            txtBakimTamirBitAcikla.ForeColor = Color.MidnightBlue;
            txtKaskoBitAcikla.ForeColor = Color.MidnightBlue;
            txtSigortBitAcikla.ForeColor = Color.MidnightBlue;
            txtMuayneBitAcikla.ForeColor = Color.MidnightBlue;

            txtBakimTamirBitAcikla.Text = "";
            txtKaskoBitAcikla.Text = "";
            txtSigortBitAcikla.Text = "";
            txtMuayneBitAcikla.Text = "";
          //  chkBAracTamirBakimdaDegil.BackColor = Color.DarkSeaGreen;

            if (rdbBosAraclar.Checked == true)
            {
                FillCardetailsWithPreviousReadyCarId();
            }
            else
            {

                FillCardetailsWithPreviousId();

            }


            TimeCounter(dtpMuayeneBitTar, txtMuayneBitAcikla, chkBMuayene, false);
            TimeCounter(dtpSigortaBit, txtSigortBitAcikla, chkBSigortaVar, false);
            TimeCounter(dtpKaskoBit, txtKaskoBitAcikla, chkKaskoVar, false);
            
              //  chkBAracTamirBakimdaDegil.Checked = false;
            TimeCounter(dtpTamirBakimBitTar, txtBakimTamirBitAcikla, chkBAracTamirBakimdaDegil, true);
            


        }

        private void FillCardetailsWithPreviousReadyCarId()
        {
            int carId = Convert.ToInt32(txtAracNo.Text);
            int carTip= Convert.ToInt32(cmbAracTip2.SelectedValue);

            AracListesi car = _araclistesiService.GetPreviousBigReadyCarId(carId,carTip);

            AracDetaylar aracDetaycar = _aracDetaylarService.GetCarById(car.Id);

            txtAracNo.Text = Convert.ToString(car.Id);
            txtMarka.Text = car.Marka;
            txtModel.Text = car.Model;
            txtYil.Text = Convert.ToString(car.Yil);
            if (aracDetaycar.Renk == null)
            {
                txtRenk.Text = "KIRMIZI-BEYAZ";
            }
            txtRenk.Text = aracDetaycar.Renk;
            mskedTextKm.Text = Convert.ToString(car.Km);
            cmbAracTip2.SelectedValue = car.KategoriId;
            txtMotorTipi.Text = aracDetaycar.MotorTipi;
            txtBeygirGuc.Text = Convert.ToString(aracDetaycar.BeygirGucu);
            txtVitesTipi.Text = aracDetaycar.VitesTipi;
            txtYakitTipi.Text = aracDetaycar.YakitTipi;
            txtPlaka.Text = car.Plaka;
            txtSaseNo.Text = aracDetaycar.SaseNo;
            maskedTextBakimKm.Text = Convert.ToString(aracDetaycar.BakimKm);
            chkBLastikTam.Checked = aracDetaycar.LastikTam;
            checkBMtvOdendi.Checked = aracDetaycar.MtvOdendi;
            chkBMuayene.Checked = aracDetaycar.MuayeneVar;
            dtpMuayeneBitTar.Value = aracDetaycar.MuayeneBitisTarihi;
            chkBSigortaVar.Checked = aracDetaycar.SigortaVar;
            dtpSigortaBit.Value = aracDetaycar.SigortaBitisTarihi;
            chkKaskoVar.Checked = aracDetaycar.KaskoVar;
            dtpKaskoBit.Value = aracDetaycar.KaskoBitisTarihi;
            chkBBakimlarTam.Checked = aracDetaycar.BakimlarTam;
            chkBAracTamirBakimdaDegil.Checked = aracDetaycar.AracBakimVeTamirdeDegil;
            dtpTamirBakimBitTar.Value = aracDetaycar.TamirBitisTarihi;
            txtAracAciklama.Text = aracDetaycar.Aciklama;



            pictureBox1.Image = GetCarPicture();
        }

        private void lblUyarSay_Click(object sender, EventArgs e)
        {

        }

        private void txtBakimTamirBitAcikla_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKaskoBitAcikla_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSigortBitAcikla_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMuayneBitAcikla_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      
    }
}
