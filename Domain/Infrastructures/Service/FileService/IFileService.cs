using Domain.AggregateModels.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.AggregateModels.Entities.FileModel;

namespace Domain.Infrastructures.Service.FileService
{
    public interface IFileService
    {
        Task<FileOnDatabaseModel> GetFileOnDatabaseById(Guid id);
        Task<string> CreateFileOnDatabase(List<IFormFile> files);
        Task<string> DeletedFileOnDatabase(Guid id);
        //
        Task<FileOnFileSystemModel> GetFileOnSystemById(Guid id);
        Task<string> CreateFileOnSystem(List<IFormFile> files);
        Task<string> DeletedFileOnSystem(Guid id);
        Task<FileUploadViewModel> LoadAllFiles();

    }
}
