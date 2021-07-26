using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arac_Kayit_Program
{
  public static  class Beklet
    {
        public static async Task Bekle(int ms)
        {
            await Task.Delay(ms);
        }

        public static async void BekletMetod()
        {

            await Bekle(800);
        }
    }
}
