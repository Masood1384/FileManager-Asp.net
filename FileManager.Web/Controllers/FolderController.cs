using Filemanager.Application.Constract;
using Filemanager.Application.DTOS;
using FileManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using static FileManager.Web.Controllers.FolderController;

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
            if(addFolder.ParentId == Guid.Empty)
            {
                addFolder.ParentId = null;
            }
            await _folderService.AddFolder(addFolder);
            return RedirectToAction("Index", "Home", new { FolderId = addFolder.ParentId });
        }
        [HttpPost]
        public async Task<IActionResult> EditFolder(UpdateFolderDto updateFolder)
        {
            await _folderService.UpdateFolder(updateFolder);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> MoveFolderAndFile(Guid SelectedFolder, Guid ToFolder)
        {
            await _folderService.MoveFolderAndFile(SelectedFolder, ToFolder);
            return RedirectToAction("Index", "Home", new { FolderId = SelectedFolder });
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFileAndFolder(List<Guid> SelectedFolder , List<Guid> SelectedFile, Guid folderId)
        {
            SelectedFolder.AddRange(SelectedFile);
            var res = await _folderService.DeleteFolderAndFile(SelectedFolder);
            if (res != null)
            {
                return BadRequest(" مشکل در حذف فولدر لطفا قبل از حذف زیر مجموعه های فولدر را حذف کنید");
            }
            return RedirectToAction("Index", "Home", new { FolderId = folderId});
        }
        [HttpPost]
        public async Task<IActionResult> Tool(List<Guid>? SelectedFolder, List<Guid>? SelectedFile, Guid folderId,ContrallerState controllerState,string? name,Guid ToFolder)
        {
            if (controllerState == ContrallerState.Remove)
                 await RemoveFileAndFolder(SelectedFolder, SelectedFile, folderId);
            if (controllerState == ContrallerState.Move)
                await MoveFolderAndFile(SelectedFolder.FirstOrDefault(), ToFolder);
            if(controllerState == ContrallerState.EditFolder)
            {
                UpdateFolderDto updateFolder = new()
                {
                    Id = SelectedFolder.FirstOrDefault(),
                    Name = name,
                    ParentId = folderId
                };
                await EditFolder(updateFolder);
            }
            if(controllerState == ContrallerState.EditFile)
                RedirectToAction("RenameFile", "File", new { FileId = SelectedFile.FirstOrDefault(), filename =name });
            return RedirectToAction("Index", "Home", new { FolderId = folderId });
        }
        public enum ContrallerState
        {
            Remove,
            Move,
            EditFile,
            EditFolder
        }
    }
}
