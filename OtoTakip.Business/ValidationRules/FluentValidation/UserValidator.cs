using FluentValidation;
using OtoTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoTakip.Business.ValidationRules.FluentValidation
{
  public  class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.PersonelAdi).NotEmpty().WithMessage("PERSONEL İSMİ BOŞ OLAMAZ!!");
            RuleFor(a => a.PersonelSoyadi).NotEmpty().WithMessage("PERSONEL SOY İSMİ BOŞ OLAMAZ!!");
            RuleFor(a => a.UserName).NotEmpty().WithMessage("USERNAME BOŞ OLAMAZ!!");
            RuleFor(a => a.Password).NotEmpty().WithMessage("ŞİFRE YERİ BOŞ OLAMAZ!!");
        }
    }
}
