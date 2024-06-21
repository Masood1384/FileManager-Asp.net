
namespace Filemanager.Application.Services
{
    public class FolderService : IFolderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FolderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FolderDto> AddFolder(AddFolderDto folderDto)
        {
            var folder = _mapper.Map<Folder>(folderDto);
            var res = await _context.Folders.AddAsync(folder);
            await _context.SaveChangesAsync();
            return _mapper.Map<FolderDto>(res);
        }

        public async Task<bool> DeleteFolder(Guid folderId)
        {
            var folder = await _context.Folders.FirstOrDefaultAsync(x => x.Id == folderId);
            _context.Folders.Remove(folder);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<FolderDto>> GetAllFolder()
        {
            return _mapper.Map<List<FolderDto>>(await _context.Folders.Include(p => p.Files).Include(p => p.ChildrenFolders).ThenInclude(p => p.Files).ToListAsync());
        }

        public async Task<List<FolderDto>> GetFolderByFolder(Guid folderId)
        {
            var folders = _context.Folders.Where(p=>p.ParentId == folderId).Include(p => p.Files).Include(p => p.ChildrenFolders).ThenInclude(p => p.Files).ToList();
            return _mapper.Map<List<FolderDto>>(folders);
        }

        public async Task<FolderDto> MoveFolder(Guid FolderId, Guid ToFolderId)
        {
            var folder =await _context.Folders.FirstOrDefaultAsync(p=>p.Id == FolderId);
            folder.ParentId = ToFolderId;
            _context.Folders.Update(folder);
            await _context.SaveChangesAsync();
            return _mapper.Map<FolderDto>(folder);
        }

        public async Task<FolderDto> UpdateFolder(UpdateFolderDto folderDto)
        {
            var folder = _mapper.Map<Folder>(folderDto);
            var res = _context.Folders.Update(folder);
            await _context.SaveChangesAsync();
            return _mapper.Map<FolderDto>(res);
        }
    }
}
