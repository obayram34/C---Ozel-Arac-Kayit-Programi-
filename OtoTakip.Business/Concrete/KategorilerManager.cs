using Arac_Kayit_Program.Entities;
using OtoTakip.Business.Abstract;
using OtoTakip.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.Concrete
{
    public class KategorilerManager : IKategorilerService
    {
        private IKategorilerDAL _kategorilerDAL;
        public KategorilerManager(IKategorilerDAL kategorilerDAL)
        {
            _kategorilerDAL = kategorilerDAL;
        }

        public List<Kategoriler> GetAlllAracListesis()
        {
            return _kategorilerDAL.GetAll();
        }

        public Kategoriler GetSelectedKategoryById(int id)
        {
           return _kategorilerDAL.GetAll().SingleOrDefault(m=>m.KategoriId==id);
        }
    }
}
