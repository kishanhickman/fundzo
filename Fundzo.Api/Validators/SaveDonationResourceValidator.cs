using FluentValidation;
using Fundzo.Api.Resources;

namespace Fundzo.Api.Validations
{
    public class SaveDonationResourceValidator : AbstractValidator<SaveDonationResource>
    {
        public SaveDonationResourceValidator()
        {
            RuleFor(a => a.Amount)
                .NotEmpty()
                .WithMessage("'Amount' must be value not be 0.");

            RuleFor(b => b.FundraiserId)
                .NotEmpty()
                .WithMessage("'Fundaraiser Id' must not be 0.");

            RuleFor(c => c.UserId)
                .NotEmpty()
                .WithMessage("'User Id' must not be 0.");

            RuleFor(d => d.CurrencyId)
                .NotEmpty()
                .WithMessage("'Currency Id' must not be 0.");

            RuleFor(d => d.StatusId)
                .NotEmpty()
                .WithMessage("'Status Id' must not be 0.");
        }
    }
}