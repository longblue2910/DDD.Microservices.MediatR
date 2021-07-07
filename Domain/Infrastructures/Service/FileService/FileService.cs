using Domain.AggregateModels.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static Domain.AggregateModels.Entities.FileModel;

namespace Domain.Infrastructures.Service.FileService
{
    public class FileService : IFileService
    {
        private readonly IFileRepository fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }
        public async Task<string> CreateFileOnDatabase(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                var fileModel = new FileOnDatabaseModel
                {
                    CreatedOn = DateTime.Now,
                    FileType = file.ContentType,
                    Extension = extension,
                    Name = fileName
                };
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    fileModel.Data = dataStream.ToArray();
                }
                await fileRepository.CreateFileOnDatabase(fileModel);
            }
            return "Uploaded success.";
        }

        public async Task<string> CreateFileOnSystem(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    var fileModel = new FileOnFileSystemModel
                    {
                        CreatedOn = DateTime.UtcNow,
                        FileType = file.ContentType,
                        Extension = extension,
                        Name = fileName,
                        FilePath = filePath
                    };
                    await fileRepository.CreateFileOnSystem(fileModel);
                }
            }
            return "Uploaded success.";
        }

        public async Task<string> DeletedFileOnDatabase(Guid id)
        {
            return await fileRepository.DeletedFileOnDatabase(id);

        }

        public async Task<string> DeletedFileOnSystem(Guid id)
        {
            var file = await fileRepository.GetFileOnSystemById(id);
            if (file == null) return null;
            if (System.IO.File.Exists(file.FilePath))
            {
                System.IO.File.Delete(file.FilePath);
            }
            return await fileRepository.DeletedFileOnSystem(id);
            
        }

        public async Task<FileOnDatabaseModel> GetFileOnDatabaseById(Guid id)
        {
            return await fileRepository.GetFileOnDatabaseById(id);
        }

        public async Task<FileOnFileSystemModel> GetFileOnSystemById(Guid id)
        {
            return await fileRepository.GetFileOnSystemById(id);
        }

        public async Task<FileUploadViewModel> LoadAllFiles()
        {
            return await fileRepository.LoadAllFiles();
        }
    }
}
