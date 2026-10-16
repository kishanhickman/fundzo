using FluentValidation;
using Fundzo.Api.Resources.Payment;

namespace Fundzo.Api.Validators
{
    public class SavePaymentResourceValidator : AbstractValidator<SavePaymentResource>
    {
        public SavePaymentResourceValidator()
        {
            RuleFor(p => p.Amount)
                .NotEmpty()
                .WithMessage("'Amount' must be value not be 0.");

            RuleFor(p => p.CurrencyCode)
                .NotEmpty()
                .WithMessage("'Name' must not be empty.");

            RuleFor(p => p.UserId)
                .NotEmpty()
                .WithMessage("'User Id' must not be 0.");

            RuleFor(p => p.PaymentMethodId)
                .NotEmpty()
                .WithMessage("'Payment Method Id' must not be 0.");

            RuleFor(p => p.PaymentStatusId)
                .NotEmpty()
                .WithMessage("'Payment Status Id' must not be 0.");

            RuleFor(p => p.DonationId)
                .NotEmpty()
                .WithMessage("'Donation Id' must not be 0.");

            RuleFor(p => p.CurrencyId)
                .NotEmpty()
                .WithMessage("'Currency Id' must not be 0.");
        }
    }
}
