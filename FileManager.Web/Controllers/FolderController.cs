using Filemanager.Application.Constract;
using Filemanager.Application.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Web.Controllers
{
    public class FolderController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IFolderService _folderService;
        public FolderController(IFolderService folderService, IFileService fileService)
        {
            _folderService = folderService;
            _fileService = fileService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFolder(AddFolderDto addFolder)
        {
            await _folderService.AddFolder(addFolder);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> EditFolder(UpdateFolderDto updateFolder)
        {
            await _folderService.UpdateFolder(updateFolder);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> MoveFolder(Guid FolderId,Guid ToFolder)
        {
            await _folderService.MoveFolder(FolderId,ToFolder);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFolder(Guid FolderId)
        {
            await _folderService.DeleteFolder(FolderId);
            return RedirectToAction("Index", "Home");
        }
    }
}
