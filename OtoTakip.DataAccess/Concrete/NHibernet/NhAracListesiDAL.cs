using Arac_Kayit_Program.Entities;
using OtoTakip.DataAccess.Abstract;
using OtoTakip.DataAccess.Concrete.EntityFramework;
using OtoTakip.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.DataAccess.Concrete.NHibernet
{
    public class NhAracListesiDAL : IAraclistesiDAL
    {
        public void AddToAracListesis(AracListesi entitiy)
        {
            throw new NotImplementedException();
        }

        public void DeleteAracListesis(AracListesi entitiy)
        {
            throw new NotImplementedException();
        }

        public List<AracListesi> GetAll(Expression<Func<AracListesi, bool>> filter = null)
        {
            List<AracListesi> aracListesi = new List<AracListesi>
            {

                new AracListesi{Id= 4, KategoriId=1, Marka="PORSHE", Model="CAYENNE", Plaka="34ZZZ12", Yil=1984, Aciklama="nHİBERNETTEN ALMA", SonMusteryId=2, BirimFiat=500, IsActive=true}

            };
            return aracListesi;
        }

        public AracListesi GetOneAracListesis(Expression<Func<AracListesi, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void UpdateAracListesis(AracListesi entitiy)
        {
            throw new NotImplementedException();
        }
    }
}
