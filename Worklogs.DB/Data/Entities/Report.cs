using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worklogs.Shared.ENUM;

namespace Worklogs.DB.Data.Entities
{
    public class Report : BaseEntity
    {
        public int UploadedFileID { get; set; }
        public UploadedFile? UploadedFile { get; set; }

        public int TargetUserID { get; set; }
        public User? User { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public required EnumTypes Type { get; set; }

        [Required(ErrorMessage = "Report date is required.")]
        public DateTime ReportDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "File path is required.")]
        [MaxLength(256, ErrorMessage = "The file path must not exceed {1} characters.")]
        public required string FilePath { get; set; }
    }
}
