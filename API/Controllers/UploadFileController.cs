using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.AggregateModels.Entities;
using Domain.Infrastructures.Service.FileService;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Domain.AggregateModels.Entities.FileModel;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IFileService fileService;

        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }
        [HttpGet]
        [Route("GetAllFiles")]
        public async Task<IActionResult> GetAllFiles()
        {
            var fileuploadViewModel = await LoadAllFiles();
            return Ok(fileuploadViewModel);
        }
        [HttpPost]
        [Route("uploadSystem")]

        public async Task<IActionResult> UploadToFileSystem(List<IFormFile> files)
        {
            try
            {
                return Ok(await fileService.CreateFileOnSystem(files));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("uploadToDatabase")]
        public async Task<IActionResult> UploadToDatabase(List<IFormFile> files)
        {
            try
            {
                return Ok(await fileService.CreateFileOnDatabase(files));
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetAll")]
        private async Task<FileUploadViewModel> LoadAllFiles()
        {
            return await fileService.LoadAllFiles();
        }

        [HttpGet]
        [Route("downloadFromDatabase")]
        public async Task<IActionResult> DownloadFileFromDatabase(Guid id)
        {

            var file = await fileService.GetFileOnDatabaseById(id);
            if (file == null) return null;
            return File(file.Data, file.FileType, file.Name + file.Extension);
        }
        [HttpGet]
        [Route("downloadToSystem")]
        public async Task<IActionResult> DownloadFileFromFileSystem(Guid id)
        {

            var file = await fileService.GetFileOnSystemById(id);
            if (file == null) return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.FilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, file.FileType, file.Name + file.Extension);
        }
        [HttpDelete]
        [Route("deteleFileToSystem/{id}")]
        public async Task<IActionResult> DeleteFileFromFileSystem(Guid id)
        {
            try
            {
                return Ok(await fileService.DeletedFileOnSystem(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("deteleFileToDatabase/{id}")]
        public async Task<IActionResult> DeleteFileFromDatabase(Guid id)
        {
            try
            {
                return Ok(await fileService.DeletedFileOnDatabase(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
