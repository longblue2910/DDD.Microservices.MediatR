using Domain.AggregateModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Domain.AggregateModels.Entities.FileModel;

namespace Domain.Interfaces
{
    public interface IFileRepository
    {
        Task<FileOnDatabaseModel> GetFileOnDatabaseById(Guid id);
        Task<FileOnDatabaseModel> CreateFileOnDatabase(FileOnDatabaseModel file);
        Task<string> DeletedFileOnDatabase(Guid id);
        //
        Task<FileOnFileSystemModel> GetFileOnSystemById(Guid id);
        Task<FileOnFileSystemModel> CreateFileOnSystem(FileOnFileSystemModel file);
        Task<string> DeletedFileOnSystem(Guid id);
        Task<FileUploadViewModel> LoadAllFiles();

    }
}
