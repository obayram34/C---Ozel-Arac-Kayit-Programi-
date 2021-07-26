using OtoTakip.Business.Abstract;
using OtoTakip.Business.Utilities;
using OtoTakip.Business.ValidationRules.FluentValidation;
using OtoTakip.DataAccess.Abstract;
using OtoTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.Concrete
{
   public class UserManager :IUserService
    {
        private IUserDAL _userDAL;

        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public void UpdateUser(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);

            _userDAL.UpdateAracListesis(user);
        }

        public List<User> GetALLUsers()
        {
            return _userDAL.GetAll().ToList() ;
        }

        public User GetUser( string userName,string password)
        {
            return _userDAL.GetOneAracListesis(u => u.UserName == userName && u.Password == password && u.IsActive == true);
        }

        public List<User> GetUserByName(string ad)
        {
            return _userDAL.GetAll(u => u.PersonelAdi.Contains(ad) && u.IsActive == true);
           // _musterilerDAL.GetAll(m => m.Ad.Contains(text));
        }

        public bool GetBoolResultIfUserNameIsActiveForThisUser(string text,int Id)
        {
           
            User userUsedUserName = _userDAL.GetAll(u => u.UserName.Equals(text) && u.IsActive == true&&u.ID==Id).SingleOrDefault();
           
         
            if (userUsedUserName==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public User GetUserNameSurname(string PersonelName, string PersonelSurname)
        {
            return _userDAL.GetOneAracListesis(u => u.PersonelAdi == PersonelName && u.PersonelSoyadi == PersonelSurname&&u.IsActive==true);
        }

        public void AddUser(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);
            _userDAL.AddToAracListesis(user);
        }

        public User GetUserByUserName(string userName)
        {
            return _userDAL.GetAll(u => u.UserName.Equals(userName)&& u.IsActive==true).SingleOrDefault() ;
        }

        public List<User> GetAllActiveUsers()
        {
            return _userDAL.GetAll(u => u.IsActive==true);
        }

        public User GetUserById(int v)
        {
            return _userDAL.GetAll(u => u.ID == v && u.IsActive == true).SingleOrDefault();
        }

        public List<User> GetALLUsersByName(string text)
        {
            return _userDAL.GetAll(u => u.PersonelAdi.Contains(text)).ToList() ;
           // return _userDAL.GetAll(u => u.PersonelAdi.Contains(ad) && u.IsActive == true);
        }

        public void DeleteUser(User user)
        {
            _userDAL.DeleteAracListesis(user);
        }

        public bool GetBoolResultIfUserNameIsActive(string text)
        {
            User userUsedUserName = _userDAL.GetAll(u => u.UserName.Equals(text) && u.IsActive == true).SingleOrDefault();


            //int userIsBeingId=
            //User userChesckUser = _userDAL.GetOneAracListesis(u => u.ID==Id);

            //foreach (User user in userList)
            //{

            //}

            if (userUsedUserName == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool GetBoolResultIfPersonelNameEverUsed(string textname, string textsurname)
        {
            User userEverUsedUserNameSurnameBefore = _userDAL.GetAll(u => u.PersonelAdi.Equals(textname) && u.IsActive == true && u.PersonelSoyadi.Equals(textsurname)).SingleOrDefault();


            if (userEverUsedUserNameSurnameBefore == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool GetBoolResultIfPersonelNameIsActiveForThisUser(string textname, string textsurname, int Id)
        {
            User userUsedUserNameSurname = _userDAL.GetAll(u => u.PersonelAdi.Equals(textname) && u.IsActive == true && u.PersonelSoyadi.Equals(textsurname) && u.ID==Id).SingleOrDefault();


            if (userUsedUserNameSurname == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<User> GetUsersTheSameNamedSurnamed(string textname, string textsurname)
        {
            return _userDAL.GetAll(u => u.UserName.Equals(textname) && u.IsActive == true && u.UserName.Equals(textsurname)).ToList();
        }

        public List<User> GetUsersTheSameUserNamed(string UserName)
        {
            return _userDAL.GetAll(u => u.UserName.Equals(UserName) && u.IsActive == true).ToList() ;
        }
    }
}
