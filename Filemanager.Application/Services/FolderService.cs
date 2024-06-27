
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
            return _mapper.Map<FolderDto>(folder);
        }

        public async Task<bool> DeleteFolderAndFile(List<Guid> SelectedFolder)
        {
            foreach (var item in SelectedFolder)
            {
                var folder = await _context.Folders.FindAsync(item);
                if (folder != null)
                {
                    _context.Folders.Remove(folder);
                    await _context.SaveChangesAsync();
                }
                var file = await _context.Files.FindAsync(item);
                if (file != null)
                {
                    _context.Files.Remove(file);
                    await _context.SaveChangesAsync();
                }
            }
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

        public async Task<FolderDto> MoveFolderAndFile(Guid Id, Guid ToFolderId)
        {
            var folder =await _context.Folders.FirstOrDefaultAsync(p=>p.Id == Id);
            if (folder != null)
            {
                if (ToFolderId != Guid.Empty)
                {
                    folder.ParentId = ToFolderId;
                }
                else
                {
                    folder.ParentId = null;
                }
                _context.Folders.Update(folder);
                await _context.SaveChangesAsync();
            }
            if(folder == null)
            {
                var file = await _context.Files.FirstOrDefaultAsync(p=>p.Id==Id);
                if (ToFolderId != Guid.Empty)
                {
                    file.FolderId = ToFolderId;
                }
                else
                {
                    file.FolderId = null;
                }
                _context.Files.Update(file);
                await _context.SaveChangesAsync();
            }
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
