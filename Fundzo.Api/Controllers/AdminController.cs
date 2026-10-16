using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fundzo.Api.Resources;
using Fundzo.Api.Validations;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using Microsoft.Extensions.Logging;
using Fundzo.Api.Validators;
using Fundzo.Api.Resources.Admin.Industries;

namespace Fundzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// Private Address service context.
        /// </summary>
        private readonly IAddressService addressService;

        /// <summary>
        /// Private Category service context.
        /// </summary>
        private readonly ICategoryService categoryService;

        /// <summary>
        /// Private Country service context.
        /// </summary>
        private readonly ICountryService countryService;

        /// <summary>
        /// Private Currency service context.
        /// </summary>
        private readonly ICurrencyService currencyService;

        /// <summary>
        /// Private Industry service context.
        /// </summary>
        private readonly IIndustryService industryService;

        /// <summary>
        /// Private Organisation service context.
        /// </summary>
        private readonly IOrganisationService organisationService;

        /// <summary>
        /// Private mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Private logger for AdminController.
        /// </summary>
        private readonly ILogger<AdminController> logger;

        /// <summary>
        /// Controller constructor for dependency injection and mapping.
        /// </summary>
        /// <param name="addressService">Injected service context.</param>
        /// <param name="categoryService">Injected service context.</param>
        /// <param name="countryService">Injected service context.</param>
        /// <param name="currencyService">Injected service context.</param>
        /// <param name="industryService">Injected service context.</param>
        /// <param name="organisationService">Injected service context.</param>
        /// <param name="mapper">Mapping.</param>
        /// <param name="logger">Logger.</param>
        public AdminController(IAddressService addressService, ICategoryService categoryService, ICountryService countryService, ICurrencyService currencyService, IIndustryService industryService, IOrganisationService organisationService, IMapper mapper, ILogger<AdminController> logger)
        {
            this.mapper = mapper;
            this.addressService = addressService;
            this.categoryService = categoryService;
            this.countryService = countryService;
            this.currencyService = currencyService;
            this.industryService = industryService;
            this.organisationService = organisationService;
            this.logger = logger;
        }

        /// <summary>
        /// Get all addresses.
        /// </summary>
        /// <returns>200 successful operation and list of all addresses.</returns>
        [HttpGet("Address")]
        public async Task<ActionResult<IEnumerable<AddressResource>>> GetAllAddresses()
        {
            try
            {
                var addresses = await addressService.GetAllAddresses();
                var response = mapper.Map<IEnumerable<Address>, IEnumerable<AddressResource>>(addresses);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get address by id.
        /// </summary>
        /// <param name="id">Id of the address.</param>
        /// <returns>200 successful operation and the address or 404 address not found.</returns>
        [HttpGet("Address/{id}")]
        public async Task<ActionResult<AddressResource>> GetAddressById(int id)
        {
            try
            {
                var address = await addressService.GetAddressById(id);
                var response = mapper.Map<Address, AddressResource>(address);

                if (address == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>200 successful operation and list of all categories.</returns>
        [HttpGet("Category")]
        public async Task<ActionResult<IEnumerable<CategoryResource>>> GetAllCategories()
        {
            try
            {
                var categories = await categoryService.GetAllCategories();
                var response = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get category by id.
        /// </summary>
        /// <param name="id">Id of the category.</param>
        /// <returns>200 successful operation and the category or 404 category not found.</returns>
        [HttpGet("Category/{id}")]
        public async Task<ActionResult<CategoryResource>> GetCategoryById(int id)
        {
            try
            {
                var category = await categoryService.GetCategoryById(id);
                var response = mapper.Map<Category, CategoryResource>(category);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all countries.
        /// </summary>
        /// <returns>200 successful operation and list of all countries.</returns>
        [HttpGet("Country")]
        public async Task<ActionResult<IEnumerable<CountryResource>>> GetAllCountries()
        {
            try
            {
                var countries = await countryService.GetAllCountries();
                var response = mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(countries);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get country by id.
        /// </summary>
        /// <param name="id">Id of the country.</param>
        /// <returns>200 successful operation and the country or 404 country not found.</returns>
        [HttpGet("Country/{id}")]
        public async Task<ActionResult<CountryResource>> GetCountryById(int id)
        {
            try
            {
                var country = await countryService.GetCountryById(id);
                var response = mapper.Map<Country, CountryResource>(country);

                if (country == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all currencies.
        /// </summary>
        /// <returns>200 successful operation and list of all currencies.</returns>
        [HttpGet("Currency")]
        public async Task<ActionResult<IEnumerable<CurrencyResource>>> GetAllCurrencies()
        {
            try
            {
                var currencies = await currencyService.GetAllCurrencies();
                var response = mapper.Map<IEnumerable<Currency>, IEnumerable<CurrencyResource>>(currencies);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get currency by id.
        /// </summary>
        /// <param name="id">Id of the currency.</param>
        /// <returns>200 successful operation and the currency or 404 currency not found.</returns>
        [HttpGet("Currency/{id}")]
        public async Task<ActionResult<CurrencyResource>> GetCurrencyById(int id)
        {
            try
            {
                var currency = await currencyService.GetCurrencyById(id);
                var response = mapper.Map<Currency, CurrencyResource>(currency);

                if (currency == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all industries.
        /// </summary>
        /// <returns>200 successful operation and list of all industries.</returns>
        [HttpGet("Industry")]
        public async Task<ActionResult<IEnumerable<IndustryResource>>> GetAllIndustries()
        {
            try
            {
                var industries = await industryService.GetAllIndustries();
                var response = mapper.Map<IEnumerable<Industry>, IEnumerable<IndustryResource>>(industries);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get industry by id.
        /// </summary>
        /// <param name="id">Id of the industry.</param>
        /// <returns>200 successful operation and the industry or 404 industry not found.</returns>
        [HttpGet("Industry/{id}")]
        public async Task<ActionResult<IndustryResource>> GetIndustryById(int id)
        {
            try
            {
                var industry = await industryService.GetIndustryById(id);
                var response = mapper.Map<Industry, IndustryResource>(industry);

                if (industry == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all organisations.
        /// </summary>
        /// <returns>200 successful operation and list of all organisations.</returns>
        [HttpGet("Organisation")]
        public async Task<ActionResult<IEnumerable<OrganisationResource>>> GetAllOrganisations()
        {
            try
            {
                var organisations = await organisationService.GetAllOrganisations();
                var response = mapper.Map<IEnumerable<Organisation>, IEnumerable<OrganisationResource>>(organisations);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get organisation by id.
        /// </summary>
        /// <param name="id">Id of the organisation.</param>
        /// <returns>200 successful operation and the organisation or 404 organisation not found.</returns>
        [HttpGet("Organisation/{id}")]
        public async Task<ActionResult<OrganisationResource>> GetOrganisationById(int id)
        {
            try
            {
                var organisation = await organisationService.GetOrganisationById(id);
                var response = mapper.Map<Organisation, OrganisationResource>(organisation);

                if (organisation == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
