using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs.DB.Data.Entities
{
    public class Project : BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(50, ErrorMessage = "The project name must not exceed {1} characters.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Contract start date is required.")]
        public required DateTime ContractStartDate { get; set; }

        [Required(ErrorMessage = "Contract end date is required.")]
        public required DateTime ContractEndDate { get; set; }

        [Required(ErrorMessage = "Time worked each month is required.")]
        public required int TimePerMonth { get; set; } // in seconds
    }
}
