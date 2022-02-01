using FileAPI.Repository.Database;
using FileAPI.Repository.FileSystem;
using FileAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IDBRepository dbRepository;
        private readonly IDataTransformationService dataTransformationService;
        private readonly IFileRepository fileRepository;

        public FilesController(IDataTransformationService dataTransformationService, IDBRepository dbRepository, IFileRepository fileRepository)
        {
            this.dbRepository = dbRepository;
            this.dataTransformationService = dataTransformationService;
            this.fileRepository = fileRepository;
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 300000000)]
        [RequestSizeLimit(300000000)]
        public async Task<bool> UploadFile(IFormFile file)
        {
            if(string.IsNullOrEmpty(file.FileName))
            {
                return false;
                //This should be logged
            }
            //copy file locally
            var fileName = $"{Environment.CurrentDirectory}\\{file.FileName}";
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            //transform the data to object
            var transformedData = dataTransformationService.TransformCsvToObject(fileName);
           
            // persist data to database
            await Task.Run(() => dbRepository.Create(transformedData));

            //persist the data to storage location
            await Task.Run(() => fileRepository.Create(transformedData));
            
            return true;
        }    
    }
}
