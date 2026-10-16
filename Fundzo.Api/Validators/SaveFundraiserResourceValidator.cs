using FluentValidation;
using Fundzo.Api.Resources;

namespace Fundzo.Api.Validations
{
    public class SaveFundraiserResourceValidator : AbstractValidator<SaveFundraiserResource>
    {
        public SaveFundraiserResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("'Name' must not be empty.");

            RuleFor(b => b.Description)
                .NotEmpty()
                .WithMessage("'Description' must not be empty.");

            RuleFor(c => c.FundraiserTypeId)
                .NotEmpty()
                .WithMessage("'Fundraiser Type Id' must not be 0.");

            RuleFor(d => d.CategoryId)
                .NotEmpty()
                .WithMessage("'Category Id' must not be 0.");

            RuleFor(d => d.OrganisationId)
                .NotEmpty()
                .WithMessage("'Organisation Id' must not be 0.");

            RuleFor(d => d.FundraiserStatusId)
                .NotEmpty()
                .WithMessage("'Fundraised Status Id' must not be 0.");

            RuleFor(d => d.UserId)
                .NotEmpty()
                .WithMessage("'User Id' must not be 0.");

            RuleFor(d => d.CurrencyId)
                .NotEmpty()
                .WithMessage("'Currency Id' must not be 0.");
        }

    }
}