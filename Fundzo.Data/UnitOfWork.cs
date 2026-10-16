using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Fundzo.Core;
using Fundzo.Core.Repositories;
using Fundzo.Data.Repositories;

namespace Fundzo.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FundzoContext context;
        private AddressRepository addressRepository;
        private CategoryRepository categoryRepository;
        private CountryRepository countryRepository;
        private CurrencyRepository currencyRepository;
        private DonationRepository donationRepository;
        private DonationStatusRepository donationStatusRepository;
        private FundraiserRepository fundraiserRepository;
        private FundraiserMediaRepository fundraiserMediaRepository;
        private FundraiserStatusRepository fundraiserStatusRepository;
        private FundraiserTypeRepository fundraiserTypeRepository;
        private IndustryRepository industryRepository;
        private OrganisationRepository organizationRepository;
        private PaymentMethodRepository paymentMethodRepository;
        private PaymentRepository paymentRepository;
        private PaymentStatusRepository paymentStatusRepository;
        private StaticMediaRepository staticMediaRepository;

        public UnitOfWork(FundzoContext context)
        {
            this.context = context;
        }

        public IAddressRepository Addresses => addressRepository = addressRepository ?? new AddressRepository(context);
        public ICategoryRepository Categories => categoryRepository = categoryRepository ?? new CategoryRepository(context);
        public ICountryRepository Countries => countryRepository = countryRepository ?? new CountryRepository(context);
        public ICurrencyRepository Currencies => currencyRepository = currencyRepository ?? new CurrencyRepository(context);
        public IDonationRepository Donations => donationRepository = donationRepository ?? new DonationRepository(context);
        public IDonationStatusRepository DonationStatuses => donationStatusRepository = donationStatusRepository ?? new DonationStatusRepository(context);
        public IFundraiserRepository Fundraisers => fundraiserRepository = fundraiserRepository ?? new FundraiserRepository(context);
        public IFundraiserMediaRepository FundraiserMedias => fundraiserMediaRepository = fundraiserMediaRepository ?? new FundraiserMediaRepository(context);
        public IFundraiserStatusRepository FundraiserStatuses => fundraiserStatusRepository = fundraiserStatusRepository ?? new FundraiserStatusRepository(context);
        public IFundraiserTypeRepository FundraiserTypes => fundraiserTypeRepository = fundraiserTypeRepository ?? new FundraiserTypeRepository(context);
        public IIndustryRepository Industries => industryRepository = industryRepository ?? new IndustryRepository(context);
        public IOrganisationRepository Organisations => organizationRepository = organizationRepository ?? new OrganisationRepository(context);
        public IPaymentMethodRepository PaymentMethods => paymentMethodRepository = paymentMethodRepository ?? new PaymentMethodRepository(context);
        public IPaymentRepository Payments => paymentRepository = paymentRepository ?? new PaymentRepository(context);
        public IPaymentStatusRepository PaymentStatuses => paymentStatusRepository = paymentStatusRepository ?? new PaymentStatusRepository(context);
        public IStaticMediaRepository StaticMedias => staticMediaRepository = staticMediaRepository ?? new StaticMediaRepository(context);

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

