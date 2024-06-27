
namespace Filemanager.Application.Tools
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                #region File
                config.CreateMap<Files, FileDto>().ReverseMap();
                config.CreateMap<AddFileDto, Files>();
                
                #endregion

                #region Folder
                config.CreateMap<Folder, FolderDto>().ReverseMap();
                config.CreateMap<AddFolderDto, Folder>();
                config.CreateMap<UpdateFolderDto, Folder>();
                #endregion
            });
            return mapperConfiguration;
        }
    }
}
