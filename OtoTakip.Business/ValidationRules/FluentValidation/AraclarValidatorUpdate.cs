using Arac_Kayit_Program.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.ValidationRules.FluentValidation
{
   public class AraclarValidatorUpdate : AbstractValidator<AracListesi>
    {
       

        public AraclarValidatorUpdate()
        {
           

            RuleFor(a => a.Marka).NotEmpty().WithMessage("MARKA İSMİ BOŞ OLAMAZ!!");
            RuleFor(a => a.Model).NotEmpty().WithMessage("MODEL İSMİ BOŞ OLAMAZ!!");
            RuleFor(a => a.Yil).NotEmpty().WithMessage("YIL YERİ BOŞ OLAMAZ!!");
            RuleFor(a => a.Plaka).NotEmpty().WithMessage("PLAKA YERİ BOŞ OLAMAZ!!");
            RuleFor(a => a.KategoriId).NotEmpty().WithMessage("KATEGORİ İSMİ BOŞ OLAMAZ!!");

            //RuleFor(a => a.KiralamaTarihi).GreaterThanOrEqualTo(DateTime.Now).WithMessage("KiralamaTarihi GEÇMİŞ TARİH OLAMAZ !!");
            //RuleFor(a => a.KiralamaBitisTarihi).GreaterThanOrEqualTo(DateTime.Now).WithMessage("KiralamaBitisTarihi GEÇMİŞ TARİH OLAMAZ !!");

            RuleFor(a => a.KiralamaBitisTarihi).GreaterThan(a => a.KiralamaTarihi).WithMessage("KiralamaTarihi  ÖNCE, bitiş tarihi sonra  olmalı !!");

            RuleFor(a => a.KiralamaBitisTarihi).NotEmpty().WithMessage("BİTİŞ TARİH YERİ BOŞ OLAMAZ!!");
          
            RuleFor(a => a.IsRent).Must(CarMustBeReady).WithMessage("BU ARAÇ ZATEN KİRALANMIŞTIR !!");

        

        }

        private bool CarMustBeReady(bool arg)
        {
            return arg=true;
        }

       
    }
}
