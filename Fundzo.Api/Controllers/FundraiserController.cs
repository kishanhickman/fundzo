using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Fundzo.Api.Resources;
using Fundzo.Api.Validations;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Fundzo.Api.Resources.Fundraiser;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Fundzo.Api.Resources.StaticMedia;
using Microsoft.AspNetCore.Identity;
using Fundzo.Api.Authentication;

namespace Fundzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundraiserController : ControllerBase
    {
        /// <summary>
        /// Private Fundraiser logger
        /// </summary>
        private readonly ILogger<FundraiserController> _logger;

        /// <summary>
        /// Private IConfiguration context to access keys from appsettings.json file.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Private Fundraiser service context.
        /// </summary>
        private readonly IFundraiserService fundraiserService;

        /// <summary>
        /// Private Fundraiser Media service context.
        /// </summary>
        private readonly IFundraiserMediaService fundraiserMediaService;

        /// <summary>
        /// Private Fundraiser Status service context.
        /// </summary>
        private readonly IFundraiserStatusService fundraiserStatusService;

        /// <summary>
        /// Private Fundraiser Type service context.
        /// </summary>
        private readonly IFundraiserTypeService fundraiserTypeService;

        /// <summary>
        /// Private Static Media service context.
        /// </summary>
        private readonly IStaticMediaService staticMediaService;

        /// <summary>
        /// Private mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Private _userManager.
        /// </summary>
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Controller constructor for dependency injection and mapping.
        /// </summary>
        /// <param name="fundraiserService">Injected service context.</param>
        /// <param name="fundraiserMediaService">Injected service context.</param>
        /// <param name="fundraiserStatusService">Injected service context.</param>
        /// <param name="fundraiserTypeService">Injected service context.</param>
        /// <param name="mapper">Mapping.</param>
        public FundraiserController(IFundraiserService fundraiserService, IFundraiserMediaService fundraiserMediaService, IFundraiserStatusService fundraiserStatusService, IFundraiserTypeService fundraiserTypeService, IMapper mapper, ILogger<FundraiserController> logger, IConfiguration configuration, IStaticMediaService staticMediaService, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.fundraiserService = fundraiserService;
            this.fundraiserMediaService = fundraiserMediaService;
            this.fundraiserStatusService = fundraiserStatusService;
            this.fundraiserTypeService = fundraiserTypeService;
            this.staticMediaService = staticMediaService;
            _logger = logger;
            this.configuration = configuration;
            _userManager = userManager;
        }

        /// <summary>
        /// Get all fundraisers.
        /// </summary>
        /// <returns>200 successful operation and list of all fundraisers.</returns>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<FundraiserResource>>> GetAllFundraisers()
        {
            _logger.LogInformation("Testing serilog");
            var fundraisers = await fundraiserService.GetAllFundraisers();
            // var response = mapper.Map<IEnumerable<Fundraiser>, IEnumerable<FundraiserResource>>(fundraisers);

            return Ok(fundraisers);
        }


        /// <summary>
        /// Get fundraiser by id.
        /// </summary>
        /// <param name="id">Id of the fundraiser.</param>
        /// <returns>200 successful operation and the fundraiser or 404 fundraiser not found.</returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FundraiserResource>> GetFundraiserById(int id)
        {
            var fundraiser = await fundraiserService.GetFundraiserById(id);
            var response = mapper.Map<Fundraiser, FundraiserResource>(fundraiser);

            if (fundraiser == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Get fundraiser by name.
        /// </summary>
        /// <param name="name">Name of the fundraiser.</param>
        /// <returns>200 successful operation and the fundraiser or 404 fundraiser not found.</returns>
        [HttpGet("{name}")]
        public async Task<ActionResult<FundraiserResource>> GetFundraiserByName([FromRoute] string name)
        {
            var fundraiser = await fundraiserService.GetFundraiserByName(name);
            // var response = mapper.Map<IEnumerable<Fundraiser>, IEnumerable<FundraiserResource>>(fundraiser);

            if (fundraiser == null)
            {
                return NotFound();
            }

            return Ok(fundraiser);
        }

        /// <summary>
        /// Creates a new fundraiser and adds it to the system.
        /// </summary>
        /// <param name="saveFundraiserResource">Body of the fundraiser.</param>
        /// <returns>200 successful operation and new fundraiser was created or 400 bad request.</returns>
        [HttpPost("")]
        public async Task<IActionResult> CreateFundraiser(IFormFile files, [FromForm] SaveFundraiserResource saveFundraiserResource)
        {
            var validator = new SaveFundraiserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveFundraiserResource);
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (!validationResult.IsValid)
            {
                // This needs refining, but for demo it is ok.
                return BadRequest(validationResult.Errors);
            }

            // Map Resource to Domain: Create new fundraiser.
            var newFundraiser = await fundraiserService.CreateFundraiser(mapper.Map<SaveFundraiserResource, Fundraiser>(saveFundraiserResource));
            newFundraiser.UserId = Guid.Parse(user.Id);

            // Map Domain to Resource: Return to API friendly response.
            var fundraiserResource = mapper.Map<Fundraiser, FundraiserResource>(await fundraiserService.GetFundraiserById(newFundraiser.Id));

            string blobStorageConnection = configuration.GetValue<string>("BlobConnectionString");

            string blobContainerName = configuration.GetValue<string>("BlobContainerName");

            // Azure connection string and container name passed as an argument to get the Blob reference of the container.
            var container = new BlobContainerClient(blobStorageConnection, blobContainerName);

            // Method to create our container if it doesn’t exist.
            var createResponse = await container.CreateIfNotExistsAsync();

            // If container successfully created, then set public access type to Blob.
            if (createResponse != null && createResponse.GetRawResponse().Status == 201)
            {
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
            }

            // Method to create a new Blob client.
            var blob = container.GetBlobClient(files.FileName);

            // If a blob with the same name exists, then we delete the Blob and its snapshots.
            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

            // Create a file stream and use the UploadSync method to upload the Blob.
            using (var fileStream = files.OpenReadStream())
            {
                await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = files.ContentType });
            }

            StaticMedia newStaticMedia = new StaticMedia()
            {
                Name = blob.Name,
                Extension = files.ContentType,
                BlobUrl = blob.Uri.AbsoluteUri,
                DateCreated = DateTime.Now,
                Page = "Fundraiser",
                Layout = "Fundraiser image",
            };

            var staticMedia = await staticMediaService.CreateStaticMedia(newStaticMedia);
            mapper.Map<StaticMedia, StaticMediaResource>(staticMedia);

            FundraiserMedia newFundraiserMedia = new FundraiserMedia()
            {
                FundraiserId = newFundraiser.Id,
                Fundraiser = newFundraiser,
                StaticMediaId = newStaticMedia.Id,
                StaticMedia = newStaticMedia,
            };

            var fundraiserMedia = await fundraiserMediaService.CreateFundraiserMedia(newFundraiserMedia);
            mapper.Map<FundraiserMedia, FundraiserMediaResource>(fundraiserMedia);

            return Ok("Fundraiser created successfully");
        }

        /// <summary>
        /// Edit fundraiser information.
        /// </summary>
        /// <param name="id">Id of the fundraiser.</param>
        /// <param name="saveFundraiserResource">Body of the fundraiser.</param>
        /// <returns>200 successful operation and the fundraiser was edited or 400/404 error.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFundraiser(int id, int staticMediaId, int fundraiserMediaId, IFormFile files, [FromForm] SaveFundraiserResource saveFundraiserResource)
        {
            var validator = new SaveFundraiserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveFundraiserResource);

            if (!validationResult.IsValid)
            {
                // This needs refining, but for demo it is ok.
                return BadRequest(validationResult.Errors);
            }

            // Find existing fundraiser.
            var fundraiser = await fundraiserService.GetFundraiserById(id);

            if (fundraiser == null)
            {
                return NotFound();
            }

            fundraiser.Name = saveFundraiserResource.Name;
            fundraiser.Description = saveFundraiserResource.Description;
            fundraiser.GoalAmount = saveFundraiserResource.GoalAmount;
            fundraiser.FundraiserTypeId = saveFundraiserResource.FundraiserTypeId;
            fundraiser.CategoryId = saveFundraiserResource.CategoryId;
            fundraiser.OrganisationId = saveFundraiserResource.OrganisationId;
            fundraiser.CurrencyId = saveFundraiserResource.CurrencyId;

            // Map Resource to Domain: Update fundraiser.
            var updatedFundraiser = await fundraiserService.UpdateFundraiser(fundraiser);

            // Map Domain to Resource: Return to API friendly response.
            var fundraiserResource = mapper.Map<Fundraiser, FundraiserResource>(await fundraiserService.GetFundraiserById(updatedFundraiser.Id));

            string blobStorageConnection = configuration.GetValue<string>("BlobConnectionString");

            string blobContainerName = configuration.GetValue<string>("BlobContainerName");

            // Azure connection string and container name passed as an argument to get the Blob reference of the container.
            var container = new BlobContainerClient(blobStorageConnection, blobContainerName);

            // Method to create our container if it doesn’t exist.
            var createResponse = await container.CreateIfNotExistsAsync();

            // If container successfully created, then set public access type to Blob.
            if (createResponse != null && createResponse.GetRawResponse().Status == 201)
            {
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
            }

            // Method to create a new Blob client.
            var blob = container.GetBlobClient(files.FileName);

            // If a blob with the same name exists, then we delete the Blob and its snapshots.
            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

            // Create a file stream and use the UploadSync method to upload the Blob.
            using (var fileStream = files.OpenReadStream())
            {
                await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = files.ContentType });
            }

            // Find existing static media.
            var staticMedia = await staticMediaService.GetStaticMediaById(staticMediaId);

            if (staticMedia == null)
            {
                return NotFound();
            }

            staticMedia.Name = blob.Name;
            staticMedia.Extension = files.ContentType;
            staticMedia.BlobUrl = blob.Uri.AbsoluteUri;
            staticMedia.DateCreated = DateTime.Now;
            staticMedia.Page = "Fundraiser";
            staticMedia.Layout = "Fundraiser image";

            var updatedStaticMedia = await staticMediaService.UpdateStaticMedia(staticMedia);
            mapper.Map<StaticMedia, StaticMediaResource>(updatedStaticMedia);

            // Find existing fundraiser media.
            var fundraiserMedia = await fundraiserMediaService.GetFundraiserMediaById(fundraiserMediaId);

            if (fundraiserMedia == null)
            {
                return NotFound();
            }

            fundraiserMedia.FundraiserId = id;
            fundraiserMedia.Fundraiser = updatedFundraiser;
            fundraiserMedia.StaticMediaId = staticMediaId;
            fundraiserMedia.StaticMedia = updatedStaticMedia;

            var updatedFundraiserMedia = await fundraiserMediaService.UpdateFundraiserMedia(fundraiserMedia);
            mapper.Map<FundraiserMedia, FundraiserMediaResource>(updatedFundraiserMedia);


            return Ok("Fundraiser updated successfully");
        }

        /// <summary>
        /// Delete fundraiser.
        /// </summary>
        /// <param name="id">Id of the fundraiser.</param>
        /// <returns>200 successful operation and the fundraiser was deleted or 404 fundraiser was not found.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundraiser(int id)
        {
            // Find existing fundraiser.
            var fundraiser = await fundraiserService.GetFundraiserById(id);

            if (fundraiser == null)
            {
                return NotFound();
            }

            await fundraiserService.DeleteFundraiser(fundraiser);

            return Ok("Record deleted sucessfully");
        }

        /// <summary>
        /// Get all fundraiser medias.
        /// </summary>
        /// <returns>200 successful operation and list of all fundraiser medias.</returns>
        [HttpGet("FundraiserMedia")]
        public async Task<ActionResult<IEnumerable<FundraiserMediaResource>>> GetAllFundraiserMedias()
        {
            var fundraiserMedias = await fundraiserMediaService.GetAllFundraiserMedias();
            var response = mapper.Map<IEnumerable<FundraiserMedia>, IEnumerable<FundraiserMediaResource>>(fundraiserMedias);

            return Ok(response);
        }

        /// <summary>
        /// Get fundraiser media by id.
        /// </summary>
        /// <param name="id">Id of the fundraiser media.</param>
        /// <returns>200 successful operation and the fundraiser media or 404 fundraiser media not found.</returns>
        [HttpGet("FundraiserMedia/{id}")]
        public async Task<ActionResult<FundraiserMediaResource>> GetFundraiserMediaById(int id)
        {
            var fundraiserMedia = await fundraiserMediaService.GetFundraiserMediaById(id);
            var response = mapper.Map<FundraiserMedia, FundraiserMediaResource>(fundraiserMedia);

            if (fundraiserMedia == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Get all fundraiser statuses.
        /// </summary>
        /// <returns>200 successful operation and list of all fundraiser statuses.</returns>
        [HttpGet("FundraiserStatus")]
        public async Task<ActionResult<IEnumerable<FundraiserStatusResource>>> GetAllFundraiserStatuses()
        {
            var fundraiserStatuses = await fundraiserStatusService.GetAllFundraiserStatuses();
            var response = mapper.Map<IEnumerable<FundraiserStatus>, IEnumerable<FundraiserStatusResource>>(fundraiserStatuses);

            return Ok(response);
        }

        /// <summary>
        /// Get fundraiser status by id.
        /// </summary>
        /// <param name="id">Id of the fundraiser status.</param>
        /// <returns>200 successful operation and the fundraiser status or 404 fundraiser status not found.</returns>
        [HttpGet("FundraiserStatus/{id}")]
        public async Task<ActionResult<FundraiserStatusResource>> GetFundraiserStatusById(int id)
        {
            var fundraiserStatus = await fundraiserStatusService.GetFundraiserStatusById(id);
            var response = mapper.Map<FundraiserStatus, FundraiserStatusResource>(fundraiserStatus);

            if (fundraiserStatus == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Get all fundraiser types.
        /// </summary>
        /// <returns>200 successful operation and list of all fundraiser types.</returns>
        [HttpGet("FundraiserType")]
        public async Task<ActionResult<IEnumerable<FundraiserTypeResource>>> GetAllFundraiserTypes()
        {
            var fundraiserTypes = await fundraiserTypeService.GetAllFundraiserTypes();
            var response = mapper.Map<IEnumerable<FundraiserType>, IEnumerable<FundraiserTypeResource>>(fundraiserTypes);

            return Ok(response);
        }


        /// <summary>
        /// Get fundraiser type by id.
        /// </summary>
        /// <param name="id">Id of the fundraiser type.</param>
        /// <returns>200 successful operation and the fundraiser type or 404 fundraiser type not found.</returns>
        [HttpGet("FundraiserType/{id}")]
        public async Task<ActionResult<FundraiserTypeResource>> GetFundraiserTypeById(int id)
        {
            var fundraiserType = await fundraiserTypeService.GetFundraiserTypeById(id);
            var response = mapper.Map<FundraiserType, FundraiserTypeResource>(fundraiserType);

            if (fundraiserType == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}