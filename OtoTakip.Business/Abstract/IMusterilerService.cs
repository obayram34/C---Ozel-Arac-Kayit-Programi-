using Arac_Kayit_Program.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.Abstract
{
    public interface IMusterilerService
    {
        //List<Musteriler> GetAlllAracListesis();
        //List<Musteriler> GetAlllByKategorisAracListesis(int kategoriId);
        //List<Musteriler> GetAlllAracListesisByPlaka(string text);
        void Add(Musteriler musteriler);
        void Update(Musteriler musteriler);
        void Delete(Musteriler musteriler);
        List<Musteriler> GetAlllMusterilerByName(string text);
        List<Musteriler> GetAlllMusteriler();
        List<Musteriler> GetAlllActiveMusteriler();
        Musteriler GetLastMusteriler();
        Musteriler GetCustomerByCarId(int v, DateTime dateTime);//birden fazla musteri var diye 2 parametre
        Musteriler GetCustomerByCarId(int v);
        List<Musteriler> GetCustomerssByCarId(int v);
        Musteriler GetLastCustomerByCarId(int v);
        Musteriler GetMusteriById(int v);
        bool CheckCostumerNumber(int v);
    }
}
