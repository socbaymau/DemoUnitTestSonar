using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzureProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        public VideoController()
        {

        }
        [HttpGet]
        public async Task<ActionResult> Get(string path)
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

            //Create a name for the container
            string containerName = "videos";
            string blobName = path;
            // Create the container and return a container client object
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

            // Get a reference to a blob named "sample-file" in a container named "sample-container"
            BlobClient blob = container.GetBlobClient(blobName);
            MemoryStream fileStream = new MemoryStream();
            await blob.DownloadToAsync(fileStream);

            //var req = new FileContentResult(fileStream.ToArray(), "video/mp4");
            //return Ok(req);
            return new FileContentResult(fileStream.ToArray(), "video/mp4");
        }
        //[HttpGet("GetVideoFromAzureStorage")]
        //public FileResult GetVideo(int fileId)
        //{
        //    try
        //    {
        //        string connectionString = Environment.GetEnvironmentVariable("STORAGE_ACCOUNT_NAME");
        //        // Create a BlobServiceClient object which will be used to create a container client
        //        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

        //        //Create a unique name for the container
        //        string containerName = "quickstartblobs" + Guid.NewGuid().ToString();

        //        // Create the container and return a container client object
        //        BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}
    }
}
