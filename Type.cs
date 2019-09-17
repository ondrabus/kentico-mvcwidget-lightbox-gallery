
using System.ComponentModel;

namespace Ondrabus.Kentico.Mvc.Widgets.LightboxGallery
{
    public enum Type
    {
        [Description("Attachments")]
        Attachments = 1,
        [Description("Media library files")]
        MediaLibraryFolder = 2,
        [Description("Externally hosted images")]
        External = 4
    }
}
