using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs.DB.Data.Entities
{
    [Index(nameof(FileName), Name = "UploadedFiles_FileName_UQ", IsUnique = true)]
    public class UploadedFile : BaseEntity
    {
        [Required(ErrorMessage = "File name is required.")]
        [MaxLength(35, ErrorMessage = "The file name must not exceed {1} characters.")]
        public required string FileName { get; set; }

        [Required(ErrorMessage = "Upload date is required.")]
        public  DateTime UploadDate { get; set; } = DateTime.Now;
    }
}
