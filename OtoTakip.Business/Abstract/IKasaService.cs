using OtoTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.Abstract
{
    public interface IKasaService
    {
        List<Kasa> GetALLBills();
        List<Kasa> GetAlllMusterilerByName(string text);
        Kasa GetCountByCustomerId(int id);
        Kasa GetOneKasaBillByCarIdAndCustomerId(int hesapAraciId, int hesapMusteriId);
        //Kasa GetCountByCustomerId(int id);
        void Add(Kasa kasa);
        List<Kasa> GetALLActiveBills();
        List<Kasa> GetKasaBilssByCarId(int v);
        void Update(Kasa kasa);
        List<Kasa> GetKasaBillByCarIdAndCustomerId(int hesapAraciId, int hesapMusteriId);
        Kasa GetKasaBillById(int seciliKasaDetayId);
        List<Kasa> GetCountsByCustomerId(int v);
        List<Kasa> GetLastTenBills();
        List<Kasa> GetKasaBilssBetweenDates(DateTime value1, DateTime value2);
        //List<Kasa> GetCountsByCarId(int v);
    }
}
