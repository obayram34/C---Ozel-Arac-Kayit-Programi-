using Arac_Kayit_Program.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.Abstract
{
  public  interface IAracListesiService
    {
        List<AracListesi> GetAlllAracListesis();
        List<AracListesi> GetAlllByKategorisAracListesis(int kategoriId);
        int GetOneAracListesisByPlaka(string text);
        List<AracListesi> GetAlllAracListesisByPlaka(string text);
        void Add(AracListesi aracListesi);
        void Update(AracListesi aracListesi);
        void Delete(AracListesi aracListesi);
        List<AracListesi> GetAlllReadyCars();
       // List<Musteriler> GetCustomerssByCarId(int v);
        AracListesi GetCarById(int v);
        bool CheckCarNumber(int v);
        AracListesi GetNextBigIdCar(int carId);
        AracListesi GetPreviousBigId(int carId);
        AracListesi GetNextBigReadyCarId(int carId,int carTip);
        AracListesi GetPreviousBigReadyCarId(int carId,int carTip);
    }
}
