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
    public partial class UserAddUpdateForm : Form
    {
        public UserAddUpdateForm()
        {
            InitializeComponent();
            _araclistesiService = InstanceFactory.GetInstance<IAracListesiService>();
            _kategorilerService = InstanceFactory.GetInstance<IKategorilerService>();
            _musterilerService = InstanceFactory.GetInstance<IMusterilerService>();
            _kasaService = InstanceFactory.GetInstance<IKasaService>();
            _kiraTipService = InstanceFactory.GetInstance<IKiraTipService>();
            _aracDetaylarService = InstanceFactory.GetInstance<IAracDetaylarService>();
            _userService= InstanceFactory.GetInstance<IUserService>();

        }

        private IUserService _userService;
        private IKasaService _kasaService;
        private IAracListesiService _araclistesiService;
        private IKategorilerService _kategorilerService;
        private IMusterilerService _musterilerService;
        private IKiraTipService _kiraTipService;
        private IAracDetaylarService _aracDetaylarService;

        private void UserAddUpdateForm_Load(object sender, EventArgs e)
        {
            ListAvtiveUserrs();
            dgwUsers.Rows[0].Selected = true;
        //    MessageBox.Show(Convert.ToString(dgwUsers.CurrentRow.Cells[3].Value));
        }

        private void ListAvtiveUserrs()
        {
            dgwUsers.DataSource = _userService.GetAllActiveUsers().Where(m => m.IsActive == true).ToList();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //dgwUsers.DataSource = _userService.GetUserByName(txtSearch.Text);
            dgwUsers.DataSource = _userService.GetALLUsersByName(txtSearch.Text);
            if (string.IsNullOrEmpty( txtSearch.Text))
            {
                dgwUsers.DataSource = _userService.GetALLUsers();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {


            User kayitliUser =_userService.GetUserNameSurname(txtPersonelName.Text,txtPersonelSurname.Text);

            bool IsUserNameUsed = _userService.GetBoolResultIfUserNameIsActive(txtUserName.Text);

            //if (3>2)
            ///*(dgwAracListesi.CurrentRow.Cells[5].ValueType == typeof(decimal))*/
            //{               


            if (kayitliUser != null)
            {


                    MessageBox.Show("BU  İSİM  VE SOYADLI  KULLANICI  ZATEN   VARDIR !\n LÜTFEN  İSİM  SOYİSİM  BİLGİLERİNİ  KONTROL  EDİNİZ !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (IsUserNameUsed == true)
            {
                MessageBox.Show("BU  KULLANICI  ADI  ZATEN   VARDIR !\n LÜTFEN  ' 'KULLANICI  ADI  ''NI DEĞİŞTİRİNİZ !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                {

                    try
                    {

                    _userService.AddUser(new User
                    {

                        PersonelAdi = txtPersonelName.Text,
                        PersonelSoyadi = txtPersonelSurname.Text,
                        
                        UserName = txtUserName.Text,
                        Password = txtPassword.Text,
                        UyelikTarihi = GetSubmitDay(txtSubmitDay.Text), // Convert.ToDateTime(txtSubmitDay.Text),                         
                        Aciklama = txtExplanation.Text,

                        IsActive = true
                        }

                       );

                       
                       MessageBox.Show("KULLANICI  EKLEME  İŞLEMİ   BAŞARILI  !!!!");
                    ListAvtiveUserrs();
                }
                    catch (Exception )
                    {

                      throw;
                    }

                }

            //}
            //else
            //{
            //    MessageBox.Show("LÜTFEN ÖNCE MÜŞTERİ BİLGİLERİNİ GİRİNİZ SONRA DA ARAÇLAR MENÜSÜNDEN YEŞİL RENKLİ BOŞTAKİ ARAÇLARDAN BİRİNİ SEÇİNİZ !!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

        }

        private DateTime GetSubmitDay(string text)
        {
            DateTime submittime;
            try
            {
                submittime= Convert.ToDateTime(txtSubmitDay.Text);
                return submittime;
            }
            catch 
            {

                submittime = DateTime.Now; return submittime;
            }
           
        }


        public static int checkUserNameIdIfUsed;
        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            User kayitliUser = _userService.GetUserById(Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value));

            List<User> usersTheSameNamedSurnamed = _userService.GetUsersTheSameNamedSurnamed(txtPersonelName.Text, txtPersonelSurname.Text);

            List<User> usersTheSameUserNamed = _userService.GetUsersTheSameUserNamed(txtUserName.Text);

            User adminUser = _userService.GetUserByUserName("Admin");

            bool IsUserNameUsed = _userService.GetBoolResultIfUserNameIsActive(txtUserName.Text);

            bool PersonelNameEverUsed = _userService.GetBoolResultIfPersonelNameEverUsed(txtPersonelName.Text, txtPersonelSurname.Text);
            bool PersonelNameIsActiveForThisUser = _userService.GetBoolResultIfPersonelNameIsActiveForThisUser(txtPersonelName.Text, txtPersonelSurname.Text, Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value));


            bool isUserNameUsedByThis = _userService.GetBoolResultIfUserNameIsActiveForThisUser(txtUserName.Text, Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value));
            bool isUserNameEverUsed = _userService.GetBoolResultIfUserNameIsActive(txtUserName.Text);



            if (kayitliUser == null)
            {
                MessageBox.Show("LÜTFEN TABLODAN BİR KULLANICI SEÇİNİZ !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (kayitliUser.ID == adminUser.ID && (PersonelNameEverUsed == false || PersonelNameIsActiveForThisUser == true))
            {
                txtUserName.Text = "Admin";
                // txtUserName.ReadOnly = true;

                try
                {

                    _userService.UpdateUser(new User
                    {
                        ID = kayitliUser.ID,
                        PersonelAdi = txtPersonelName.Text,
                        PersonelSoyadi = txtPersonelSurname.Text,
                        UserName = "Admin",
                        Password = txtPassword.Text,
                        UyelikTarihi = GetSubmitDay(txtSubmitDay.Text),
                        Aciklama = txtExplanation.Text,

                        IsActive = true
                    }

                    );


                    MessageBox.Show("KULLANICI  GÜNCELLEME  İŞLEMİ   BAŞARILI  !!!!");
                    ListAvtiveUserrs();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }



            }


            else if (kayitliUser.ID != adminUser.ID && ((PersonelNameEverUsed == false || PersonelNameIsActiveForThisUser == true) && (IsUserNameUsed == false || isUserNameUsedByThis == true)))
            {

                try
                {

                    _userService.UpdateUser(new User
                    {
                        ID = kayitliUser.ID,
                        PersonelAdi = txtPersonelName.Text,
                        PersonelSoyadi = txtPersonelSurname.Text,
                        UserName = txtUserName.Text,
                        Password = txtPassword.Text,
                        UyelikTarihi = GetSubmitDay(txtSubmitDay.Text),
                        Aciklama = txtExplanation.Text,

                        IsActive = true
                    }

                    );


                    MessageBox.Show("KULLANICI  GÜNCELLEME  İŞLEMİ   BAŞARILI  !!!!");
                    ListAvtiveUserrs();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else
            {
                MessageBox.Show("BU  KULLANICI  ADI - SOYADI  YADA  USERNAME   ZATEN   VARDIR !\n LÜTFEN  ' 'KULLANICI  ADI  ''NI VE ' 'USERNAME  ''I  KONTROL EDİNİZ   !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




            #region oldGuncelle

            //User kayitliUser = _userService.GetUserByUserName(Convert.ToString(dgwUsers.CurrentRow.Cells[3].Value));

            //User adminUser = _userService.GetUserByUserName("Admin");

            //User NameSurnameuser = _userService.GetUserNameSurname(txtPersonelName.Text, txtPersonelSurname.Text);
            //User NameSurnameuserBeingUpdated = _userService.GetUserNameSurname(Convert.ToString(dgwUsers.CurrentRow.Cells[1].Value), Convert.ToString(dgwUsers.CurrentRow.Cells[2].Value));

            //User userBeingUpdated = _userService.GetUserById(Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value));

            //User userUsedUserName = _userService.GetUserByUserName(txtUserName.Text);

            //checkUserNameIdIfUsed = Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value);

            //bool isUserNameUsedByThis = _userService.GetBoolResultIfUserNameIsActiveForThisUser(txtUserName.Text, Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value));
            //bool isUserEverUsed = _userService.GetBoolResultIfUserNameIsActive(txtUserName.Text);

            //bool isUserNameSurnameUsedByThis = _userService.GetBoolResultIfPersonelNameIsActiveForThisUser(txtPersonelName.Text, txtPersonelSurname.Text, Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value));


            //if (NameSurnameuser == null)
            //{
            //    NameSurnameuser = new User { ID = 0, PersonelAdi = "bos", PersonelSoyadi = "bos", UserName = "boss", Password = "000", UyelikTarihi = DateTime.Now, Aciklama = "..", IsActive = true };

            //}



            //else if (kayitliUser == null)
            //{
            //    MessageBox.Show("LÜTFEN TABLODAN BİR KULLANICI SEÇİNİZ !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

            //else if (kayitliUser.ID == adminUser.ID)
            //{
            //    txtUserName.Text = "Admin";
            //    // txtUserName.ReadOnly = true;

            //    try
            //    {

            //        _userService.UpdateUser(new User
            //        {
            //            ID = adminUser.ID,
            //            PersonelAdi = txtPersonelName.Text,
            //            PersonelSoyadi = txtPersonelSurname.Text,
            //            UserName = "Admin",
            //            Password = txtPassword.Text,
            //            UyelikTarihi = GetSubmitDay(txtSubmitDay.Text),
            //            Aciklama = txtExplanation.Text,

            //            IsActive = true
            //        }

            //        );


            //        MessageBox.Show("KULLANICI  GÜNCELLEME  İŞLEMİ   BAŞARILI  !!!!");
            //        ListAvtiveUserrs();
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }



            //}


            //else if (userBeingUpdated.ID != adminUser.ID && NameSurnameuserBeingUpdated.ID == NameSurnameuser.ID && isUserNameUsedByThis == true)
            //{

            //    try
            //    {

            //        _userService.UpdateUser(new User
            //        {
            //            ID = userBeingUpdated.ID,
            //            PersonelAdi = txtPersonelName.Text,
            //            PersonelSoyadi = txtPersonelSurname.Text,
            //            UserName = txtUserName.Text,
            //            Password = txtPassword.Text,
            //            UyelikTarihi = GetSubmitDay(txtSubmitDay.Text),
            //            Aciklama = txtExplanation.Text,

            //            IsActive = true
            //        }

            //        );


            //        MessageBox.Show("KULLANICI  GÜNCELLEME  İŞLEMİ   BAŞARILI  !!!!");
            //        ListAvtiveUserrs();
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }



            //}


            //else if (userBeingUpdated.ID != adminUser.ID && NameSurnameuserBeingUpdated.ID == NameSurnameuser.ID && isUserNameUsedByThis == false && isUserEverUsed == false)
            //{

            //    User kayitliUserim = _userService.GetUserNameSurname(txtPersonelName.Text, txtPersonelSurname.Text);


            //    try
            //    {

            //        _userService.UpdateUser(new User
            //        {
            //            ID = userBeingUpdated.ID,
            //            PersonelAdi = txtPersonelName.Text,
            //            PersonelSoyadi = txtPersonelSurname.Text,
            //            UserName = txtUserName.Text,
            //            Password = txtPassword.Text,
            //            UyelikTarihi = GetSubmitDay(txtSubmitDay.Text),
            //            Aciklama = txtExplanation.Text,

            //            IsActive = true
            //        }

            //        );

            //        MessageBox.Show("KULLANICI  GÜNCELLEME  İŞLEMİ   BAŞARILI  !!!!");
            //        ListAvtiveUserrs();


            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //        //try
            //        //{
            //        //    _userService.DeleteUser( new User { ID=userBeingUpdated.ID});
            //        //}
            //        //catch (Exception)
            //        //{

            //        //    throw;
            //        //}



            //        //MessageBox.Show("BU  KULLANICI  ADI  ZATEN   VARDIR !\n LÜTFEN  ' 'KULLANICI  ADI  ''NI DEĞİŞTİRİNİZ !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        //throw;

            //    }


            //}

            //else if (userBeingUpdated.ID != adminUser.ID && NameSurnameuserBeingUpdated.ID != NameSurnameuser.ID || isUserNameUsedByThis == false && isUserEverUsed == true)
            //{


            //    MessageBox.Show("BU  KULLANICI  ADI  ZATEN   VARDIR !\n LÜTFEN  ' 'KULLANICI  ADI  ''NI DEĞİŞTİRİNİZ !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            //    //try
            //    //{

            //    //    _userService.UpdateUser(new User
            //    //    {
            //    //        ID = userBeingUpdated.ID,
            //    //        PersonelAdi = txtPersonelName.Text,
            //    //        PersonelSoyadi = txtPersonelSurname.Text,
            //    //        UserName = txtUserName.Text,
            //    //        Password = txtPassword.Text,
            //    //        UyelikTarihi = GetSubmitDay(txtSubmitDay.Text),
            //    //        Aciklama = txtExplanation.Text,

            //    //        IsActive = true
            //    //    }

            //    //    );


            //    //    MessageBox.Show("KULLANICI  GÜNCELLEME  İŞLEMİ   BAŞARILI  !!!!");
            //    //    ListAvtiveUserrs();
            //    //}
            //    //catch (Exception)
            //    //{

            //    //    throw;
            //    //}

            //}
            //else //if ( kayitliUser != NameSurnameuser)//IsUserNameUsed == true &&
            //{
            //    MessageBox.Show("BU  KULLANICI  ADI  ZATEN   VARDIR !\n LÜTFEN  ' 'KULLANICI  ADI  ''NI DEĞİŞTİRİNİZ !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //} 
            #endregion

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            string userName =Convert.ToString( dgwUsers.CurrentRow.Cells[3].Value);
            int sayi = dgwUsers.CurrentRow.Cells.Count;

            User AdminUser = _userService.GetUserByUserName("Admin");
            User userToDelete = _userService.GetUserByUserName(userName);

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("LÜTFEN  KULLANICILAR  TABLOSUNDAN  ADMİN  HARİCİNDE  BİR  KULLANICI  SEÇİNİZ !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (userName== "Admin")
            {
                MessageBox.Show(" ''ADMİN''  ASIL YÖNETİCİDİR  SİLEMEZSİNİZ !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {

                try
                {

                    _userService.UpdateUser(new User
                    {
                        ID = userToDelete.ID,
                        PersonelAdi = userToDelete.PersonelAdi,
                        PersonelSoyadi = userToDelete.PersonelSoyadi,
                        UserName = userToDelete.UserName,
                        Password = userToDelete.Password,
                        UyelikTarihi = userToDelete.UyelikTarihi,
                        Aciklama = userToDelete.Aciklama,

                        IsActive = false
                    }

                    );


                    MessageBox.Show("KULLANICI SİLME  İŞLEMİ   BAŞARILI  !!!!");
                    ListAvtiveUserrs();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        private void dgwUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            User user =_userService.GetUserById( Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value));

            if (user!=null && Convert.ToString(dgwUsers.CurrentRow.Cells[3].Value) == "Admin")
            {
                
                txtPersonelName.Text = user.PersonelAdi;
                txtPersonelSurname.Text = user.PersonelSoyadi;

                txtUserName.Text = "Admin";
                txtUserName.ReadOnly = true;

                txtPassword.Text = user.Password;
                txtSubmitDay.Text =Convert.ToString( user.UyelikTarihi);
                txtExplanation.Text = user.Aciklama;
            }
           
            else if (user != null && Convert.ToString(dgwUsers.CurrentRow.Cells[3].Value) != "Admin")
            {

                txtUserName.ReadOnly = false;
                txtPersonelName.Text = user.PersonelAdi;
                txtPersonelSurname.Text = user.PersonelSoyadi;

                txtUserName.Text = user.UserName;
               

                txtPassword.Text = user.Password;
                txtSubmitDay.Text = Convert.ToString(user.UyelikTarihi);
                txtExplanation.Text = user.Aciklama;


                //txtUserName.ReadOnly = false;
                //if (user.ID == 1 || txtUserName.Text == "Admin")
                //{
                //    txtUserName.Text = "Admin";
                //    txtUserName.ReadOnly = true;
                //}
                //else if (user.ID != 1 || txtUserName.Text != "Admin")
                //{
                //    txtUserName.Text = user.UserName;
                //    txtUserName.ReadOnly = false;
                //}
            }
            else
            {

            }
                      
        }


        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

           // User kayitliUser = _userService.GetUserByUserName(Convert.ToString(dgwUsers.CurrentRow.Cells[3].Value));

           // User adminUser = _userService.GetUserByUserName("Admin");

           // bool IsUserNameUsed = _userService.GetBoolResultIfUserNameIsActive(txtUserName.Text);

           // if (kayitliUser!=null && adminUser!=null&& kayitliUser == adminUser)
           // {
           //     txtUserName.Text = "Admin";
           //     //txtUserName.Enabled = false;

           // }
           ////else if (IsUserNameUsed == true)
           //// {
           ////     MessageBox.Show("BU  KULLANICI  ADI  ZATEN   VARDIR !\n LÜTFEN  ' 'KULLANICI  ADI  ''NI DEĞİŞTİRİNİZ !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           //// }
           

           // else
           // {

                

           // }
        }


        private void UserAddUpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.Olustur.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTime.Checked==true)
            {
                numericUpDown1.Visible = true;
                 lblTime.Visible = true;
            }
            else
            {
                numericUpDown1.Visible = false;
                lblTime.Visible = false;
            }
        }

        private void sİLToolStripMenuItem_Click(object sender, EventArgs e)
        {
           User currentkullanici = _userService.GetUserById(Convert.ToInt32( dgwUsers.CurrentRow.Cells[0].Value));

            DialogResult dialogResult = MessageBox.Show("AD            :     "+currentkullanici.PersonelAdi + "\n" + "SOYAD        :    " + currentkullanici.PersonelSoyadi+ "\n"  +"USERNAME  :   " + currentkullanici.UserName + "\n"+ "\n" + "   BU  KULLANICIYI   SİLMEK ÜZERESİNİZ  ONAY VERİYORMUSUNUZ !!!!", "DİKKAT  !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


            if (dialogResult == DialogResult.Yes)
            {
                btnDelete.PerformClick();
            }
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                _userService.DeleteUser( new User
                {
                    ID = Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value)
                }

                );


                MessageBox.Show("KULLANICI SİLME  İŞLEMİ   BAŞARILI  !!!!");
                ListAvtiveUserrs();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          

            User kayitliUser = _userService.GetUserById(Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value));

            List<User> usersTheSameNamedSurnamed = _userService.GetUsersTheSameNamedSurnamed(txtPersonelName.Text, txtPersonelSurname.Text);

            List<User> usersTheSameUserNamed = _userService.GetUsersTheSameUserNamed(txtUserName.Text);

            User adminUser = _userService.GetUserByUserName("Admin");

            bool IsUserNameUsed = _userService.GetBoolResultIfUserNameIsActive(txtUserName.Text);

            bool PersonelNameEverUsed=  _userService.GetBoolResultIfPersonelNameEverUsed(txtPersonelName.Text, txtPersonelSurname.Text);
            bool PersonelNameIsActiveForThisUser= _userService.GetBoolResultIfPersonelNameIsActiveForThisUser(txtPersonelName.Text, txtPersonelSurname.Text, Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value));


            bool isUserNameUsedByThis = _userService.GetBoolResultIfUserNameIsActiveForThisUser(txtUserName.Text, Convert.ToInt32(dgwUsers.CurrentRow.Cells[0].Value));
            bool isUserNameEverUsed = _userService.GetBoolResultIfUserNameIsActive(txtUserName.Text);



            if (kayitliUser == null)
            {
                MessageBox.Show("LÜTFEN TABLODAN BİR KULLANICI SEÇİNİZ !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (kayitliUser.ID == adminUser.ID&&( PersonelNameEverUsed==false|| PersonelNameIsActiveForThisUser==true))
            {
                txtUserName.Text = "Admin";
                // txtUserName.ReadOnly = true;

                try
                {

                    _userService.UpdateUser(new User
                    {
                        ID = kayitliUser.ID,
                        PersonelAdi = txtPersonelName.Text,
                        PersonelSoyadi = txtPersonelSurname.Text,
                        UserName = "Admin",
                        Password = txtPassword.Text,
                        UyelikTarihi = GetSubmitDay(txtSubmitDay.Text),
                        Aciklama = txtExplanation.Text,

                        IsActive = true
                    }

                    );


                    MessageBox.Show("KULLANICI  GÜNCELLEME  İŞLEMİ   BAŞARILI  !!!!");
                    ListAvtiveUserrs();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }



            }


            else if (kayitliUser.ID != adminUser.ID &&( (PersonelNameEverUsed == false || PersonelNameIsActiveForThisUser == true)&&(IsUserNameUsed==false||isUserNameUsedByThis==true)))
            {

                try
                {

                    _userService.UpdateUser(new User
                    {
                        ID = kayitliUser.ID,
                        PersonelAdi = txtPersonelName.Text,
                        PersonelSoyadi = txtPersonelSurname.Text,
                        UserName =txtUserName.Text,
                        Password = txtPassword.Text,
                        UyelikTarihi = GetSubmitDay(txtSubmitDay.Text),
                        Aciklama = txtExplanation.Text,

                        IsActive = true
                    }

                    );


                    MessageBox.Show("KULLANICI  GÜNCELLEME  İŞLEMİ   BAŞARILI  !!!!");
                    ListAvtiveUserrs();
                }
                catch (Exception)
                {

                    throw;
                }

            }
            else 
            {
                MessageBox.Show("BU  KULLANICI  ADI - SOYADI  YADA  USERNAME   ZATEN   VARDIR !\n LÜTFEN  ' 'KULLANICI  ADI  ''NI VE ' 'USERNAME  ''I  KONTROL EDİNİZ   !!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
          
        }

    }
}
