using Worklogs.DB.Data.Entities;
using Worklogs.Shared.DTO;

namespace Worklogs.Repository.Repository
{
    public interface IUploadedFileRepository : IRepository<UploadedFile>
    {
        Task<List<UploadedFilesListDTO>> GetList();

        Task<bool> SyncFilesWithCloud();

        //Task<UploadedFile?> GetByFileName(string fileName);
    }
}