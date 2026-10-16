using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fundzo.Api.Resources;
using Fundzo.Api.Validations;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Fundzo.Api.Authentication;

namespace Fundzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        /// <summary>
        /// Private Donation service context.
        /// </summary>
        private readonly IDonationService donationService;

        /// <summary>
        /// Private Donation Status service context.
        /// </summary>
        private readonly IDonationStatusService donationStatusService;

        /// <summary>
        /// Private mapper.
        /// </summary>
        private readonly IMapper mapper;
        
        /// <summary>
        /// Private logger for DonationController.
        /// </summary>
        private readonly ILogger<DonationController> logger;


        /// <summary>
        /// Private _userManager.
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Controller constructor for dependency injection and mapping.
        /// </summary>
        /// <param name="donationService">Injected service context.</param>
        /// <param name="donationStatusService">Injected service context.</param>
        /// <param name="mapper">Mapping.</param>
        /// <param name="logger">Logger.</param>
        public DonationController(IDonationService donationService, IDonationStatusService donationStatusService, IMapper mapper, ILogger<DonationController> logger, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.donationService = donationService;
            this.donationStatusService = donationStatusService;
            this.logger = logger;
            _userManager = userManager;
        }

        /// <summary>
        /// Get all donations.
        /// </summary>
        /// <returns>200 successful operation and list of all donations.</returns>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<DonationResource>>> GetAllDonations()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            try
            {
                var donations = await donationService.GetAllDonations();
                var response = mapper.Map<IEnumerable<Donation>, IEnumerable<DonationResource>>(donations);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get donation by id.
        /// </summary>
        /// <param name="id">Id of the donation.</param>
        /// <returns>200 successful operation and the donation or 404 donation not found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationResource>> GetDonationById(int id)
        {
            try
            {
                var donation = await donationService.GetDonationById(id);
                var response = mapper.Map<Donation, DonationResource>(donation);

                if (donation == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new donation and adds it to the system.
        /// </summary>
        /// <param name="saveDonationResource">Body of the donation.</param>
        /// <returns>200 successful operation and new donation was created or 400 bad request.</returns>
        [HttpPost("")]
        public async Task<ActionResult<DonationResource>> CreateDonation([FromBody] SaveDonationResource saveDonationResource)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            try
            {
                var validator = new SaveDonationResourceValidator();
                var validationResult = await validator.ValidateAsync(saveDonationResource);

                if (!validationResult.IsValid)
                {
                    // This needs refining, but for demo it is ok.
                    return BadRequest(validationResult.Errors);
                }

                // Map Resource to Domain: Create new donation.
                var newDonation = await donationService.CreateDonation(mapper.Map<SaveDonationResource, Donation>(saveDonationResource));
                newDonation.UserId = Guid.Parse(user.Id);
                // Map Domain to Resource: Return to API friendly response.
                var donationResource = mapper.Map<Donation, DonationResource>(await donationService.GetDonationById(newDonation.Id));

                return Ok(donationResource);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edit donation information.
        /// </summary>
        /// <param name="id">Id of the donation.</param>
        /// <param name="saveDonationResource">Body of the donation.</param>
        /// <returns>200 successful operation and the donation was edited or 400/404 error.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<DonationResource>> UpdateDonation(int id, [FromBody] SaveDonationResource saveDonationResource)
        {
            try
            {
                var validator = new SaveDonationResourceValidator();
                var validationResult = await validator.ValidateAsync(saveDonationResource);

                if (!validationResult.IsValid)
                {
                    // This needs refining, but for demo it is ok.
                    return BadRequest(validationResult.Errors);
                }

                // Find existing donation.
                var donation = await donationService.GetDonationById(id);

                if (donation == null)
                {
                    return NotFound();
                }

                // Map Resource to Domain: Update donation.
                var updatedDonation = await donationService.UpdateDonation(mapper.Map<SaveDonationResource, Donation>(saveDonationResource));

                // Map Domain to Resource: Return to API friendly response.
                var donationResource = mapper.Map<Donation, DonationResource>(await donationService.GetDonationById(updatedDonation.Id));

                return Ok(donationResource);
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete donation.
        /// </summary>
        /// <param name="id">Id of the donation.</param>
        /// <returns>200 successful operation and the donation was deleted or 404 donation was not found.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            try
            {
                // Find existing donation.
                var donation = await donationService.GetDonationById(id);

                if (donation == null)
                {
                    return NotFound();
                }

                await donationService.DeleteDonation(donation);

                return Ok("Record deleted sucessfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all donation statuses.
        /// </summary>
        /// <returns>200 successful operation and list of all donation statuses.</returns>
        [HttpGet("DonationStatus")]
        public async Task<ActionResult<IEnumerable<DonationStatusResource>>> GetAllDonationStatuses()
        {
            try
            {
                var donationStatuses = await donationStatusService.GetAllDonationStatuses();
                var response = mapper.Map<IEnumerable<DonationStatus>, IEnumerable<DonationStatusResource>>(donationStatuses);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get donation status by id.
        /// </summary>
        /// <param name="id">Id of the donation status.</param>
        /// <returns>200 successful operation and the donation status or 404 donation status not found.</returns>
        [HttpGet("DonationStatus/{id}")]
        public async Task<ActionResult<DonationStatusResource>> GetDonationStatusById(int id)
        {
            try
            {
                var donationStatus = await donationStatusService.GetDonationStatusById(id);
                var response = mapper.Map<DonationStatus, DonationStatusResource>(donationStatus);

                if (donationStatus == null)
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