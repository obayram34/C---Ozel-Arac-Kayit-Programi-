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
    public class KiraTipsManager : IKiraTipService
    {

        private IKiraTipDAL _kiraTipDAL;
        public KiraTipsManager(IKiraTipDAL kiraTipDAL)
        {
            _kiraTipDAL = kiraTipDAL;
        }  


        public List<KiraTip> GetAlllAracListesis()
        {
            return _kiraTipDAL.GetAll();
        }

        public KiraTip GetSelectedKiratipById(int id)
        {
            return _kiraTipDAL.GetAll().SingleOrDefault(m => m.ID == id);
        }

       
    }
}
