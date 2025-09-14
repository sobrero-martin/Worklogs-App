using Microsoft.AspNetCore.Mvc;
using Worklogs.DB.Data.Entities;
using Worklogs.Repository.Repository;
using Worklogs.Shared.DTO;

namespace Worklogs.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadedFileController : ControllerBase
    {
        private readonly IUploadedFileRepository repository;
        private readonly IWorkLogRepository workLogRepository;

        public UploadedFileController(IUploadedFileRepository repository, IWorkLogRepository workLogRepository)
        {
            this.repository = repository;
            this.workLogRepository = workLogRepository;
        }


        [HttpGet("list")] 
        public async Task<ActionResult<List<UploadedFilesListDTO>>> GetList()
        {
            var list = await repository.GetList();
            if (list == null)
            {
                return NotFound("No list found(NULL).");
            }
            if (list.Count == 0)
            {
                return NotFound("No existing records on list.");
            }
            return Ok(list);
        }   


        [HttpPost("file")]
        public async Task<ActionResult<int>> PostFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var uploadedFile = new UploadedFile
            {
                FileName = file.FileName,
                UploadDate = DateTime.Now
            };

            await repository.Post(uploadedFile);

            await workLogRepository.GetWorklogsExcel(uploadedFile.Id, filePath);

            return Ok(uploadedFile.Id);
        }

        /* 

        [HttpGet]
        public async Task<ActionResult<List<UploadedFile>>> GetFull()
        {
            var list = await repository.GetFull();

            if (list == null)
            {
                return NotFound("No list found(NULL).");
            }

            if (list.Count == 0)
            {
                return NotFound("No existing records on list.");
            }

            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UploadedFile>> GetById(int id)
        {
            var entity = await repository.GetById(id);
            if (entity == null)
            {
                return NotFound($"No row found with ID {id}.");
            }
            return Ok(entity);
        }

        [HttpGet("byFileName/{fileName}")]
        public async Task<ActionResult<UploadedFile>> GetByFileName(string fileName)
        {
            var entity = await repository.GetByFileName(fileName);
            if (entity == null)
            {
                return NotFound($"No row found with file name {fileName}.");
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(UploadedFile uploadedFile)
        {
            try
            {
                await repository.Post(uploadedFile);
                return Ok(uploadedFile.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

         [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UploadedFile uploadedFile)
        {
            var result = await repository.Put(id, uploadedFile);
            return Ok($"Row with id {id} correctly updated");
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await repository.Delete(id);
            if (!result)
            {
                return NotFound($"No row found with ID {id} to delete.");
            }
            return Ok($"Row with id {id} correctly deleted");
        }
        */


    }
}
