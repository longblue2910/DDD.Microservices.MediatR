using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.AggregateModels.Entities
{
    public class FileModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string UploadedBy { get; set; }
        public DateTime? CreatedOn { get; set; }

        public class FileOnDatabaseModel : FileModel
        {
            public byte[] Data { get; set; }
        }
        public class FileOnFileSystemModel : FileModel
        {
            public string FilePath { get; set; }
        }
    }
}
