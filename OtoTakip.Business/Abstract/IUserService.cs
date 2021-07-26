using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtoTakip.Entities.Concrete;

namespace OtoTakip.Business.Abstract
{
    public interface IUserService
    {
        User GetUser(string userName, string password);
        List<User> GetALLUsers();
         List<User> GetUserByName(string ad);
        User GetUserNameSurname(string PersonelName,string PersonelSurname);
        void UpdateUser(User user);

        bool GetBoolResultIfUserNameIsActive(string text);
        bool GetBoolResultIfUserNameIsActiveForThisUser(string text, int Id);

       bool GetBoolResultIfPersonelNameEverUsed(string textname,string textsurname);
       bool GetBoolResultIfPersonelNameIsActiveForThisUser(string textname, string textsurname, int Id);

        void AddUser(User user);
        User GetUserByUserName(string userName);
        List<User> GetAllActiveUsers();
        User GetUserById(int v);
        List<User> GetALLUsersByName(string text);
        void DeleteUser(User user);

        List<User> GetUsersTheSameNamedSurnamed(string text1, string text2);
        List<User> GetUsersTheSameUserNamed(string text);
    }
}
