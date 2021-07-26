using Arac_Kayit_Program.Entities;
using OtoTakip.Business.Abstract;
using OtoTakip.Business.Utilities;
using OtoTakip.Business.ValidationRules.FluentValidation;
using OtoTakip.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.Concrete
{
  public  class MusterilerManager:IMusterilerService
    {
        private IMusterilerDAL _musterilerDAL;

        public MusterilerManager(IMusterilerDAL musterilerDAL)
        {
            _musterilerDAL = musterilerDAL;
        }

        public void Add(Musteriler musteriler)
        {
            ValidationTool.Validate(new MusterilerValidator(), musteriler);

            _musterilerDAL.AddToAracListesis(musteriler);
        }

        public void Delete(Musteriler musteriler)
        {
            _musterilerDAL.UpdateAracListesis(musteriler);
        }

        public List<Musteriler> GetAlllMusteriler()
        {
            return _musterilerDAL.GetAll();
            
        }

        public Musteriler GetLastMusteriler()
        {
            Musteriler mus = new Musteriler();
            mus = _musterilerDAL.GetAll().Last();
            return mus;
        }

        public Musteriler GetMusteriById(int v)
        {
           
            return _musterilerDAL.GetOneAracListesis(m=>m.Id==v);
        }


        public List<Musteriler> GetAlllMusterilerByName(string text)
        {
          return  _musterilerDAL.GetAll(m => m.Ad.Contains(text));
        }

        public void Update(Musteriler musteriler)
        {
            ValidationTool.Validate(new MusterilerValidatorUpdate(), musteriler);

            _musterilerDAL.UpdateAracListesis( musteriler);
        }

        public Musteriler GetCustomerByCarId(int v,DateTime dateTime)
        {

                return _musterilerDAL.GetAll().SingleOrDefault(m => m.AracId == v&& m.KiralamaBitisTarihi == dateTime);

        }


        public Musteriler GetCustomerByCarId(int v)
        {
            return _musterilerDAL.GetAll().SingleOrDefault(m=>m.Id==v);
        }



        public List<Musteriler> GetAlllActiveMusteriler()
        {
            return _musterilerDAL.GetAll(m => m.IsaActive == true).ToList();
        }

        public List<Musteriler> GetCustomerssByCarId(int v)
        {


             return _musterilerDAL.GetAll(m => m.AracId == v);
            
                     
        }

        public Musteriler GetLastCustomerByCarId(int v)
        {
            Musteriler sonMusterim = new Musteriler();
            Musteriler[] mymusterler = _musterilerDAL.GetAll(m=>m.AracId==v).ToArray();
           
            Musteriler[] mymusterler2 = mymusterler.OrderByDescending(m => m.Id).ToArray();
            try
            {
                if (mymusterler2.Count() > 1)
                {
                    sonMusterim = mymusterler2[1];
                }
                else if (mymusterler2.Count() == 1)
                {
                    sonMusterim = mymusterler2[0];
                }
            }
            catch 
            {

                sonMusterim = _musterilerDAL.GetAll(m => m.Id == 1).SingleOrDefault();
            }
            sonMusterim = _musterilerDAL.GetAll(m => m.Id == 1).SingleOrDefault();
            return sonMusterim;
        }

        public bool CheckCostumerNumber(int v)
        {
            bool result = false;

            List<Musteriler> customers = _musterilerDAL.GetAll().ToList();//AKTİFMI OLSAYDI???
            string[] musNos = new string[customers.Count];

            if (customers != null)
            {
                for (int i = 0; i < customers.Count; i++)
                {
                    foreach (Musteriler muster in customers)
                    {
                        if (musNos.Contains(Convert.ToString(muster.Id)) == false)
                        {
                            musNos[i] = Convert.ToString(muster.Id);
                        }

                    }

                }

            }


            if (musNos.Contains(Convert.ToString(v)) == true)
            {
                result = true;
            }

            return result;

        }


    }
}
