using System;
using System.Text.RegularExpressions;
using FluentValidation;
using PPayment.Domain.DTOs;

namespace PPayment.API.Validators
{
    public class CreatePaymentValidator : AbstractValidator<PaymentDto>
    {
        public CreatePaymentValidator()
        {
            RuleFor(c => c.CardNumber).NotEmpty().CreditCard();
            
            RuleFor(c => c.CardHolder).NotEmpty();

            RuleFor(c => c.ExpirationDate).Must(DateValidate).WithMessage("credit card is expired");

            RuleFor(c => c.SecurityCode).Cascade(CascadeMode.Stop).NotEmpty()
                .Length(3, 3).WithMessage("SecurityCode must be 3 characters long")
                .Must(NumberValidate).WithMessage("Only digits are allowed for a SecurityCode");

            RuleFor(c => c.Amount).Cascade(CascadeMode.Stop).NotEmpty().GreaterThan(0);
        }

        private bool DateValidate(DateTime value)
        {
            return DateTime.Compare(DateTime.Now, value) == -1;
        }

        private bool NumberValidate(string securityCode)
        {
            return Regex.Match(securityCode, "\\d+").Length == securityCode.Length;

        }
    }
}
