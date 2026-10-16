using System;
using System.Threading.Tasks;
using Fundzo.Core.Repositories;

namespace Fundzo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository Addresses { get; }
        ICategoryRepository Categories { get; }
        ICountryRepository Countries { get; }
        ICurrencyRepository Currencies { get; }
        IDonationRepository Donations { get; }
        IDonationStatusRepository DonationStatuses { get; }
        IFundraiserRepository Fundraisers { get; }
        IFundraiserMediaRepository FundraiserMedias { get; }
        IFundraiserStatusRepository FundraiserStatuses { get; }
        IFundraiserTypeRepository FundraiserTypes { get; }
        IIndustryRepository Industries { get; }
        IOrganisationRepository Organisations { get; }
        IPaymentMethodRepository PaymentMethods { get; }
        IPaymentRepository Payments { get; }
        IPaymentStatusRepository PaymentStatuses { get; }
        IStaticMediaRepository StaticMedias { get; }
        Task<int> CommitAsync();
    }
}