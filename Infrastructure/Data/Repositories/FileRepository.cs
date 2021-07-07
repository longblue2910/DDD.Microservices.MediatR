using Domain.AggregateModels.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.AggregateModels.Entities.FileModel;

namespace Infrastructure.Data.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext context;

        public FileRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<FileOnDatabaseModel> CreateFileOnDatabase(FileOnDatabaseModel file)
        {
            context.FileOnDatabase.Add(file);
            await context.SaveChangesAsync();
            return file;
        }

        public async Task<FileOnFileSystemModel> CreateFileOnSystem(FileOnFileSystemModel file)
        {
            context.FileOnFileSystems.Add(file);
            await context.SaveChangesAsync();
            return file;
        }

        public async Task<string> DeletedFileOnDatabase(Guid id)
        {
            var fileDetele = await context.FileOnDatabase.Where(x => x.Id == id).FirstOrDefaultAsync();
            context.FileOnDatabase.Remove(fileDetele);
            return $"Removed {fileDetele.Name + fileDetele.Extension} successfully from File Database.";
        }

        public async Task<string> DeletedFileOnSystem(Guid id)
        {
            var fileDetele = await context.FileOnFileSystems.Where(x => x.Id == id).FirstOrDefaultAsync();
            context.FileOnFileSystems.Remove(fileDetele);
            return $"Removed {fileDetele.Name + fileDetele.Extension} successfully from File System.";
        }

        public async Task<FileOnDatabaseModel> GetFileOnDatabaseById(Guid id)
        {
            var file = await context.FileOnDatabase.Where(x => x.Id == id).FirstOrDefaultAsync();
            return file;
        }

        public async Task<FileOnFileSystemModel> GetFileOnSystemById(Guid id)
        {
            var file = await context.FileOnFileSystems.Where(x => x.Id == id).FirstOrDefaultAsync();
            return file;
        }

        public async Task<FileUploadViewModel> LoadAllFiles()
        {
            var viewModel = new FileUploadViewModel();
            viewModel.FilesOnDatabase = await context.FileOnDatabase.ToListAsync();
            viewModel.FilesOnFileSystem = await context.FileOnFileSystems.ToListAsync();
            return viewModel;
        }
    }
}
