using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worklogs.DB.Data.Entities;
using Worklogs.Shared.DTO;

namespace Worklogs.Repository.Repository
{
    public interface IWorkLogRepository : IRepository<WorkLog>
    {
        Task GetWorklogsExcel(int uploadedFileID, string filePath);

        Task<List<WorkLogDTO>> GetList();
    }
}
