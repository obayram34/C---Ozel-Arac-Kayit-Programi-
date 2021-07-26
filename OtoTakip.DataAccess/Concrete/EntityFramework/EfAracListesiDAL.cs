using Arac_Kayit_Program.Entities;
using OtoTakip.DataAccess.Abstract;
using OtoTakip.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.DataAccess.Concrete.EntityFramework
{
  public  class EfAracListesiDAL :EfEntityRepositoryBase<AracListesi,ARABALARContext> ,IAraclistesiDAL
    {
        //public List<AracListesi> GetAllAracListesis()
        //{
           
        //}

        //public AracListesi GetOneAracListesis(int id)
        //{
        //    using (ARABALARContext context = new ARABALARContext())
        //    {
        //        return context.AracListesis.FirstOrDefault(m=>m.Id==id);
        //    }
        //}

        //public void  AddToAracListesis(AracListesi arac)
        //{
        //    using (ARABALARContext context = new ARABALARContext())
        //    {
        //        context.AracListesis.Add(arac);
        //        context.SaveChanges();
        //    }
        //}


        //public void UpdateAracListesis(AracListesi arac)
        //{
        //    using (ARABALARContext context = new ARABALARContext())
        //    {
        //        //return context.AracListesis.;
        //        context.SaveChanges();
        //    }
        //}


        //public void DeleteAracListesis(AracListesi arac)
        //{
        //    using (ARABALARContext context = new ARABALARContext())
        //    {
        //        //return context.AracListesis.;
        //        context.SaveChanges();
        //    }
        //}

        //public List<AracListesi> GetAllAracListesis(Expression<Func<AracListesi, bool>> filter = null)
        //{
        //    using (ARABALARContext context = new ARABALARContext())
        //    {
        //        return null;
        //    }
        //}

        //public AracListesi GetOneAracListesis(Expression<Func<AracListesi, bool>> filter)
        //{
        //    using (ARABALARContext context = new ARABALARContext())
        //    {
        //        return context.AracListesis.FirstOrDefault(filter);
        //    }
        //}
    }
}
