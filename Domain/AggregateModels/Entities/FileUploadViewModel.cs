using System;
using System.Collections.Generic;
using System.Text;
using static Domain.AggregateModels.Entities.FileModel;

namespace Domain.AggregateModels.Entities
{
    public class FileUploadViewModel
    {
        public List<FileOnFileSystemModel> FilesOnFileSystem { get; set; }

        public List<FileOnDatabaseModel> FilesOnDatabase { get; set; }
    }
}
