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
    public class UploadedFileRepository : Repository<UploadedFile>, IRepository<UploadedFile>, IUploadedFileRepository
    {

        private readonly AppDbContext context;

        public UploadedFileRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }


        public async Task<List<UploadedFilesListDTO>> GetList()
        {
            return await context.UploadedFiles
                .Select(x => new UploadedFilesListDTO
                {
                    FileName = x.FileName,
                    UploadDate = x.UploadDate.ToString("yyyy-MM-dd"),
                })
                .ToListAsync();
        }


        /*
        public async Task<UploadedFile?> GetByFileName(string fileName)
        {
            return await context.UploadedFiles.FirstOrDefaultAsync(x => x.FileName == fileName);
        }
        */
    }
}
