using Arac_Kayit_Program.Entities;
using OtoTakip.DataAccess.Abstract;
using OtoTakip.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.DataAccess.Concrete.EntityFramework
{
   public class EfMusterilerDAL :EfEntityRepositoryBase<Musteriler,ARABALARContext>, IMusterilerDAL
    { 

    }
}
