using Arac_Kayit_Program.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.ValidationRules.FluentValidation
{
    public class MusterilerValidatorUpdate : AbstractValidator<Musteriler>
    {

        public MusterilerValidatorUpdate()
        {
            RuleFor(a => a.Ad).NotEmpty().WithMessage(" İSİM BOŞ OLAMAZ!!");
            RuleFor(a => a.Soyad).NotEmpty().WithMessage("SOYAD  BOŞ OLAMAZ!!");
            RuleFor(a => a.TCNo).NotEmpty().WithMessage("TC BOŞ OLAMAZ!!");
            RuleFor(a => a.Telefon).NotEmpty().WithMessage("TELEFON YERİ BOŞ OLAMAZ!!");
            RuleFor(a => a.Adres).NotEmpty().WithMessage("ADRES İSMİ BOŞ OLAMAZ!!");
            RuleFor(a => a.AracId).NotEmpty().WithMessage("ARACID YERİ BOŞ OLAMAZ, ARAÇ SEÇİNİZ !!");


            //RuleFor(a => a.KiralamaTarihi).GreaterThanOrEqualTo(DateTime.Now).WithMessage("KiralamaTarihi GEÇMİŞ TARİH OLAMAZ !!");
            //RuleFor(a => a.KiralamaBitisTarihi).GreaterThan(DateTime.Now).WithMessage("KiralamaBitisTarihi GEÇMİŞ TARİH OLAMAZ !!");

            RuleFor(a => a.KiralamaBitisTarihi).GreaterThan(a => a.KiralamaTarihi).WithMessage("KiralamaTarihi  ÖNCE, bitiş tarihi sonra  olmalı !!");

            RuleFor(a => a.KiralamaBitisTarihi).NotEmpty().WithMessage("BİTİŞ TARİH YERİ BOŞ OLAMAZ!!");

            //  RuleFor(a => a.IsRent).Must(CarMustBeReady).WithMessage("BU ARAÇ ZATEN KİRALANMIŞTIR !!") ;
            // RuleFor(a => a.Ad).NotEqual(a=>a.Ad.co).WithMessage("BU ARAÇ ZATEN KİRALANMIŞTIR !!");

            //RuleFor(a => a.Plaka).Must(StartsWith34).WithMessage("PLAKALAR 34  OLMALIDIR  !! !!"); ;

        }



        //private bool StartsWith34(string arg)
        //{
        //    return arg.StartsWith("34");
        //}

    }

}
