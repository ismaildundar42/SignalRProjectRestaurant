using DtoLayer.BookingDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alanı numarası boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı alanı boş geçilemez!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez!");


            RuleFor(x => x.Name).MinimumLength(5).WithMessage("İsim alanı minimum 5 karakter olmalıdır!").MaximumLength(50).WithMessage("İsim alanı maximum 50 karakter olmalıdır!");


            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz!");
        }
    }
}
