using OtoTakip.Business.Abstract;
using OtoTakip.DataAccess.Concrete.EntityFramework;
using OtoTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.Concrete
{
    public class KasaManager : IKasaService
    {
        private EfKasaDAL _efKasaDAL;
        public KasaManager(EfKasaDAL efKasaDAL)
        {
            _efKasaDAL = efKasaDAL;
        }

        public void Add(Kasa kasa)
        {
            _efKasaDAL.AddToAracListesis(kasa);
        }

        public List<Kasa> GetALLActiveBills()
        {
           return _efKasaDAL.GetAll(k => k.IsActive == true);
        }

        public List<Kasa> GetALLBills()
        {
            return _efKasaDAL.GetAll().ToList();
        }

        public List<Kasa> GetAlllMusterilerByName(string text)
        {
            throw new NotImplementedException();
        }

        public Kasa GetCountByCustomerId(int id,int carId)
        {
            
            return _efKasaDAL.GetAll(m => m.MusteriId==id && m.AracNo==carId).SingleOrDefault();
        }

        public Kasa GetCountByCustomerId(int id)
        {

            return _efKasaDAL.GetAll(m => m.MusteriId == id  ).Last();
        }

        public List<Kasa> GetCountsByCustomerId(int id)
        {
            return _efKasaDAL.GetAll(m => m.MusteriId == id).ToList();
        }

        public List<Kasa> GetKasaBillByCarIdAndCustomerId(int hesapAraciId, int hesapMusteriId)
        {
            return _efKasaDAL.GetAll(m => m.AracNo == hesapAraciId & m.MusteriId == hesapMusteriId).ToList();
        }
        public Kasa GetOneKasaBillByCarIdAndCustomerId(int hesapAraciId, int hesapMusteriId)//dikkattt patladı!!!
        {
            return _efKasaDAL.GetAll(m => m.AracNo == hesapAraciId & m.MusteriId == hesapMusteriId).SingleOrDefault();
        }
        public Kasa GetKasaBillById(int seciliKasaDetayId)
        {
            return _efKasaDAL.GetAll(m => m.Id == seciliKasaDetayId).SingleOrDefault();
        }

        public List<Kasa> GetKasaBilssByCarId(int v)
        {
            return _efKasaDAL.GetAll(m => m.AracNo == v).ToList();
        }

        public void Update(Kasa kasa)
        {
            _efKasaDAL.UpdateAracListesis( kasa);
        }

        public List<Kasa> GetLastTenBills()
        {
           return _efKasaDAL.GetAll().OrderByDescending(k=>k.Id).Take(10).ToList();
            
        }

        public List<Kasa> GetKasaBilssBetweenDates(DateTime value1, DateTime value2)
        {
            return _efKasaDAL.GetAll(k => k.OdemeTarihi <= value2 && k.OdemeTarihi >= value1 && k.IsActive == true).ToList();
        }





        //public List<Kasa> GetAlllMusterilerByName(string text)
        //{

        //   // return _efKasaDAL.GetAll((m => m.Ad.Contains(text));
        //}
    }
}
