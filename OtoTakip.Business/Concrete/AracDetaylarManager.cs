using OtoTakip.Business.Abstract;
using OtoTakip.DataAccess.Abstract;
using OtoTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.Concrete
{
   public class AracDetaylarManager :IAracDetaylarService
    {
        private IAracDetaylarDAL _aracDetaylarDAL;

        public AracDetaylarManager(IAracDetaylarDAL aracDetaylarDAL)
        {
            _aracDetaylarDAL = aracDetaylarDAL;
        }

        public void Add(AracDetaylar aracDetaylar)
        {
            _aracDetaylarDAL.AddToAracListesis(aracDetaylar);
        }

        public List<AracDetaylar> GetAllDetailCars()
        {
            return _aracDetaylarDAL.GetAll().ToList();
        }

        public AracDetaylar GetCarById(int carNo)
        {
          //  AracDetaylar detaycar = _aracDetaylarDAL.GetAll().SingleOrDefault(a => a.AracNO == carNo);
            if (true)
            {

            }
            return _aracDetaylarDAL.GetAll().SingleOrDefault(a => a.AracNO == carNo);
        }

        public void Update(AracDetaylar aracDetaylar)
        {
            _aracDetaylarDAL.UpdateAracListesis(aracDetaylar);
        }

        public List<AracDetaylar> GetAlllAracListesisByPlaka(string text)
        {

            return _aracDetaylarDAL.GetAll(z => z.Plaka.ToLower().Contains(text.Trim().ToLower()));

        }
    }
}
