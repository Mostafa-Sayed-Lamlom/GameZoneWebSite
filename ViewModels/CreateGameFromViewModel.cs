
using GameZone.Attributes;

namespace GameZone.ViewModels
{
    public class CreateGameFromViewModel : ViewModelBaseClass
    {
        [AllowedExtensions(FileSettings.AllowedExtensions)]
        [MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
    }
}
