using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kayit_Program.Entities
{
   public class Kategoriler
    {
        [Key]
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public bool IsActive { get; set; }


    }
}
