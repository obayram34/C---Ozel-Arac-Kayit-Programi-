using OtoTakip.DataAccess.Abstract;
using OtoTakip.DataAccess.EntityFramework;
using OtoTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.DataAccess.Concrete.EntityFramework
{
   public class EfUserDAL : EfEntityRepositoryBase<User, ARABALARContext>, IUserDAL
    {
    }
}
