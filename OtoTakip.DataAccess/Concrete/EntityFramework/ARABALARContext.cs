using Arac_Kayit_Program.Entities;
using OtoTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.DataAccess.EntityFramework
{
   public class ARABALARContext : DbContext
    {
        public DbSet<AracListesi> AracListesis { get; set; }
        public DbSet<Kategoriler> Kategorilers { get; set; }
        public DbSet<Musteriler> Musterilers { get; set; }
        public DbSet<Kasa> Kasas { get; set; }
        public DbSet<KiraTip> KiraTips { get; set; }
        public DbSet<AracDetaylar> AracDetaylars { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
