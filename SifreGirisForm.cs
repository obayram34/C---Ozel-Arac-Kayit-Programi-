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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arac_Kayit_Program
{
    public partial class SifreGirisForm : Form
    {
        public SifreGirisForm()
        {
            InitializeComponent();
            //_araclistesiService = InstanceFactory.GetInstance<IAracListesiService>();
            //_kategorilerService = InstanceFactory.GetInstance<IKategorilerService>();
            //_musterilerService = InstanceFactory.GetInstance<IMusterilerService>();
            //_kasaService = InstanceFactory.GetInstance<IKasaService>();
            //_kiraTipService = InstanceFactory.GetInstance<IKiraTipService>();
            //_aracDetaylarService = InstanceFactory.GetInstance<IAracDetaylarService>();
            _userService = InstanceFactory.GetInstance<IUserService>();

        }

        private IUserService _userService;
        //private IKasaService _kasaService;
        //private IAracListesiService _araclistesiService;
        //private IKategorilerService _kategorilerService;
        //private IMusterilerService _musterilerService;
        //private IKiraTipService _kiraTipService;
        //private IAracDetaylarService _aracDetaylarService;

        public static int userGirisID;

        private void SifreGirisForm_Load(object sender, EventArgs e)
        {
          //  User user = _userService.GetUser(txtKullaniciAdi.Text, txtSifre.Text);
        }

        private void btnsSifreGiris_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtKullaniciAdi.Text) ==true || string.IsNullOrEmpty(txtSifre.Text) ==true)
            {
                MessageBox.Show("LÜTFEN GEREKLİ ALANLARI DOLDURUNUZ !!");

            }
            else
            {
                User user = _userService.GetUser(txtKullaniciAdi.Text, txtSifre.Text);

                if (user==null)
                {
                    MessageBox.Show("HATALI  ŞİFRE  GİRDİNİZ , LÜTFEN  TEKRAR  DENEYİNİZZ !!!");
                   

                }
                else if(user != null)
                {
                    userGirisID = user.ID;
                    this.Hide();
                    Form1.Olustur.Show();
                }
            }
        }
       

        private void SifreGirisForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsSifreGiris.PerformClick();
            }
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsSifreGiris.PerformClick();
            }
        }

        private void txtKullaniciAdi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnsSifreGiris.PerformClick();
            }
        }

        private void btnAyarGiris_Click(object sender, EventArgs e)
        {
            //txtKullaniciAdi.Text = "Admin";

            if (string.IsNullOrEmpty(txtKullaniciAdi.Text) == true || string.IsNullOrEmpty(txtSifre.Text) == true)
            {
                MessageBox.Show("LÜTFEN GEREKLİ ALANLARI DOLDURUNUZ !!");

            }
            else
            {
                User user = _userService.GetUser("Admin", txtSifre.Text);

                if (user == null)
                {
                    MessageBox.Show("HATALI  ŞİFRE  GİRDİNİZ , LÜTFEN ADMİN GİRİŞİ  YAPINIZ !!!");


                }
                else if (user != null)
                {
                    userGirisID = user.ID;
                    

                    UserAddUpdateForm userAddUpdate = new UserAddUpdateForm();
                    this.Hide();
                    userAddUpdate.Show();
                }
            }
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            txtSifre.Text = "";
        }

        private void txtKullaniciAdi_Enter(object sender, EventArgs e)
        {
            txtKullaniciAdi.Text = "";
        }

        
    }
}
