using Arac_Kayit_Program.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.Abstract
{
   public interface IKategorilerService
    {
        List<Kategoriler> GetAlllAracListesis();
        Kategoriler GetSelectedKategoryById(int id);
    }
}
