using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs.DB.Data.Entities
{
    public class MonthlyProjectHistory : BaseEntity
    {
        public required int ProjectId { get; set; }
        public Project? Project { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public required DateTime Date { get; set; }

        [Required(ErrorMessage = "Time worked is required.")]
        public required int TimeWorked { get; set; } 
   
    }
}
