using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kayit_Program.Entities
{
   public class AracListesi
    {
        public int Id { get; set; }
        public int KategoriId { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Yil { get; set; }
        public decimal BirimFiat { get; set; }
        public string Plaka { get; set; }
        public DateTime KiralamaTarihi { get; set; }
        public DateTime KiralamaBitisTarihi { get; set; }
        public int SonMusteryId { get; set; }
        public string Aciklama { get; set; }
        public bool IsActive { get; set; }

    }
}
