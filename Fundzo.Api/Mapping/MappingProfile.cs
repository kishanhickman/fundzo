using AutoMapper;
using Fundzo.Api.Resources;
using Fundzo.Api.Resources.Admin.Industries;
using Fundzo.Api.Resources.Fundraiser;
using Fundzo.Api.Resources.Payment;
using Fundzo.Api.Resources.StaticMedia;
using Fundzo.Core.Models;

namespace Fundzo.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource.
            CreateMap<Address, AddressResource>();
            CreateMap<Category, CategoryResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<Currency, CurrencyResource>();
            CreateMap<Donation, DonationResource>();
            CreateMap<DonationStatus, DonationStatusResource>();
            CreateMap<Fundraiser, FundraiserResource>();
            CreateMap<FundraiserMedia, FundraiserMediaResource>();
            CreateMap<FundraiserMedia, SaveFundraiserMediaResource>();
            CreateMap<FundraiserStatus, FundraiserStatusResource>();
            CreateMap<FundraiserType, FundraiserTypeResource>();
            CreateMap<Fundraiser, SaveFundraiserResource>();
            CreateMap<Industry, IndustryResource>();
            CreateMap<Organisation, DonationResource>();
            CreateMap<Organisation, OrganisationResource>();
            CreateMap<Payment, PaymentResource>();
            CreateMap<PaymentStatus, PaymentStatusResource>();  
            CreateMap<PaymentMethod, PaymentMethodResource>();
            CreateMap<StaticMedia, StaticMediaResource>();
            CreateMap<StaticMedia, SaveStaticMediaResource>();

            // Resource to Domain.
            CreateMap<AddressResource, Address>();
            CreateMap<CategoryResource, Category>();
            CreateMap<CountryResource, Country>();
            CreateMap<CurrencyResource, Currency>();
            CreateMap<DonationResource, Donation>();
            CreateMap<DonationStatusResource, DonationStatus>();
            CreateMap<SaveDonationResource, Donation>();
            CreateMap<FundraiserResource, Fundraiser>();
            CreateMap<FundraiserMediaResource, FundraiserMedia>();
            CreateMap<SaveFundraiserMediaResource, FundraiserMedia>();
            CreateMap<FundraiserStatusResource, FundraiserStatus>();
            CreateMap<FundraiserTypeResource, FundraiserType>();
            CreateMap<SaveFundraiserResource, Fundraiser>();
            CreateMap<IndustryResource, Industry>();
            CreateMap<OrganisationResource, Organisation>();    
            CreateMap<PaymentResource, Payment>();
            CreateMap<PaymentMethodResource, PaymentMethod>();
            CreateMap<PaymentStatusResource, PaymentStatus>();
            CreateMap<SavePaymentResource, Payment>();
            CreateMap<StaticMediaResource, StaticMedia>();
            CreateMap<SaveStaticMediaResource, StaticMedia>();
        }
    }
}