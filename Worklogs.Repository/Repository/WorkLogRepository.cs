using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worklogs.DB.Data;
using Worklogs.DB.Data.Entities;
using Worklogs.Shared.DTO;

namespace Worklogs.Repository.Repository
{
    public class WorkLogRepository : Repository<WorkLog>, IRepository<WorkLog>, IWorkLogRepository
    {
        private readonly AppDbContext context;
        public WorkLogRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<WorkLogDTO>> GetList()
        {
            return await context.WorkLogs
                .Select(x => new WorkLogDTO
                {
                    EmployeeName = x.EmployeeName,
                    Activity = x.Activity,
                    DateWorked = x.DateWorked,
                    TimeWorked = x.TimeWorked
                })
                .ToListAsync();
        }

        public async Task GetWorklogsExcel(int uploadedFileID, string filePath)
        {
            using var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheets.First();

            foreach ( var row in worksheet.RowsUsed().Skip(1))
            {

                var worklog = new WorkLog
                { 
                    UploadedFileID = uploadedFileID,
                    EmployeeName = row.Cell(3).GetString(),
                    Activity = row.Cell(2).GetString(),
                    DateWorked = row.Cell(4).GetString(),
                    TimeWorked = Convert.ToInt32(row.Cell(5).GetDouble())
                };

                await Post(worklog);
            }
        }
    }
}
