using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<BaseUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("İsim Soyisim Boş Geçilemez");
            RuleFor(x => x.NameSurname).MinimumLength(5).WithMessage("İsim Soyisim Alanı En Az 5 Karakter olmalıdır.");
            RuleFor(x => x.NameSurname).MaximumLength(100).WithMessage("İsim Soyisim Alanı En Fazla 100 Karakter olmalıdır.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("Kullanıcı Adı Alanı En Az 5 Karakter olmalıdır.");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Kullanıcı Adı Alanı En Fazla 50 Karakter olmalıdır.");
            RuleFor(x => x.EMail).NotEmpty().WithMessage("Email Boş Geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Şifre Alanı En Az 8 Karakter olmalıdır.");
            RuleFor(x => x.Password).MaximumLength(50).WithMessage("Şifre Alanı En Fazla 50 Karakter olmalıdır.");
            RuleFor(x => x.Password).Matches(@"[A-Z]+").WithMessage("Şifrede En Az Bir Büyük Karakter olmalıdır");
            RuleFor(x => x.Password).Matches(@"[a-z]+").WithMessage("Şifrede En Az Bir Küçük Karakter olmalıdır");
            RuleFor(x => x.Password).Matches(@"[0-9]").WithMessage("Şifrede En Az Bir Rakam olmalıdır");

        }
    }
}
