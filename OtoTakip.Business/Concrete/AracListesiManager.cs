using Arac_Kayit_Program.Entities;
using FluentValidation;
using OtoTakip.Business.Abstract;
using OtoTakip.Business.Utilities;
using OtoTakip.Business.ValidationRules.FluentValidation;
using OtoTakip.DataAccess.Abstract;
using OtoTakip.DataAccess.Concrete;
using OtoTakip.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.Concrete.EntityFramework
{
   public class AracListesiManager : IAracListesiService
    {
        private IAraclistesiDAL _araclistesiDAL;

        public AracListesiManager(IAraclistesiDAL araclistesiDAL)
        {
            _araclistesiDAL = araclistesiDAL;
        }

        public void Add(AracListesi aracListesi)
        {


            aracListesi.IsRent = false;
            ValidationTool.Validate(new AraclarValidatorAdd(), aracListesi);

          
            _araclistesiDAL.AddToAracListesis(aracListesi);
        }

        public void Update(AracListesi aracListesi)
        {
            ValidationTool.Validate(new AraclarValidatorUpdate(), aracListesi);

            _araclistesiDAL.UpdateAracListesis(aracListesi);

        }


        public void Delete(AracListesi aracListesi)
        {
            throw new NotImplementedException();
        }

        public List<AracListesi> GetAlllAracListesis()
        {
            //Busines  Layer Codes HERE !
          
            return _araclistesiDAL.GetAll();

        }

        public int  GetOneAracListesisByPlaka(string text)
        {
            int sayi;
            sayi= _araclistesiDAL.GetAll(z=>z.Plaka.ToLower().Contains(text.ToLower().Trim())).Count;
            return sayi;
        }

        public List<AracListesi> GetAlllAracListesisByPlaka(string text)
        {

            return  _araclistesiDAL.GetAll(z => z.Plaka.ToLower().Contains(text.Trim().ToLower()));
             
        }

        public List<AracListesi> GetAlllByKategorisAracListesis(int kategoriId)
        {
            return _araclistesiDAL.GetAll(p => p.KategoriId == kategoriId);
        }

        public List<AracListesi> GetAlllReadyCars()
        {
           return _araclistesiDAL.GetAll(m=>m.IsRent==false & m.IsActive==true);
        }

        public AracListesi GetCarById(int v)
        {
            return _araclistesiDAL.GetAll().SingleOrDefault(m=>m.Id==v);
	    }

        public bool CheckCarNumber(int v)
        {
            bool result = false;
           
            List<AracListesi> cars = _araclistesiDAL.GetAll(m => m.IsActive == true).ToList();
            string[] carNos = new string[cars.Count];

            if (cars!=null)
            {
                for (int i = 0; i < cars.Count; i++)
                {
                    foreach (AracListesi car in cars)
                    {
                        if (carNos.Contains(Convert.ToString(car.Id)) == false)
                        {
                            carNos[i] = Convert.ToString(car.Id);
                        }

                    }

                }

            }
          
           
            if (carNos.Contains(Convert.ToString(v)) == true)
            {
                result = true;
            }

            return result;

        }
      
        public AracListesi GetNextBigIdCar(int carId)
        {
            AracListesi nextCar= _araclistesiDAL.GetAll(c => c.Id > carId && c.IsActive == true).FirstOrDefault();
            if (nextCar==null)
            {
                return _araclistesiDAL.GetAll(c => c.Id == carId).SingleOrDefault();
            }
            return _araclistesiDAL.GetAll(c => c.Id > carId && c.IsActive == true).FirstOrDefault();
        }

        public AracListesi GetNextBigReadyCarId(int carId, int carTip)
        {
            AracListesi nextCar = _araclistesiDAL.GetAll(c => c.Id > carId && c.IsRent == false && c.IsReserved == false && c.IsActive == true&&c.KategoriId==carTip).FirstOrDefault();

            if (nextCar == null)
            {
                return _araclistesiDAL.GetAll(c => c.Id == carId).SingleOrDefault();
            }
            return _araclistesiDAL.GetAll(c => c.Id > carId && c.IsRent == false && c.IsReserved == false&&c.IsActive==true && c.KategoriId == carTip).FirstOrDefault();
        }


        public AracListesi GetPreviousBigId(int carId)
        {
            AracListesi nextCar = _araclistesiDAL.GetAll(c => c.Id < carId && c.IsActive == true).LastOrDefault();
            if (nextCar == null)
            {
                return _araclistesiDAL.GetAll(c => c.Id == carId).SingleOrDefault();
            }
            return _araclistesiDAL.GetAll(c => c.Id < carId && c.IsActive == true).LastOrDefault();
        }

        public AracListesi GetPreviousBigReadyCarId(int carId, int carTip)
        {
            AracListesi nextCar = _araclistesiDAL.GetAll(c => c.Id < carId && c.IsActive == true && c.IsRent == false && c.IsReserved == false && c.KategoriId == carTip).LastOrDefault();
            if (nextCar == null)
            {
                return _araclistesiDAL.GetAll(c => c.Id == carId).SingleOrDefault();
            }
            return _araclistesiDAL.GetAll(c => c.Id < carId && c.IsActive == true && c.IsRent == false && c.IsReserved == false&&c.KategoriId==carTip).LastOrDefault();
        }





        //public List<Musteriler> GetCustomerssByCarId(int v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
