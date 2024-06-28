using Filemanager.Application.Constract;
using Filemanager.Application.DTOS;
using FileManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FileManager.Web.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IFolderService _folderService;
        public FileController(IFolderService folderService, IFileService fileService)
        {
            _folderService = folderService;
            _fileService = fileService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFile([FromForm] AddFileDto addFile)
        {
            addFile.Name = Path.GetFileNameWithoutExtension(addFile.FileUpload.FileName);
            addFile.extension = Path.GetExtension(addFile.FileUpload.FileName);
            await _fileService.AddFiles(addFile);
            return RedirectToAction("Index", "Home", new { FolderId = addFile.FolderId });
        }
     
        public async Task<IActionResult> RenameFile(Guid FileId,string filename)
        {
            await _fileService.RenameFile(filename,FileId);
            return RedirectToAction("Index", "Home");
        }
    }
}
