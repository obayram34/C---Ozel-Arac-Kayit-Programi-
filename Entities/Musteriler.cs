using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kayit_Program.Entities
{
   public class Musteriler
    {
        public int Id { get; set; }
        public int AracId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Telefon { get; set; }
        public int TCNo { get; set; }
        public string Adres { get; set; }
       
        public int HesapId { get; set; }
        public string Aciklama { get; set; }
        public bool IsaActive { get; set; }
    }
}
