using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Fundzo.Api.Resources.StaticMedia;
using Fundzo.Core.Models;
using Fundzo.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fundzo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticMediaController : ControllerBase
    {
        /// <summary>
        /// Private IConfiguration context to access keys from appsettings.json file.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// Private Static Media service context.
        /// </summary>
        private readonly IStaticMediaService staticMediaService;

        /// <summary>
        /// Private mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Private logger for StaticMediaController.
        /// </summary>
        private readonly ILogger<StaticMediaController> logger;

        /// <summary>
        /// Controller constructor for IConfiguration injection.
        /// </summary>
        /// <param name="configuration">IConfiguration dependency</param>
        public StaticMediaController(IStaticMediaService staticMediaService, IConfiguration configuration, IMapper mapper, ILogger<StaticMediaController> logger)
        {
            this.staticMediaService = staticMediaService;
            this.configuration = configuration;
            this.mapper = mapper;
            this.logger = logger;
        }

        /// <summary>
        /// Get all static medias.
        /// </summary>
        /// <returns>200 successful operation and list of all static medias.</returns>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<StaticMediaResource>>> GetAllStaticMedias()
        {
            try
            {
                var staticMedias = await staticMediaService.GetAllStaticMedias();
                var response = mapper.Map<IEnumerable<StaticMedia>, IEnumerable<StaticMediaResource>>(staticMedias);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get static media by id.
        /// </summary>
        /// <param name="id">Id of the static media.</param>
        /// <returns>200 successful operation and the static media or 404 static media not found.</returns>
        [HttpGet("StaticMedia/{id}")]
        public async Task<ActionResult<StaticMediaResource>> GetStaticMediaById(int id)
        {
            var staticMedia = await staticMediaService.GetStaticMediaById(id);
            var response = mapper.Map<StaticMedia, StaticMediaResource>(staticMedia);

            if (staticMedia == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Upload a file to Azure Blob Storage.
        /// </summary>
        /// <param name="files">Uploaded file.</param>
        /// <param name="saveStaticMediaResource"></param>
        /// <returns>200 successful operation.</returns>
        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile files, [FromForm] SaveStaticMediaResource saveStaticMediaResource)
        {
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
                Page = saveStaticMediaResource.Page,
                Layout = saveStaticMediaResource.Layout,
            };

            var staticMedia = await staticMediaService.CreateStaticMedia(newStaticMedia);
            mapper.Map<StaticMedia, StaticMediaResource>(staticMedia);

            return Ok("File uploaded successfully");
        }

        /// <summary>
        /// Download a file from Azure Blob Storage.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The file.</returns>
        [HttpPost("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            string blobStorageConnection = configuration.GetValue<string>("BlobConnectionString");

            string blobContainerName = configuration.GetValue<string>("BlobContainerName");

            // Azure connection string and container name passed as an argument to get the Blob reference of the container.
            var container = new BlobContainerClient(blobStorageConnection, blobContainerName);

            // Method to create a new Blob client.
            var blob = container.GetBlobClient(fileName);

            using var stream = new MemoryStream();

            await blob.DownloadToAsync(stream);

            Stream blobStream = blob.OpenReadAsync().Result;

            return File(blobStream, blob.GetProperties().Value.ContentType, blob.Name);
        }

        /// <summary>
        /// Delete the file from Azure Blob Storage.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>200 successful operation and the file was deleted.</returns>
        [HttpDelete("DeleteFile")]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            string blobStorageConnection = configuration.GetValue<string>("BlobConnectionString");

            string blobContainerName = configuration.GetValue<string>("BlobContainerName");

            // Azure connection string and container name passed as an argument to get the Blob reference of the container.
            var container = new BlobContainerClient(blobStorageConnection, blobContainerName);

            // Method to create a new Blob client.
            var blob = container.GetBlobClient(fileName);

            var staticMedia = await staticMediaService.GetStaticMediaByName(fileName);

            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

            await staticMediaService.DeleteStaticMedia(staticMedia);

            return Ok("File Deleted");
        }
    }
}
