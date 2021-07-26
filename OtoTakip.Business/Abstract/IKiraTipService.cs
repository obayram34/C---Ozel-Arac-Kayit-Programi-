using OtoTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.Abstract
{
   
       public interface IKiraTipService
        {
            List<KiraTip> GetAlllAracListesis();
            KiraTip GetSelectedKiratipById(int id);
    }
}
