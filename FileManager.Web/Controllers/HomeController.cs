using Filemanager.Application.Constract;
using FileManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FileManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileService _fileService;
        private readonly IFolderService _folderService;


        public HomeController(ILogger<HomeController> logger, IFolderService folderService ,IFileService fileService)
        {
            _logger = logger;
            _folderService = folderService;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index(Guid FolderId)
        {
            if (FolderId == Guid.Empty)
            {
                var folder = await _folderService.GetAllFolder();
                var File = await _fileService.GetAllFiles();
                MainModel model = new MainModel();
                model.Folder = folder;
                model.File = File;
                return View(model);
            }
            else
            {
                var folder = await _folderService.GetFolderByFolder(FolderId);
                var File = await _fileService.GetAllFileByFolder(FolderId);
                MainModel model = new MainModel();
                model.FolderId = FolderId;
                model.Folder = folder;
                model.File = File;
                return View(model);
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
