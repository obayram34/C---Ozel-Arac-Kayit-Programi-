using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtoTakip.Entities.Concrete;

namespace OtoTakip.Business.Abstract
{
    public interface IAracDetaylarService
    {
        void Update(AracDetaylar aracDetaylar);
        AracDetaylar GetCarById(int carId);
        void Add(AracDetaylar aracDetaylar);
        List<AracDetaylar> GetAllDetailCars();
        List<AracDetaylar> GetAlllAracListesisByPlaka(string text);
    }
}
