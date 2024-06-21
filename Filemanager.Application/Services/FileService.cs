
using FileManager.Domain.Entities;

namespace Filemanager.Application.Services
{
    public class FileService : IFileService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FileService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FileDto> AddFiles(AddFileDto file)
        {
            Files files = _mapper.Map<Files>(file);
            files.File = Extension.ConvertIFormFileToByteforFile(file.FileUpload);
            files.Size = file.FileUpload.Length;
            files.Name = file.Name;
            files.extension = file.extension;
            await _context.Files.AddAsync(files);
            await _context.SaveChangesAsync();
            return _mapper.Map<FileDto>(files);
        }

        public async Task<bool> DeleteFiles(Guid fileId)
        {
            var file = await _context.Files.FirstOrDefaultAsync(p=>p.Id == fileId);
            _context.Remove(file);
            await _context.SaveChangesAsync();
            return false;
        }

        public async Task<List<FileDto>> GetAllFileByFolder(Guid folderId)
        {
            var file = _context.Files.Where(p => p.FolderId == folderId);
            return _mapper.Map<List<FileDto>>(file);
        }

        public async Task<List<FileDto>> GetAllFiles()
        {
            return _mapper.Map<List<FileDto>>(await _context.Files.ToListAsync());
        }

        public async Task<FileDto> MoveFile(Guid FileId, Guid FolderId)
        {
            var file =await _context.Files.FirstOrDefaultAsync(p=>p.Id ==FileId);
            file.FolderId = FolderId;
            _context.Files.Update(file);
            await _context.SaveChangesAsync();
            return _mapper.Map<FileDto>(file);
        }

        public async Task<FileDto> RenameFile(string Filename, Guid fileId)
        {
            var file = await _context.Files.FirstOrDefaultAsync(p => p.Id == fileId);
            file.Name = Filename;
            _context.Files.Update(file);
            await _context.SaveChangesAsync();
            return _mapper.Map<FileDto>(file);
        }
    }
}
