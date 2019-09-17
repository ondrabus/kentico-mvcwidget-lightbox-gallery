using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using CMS.DocumentEngine;
using CMS.MediaLibrary;
using Ondrabus.Kentico.Mvc.Widgets.LightboxGallery;

//[assembly: RegisterWidget("KenticoCommunity.BingMapsWidget", typeof(BingMapsWidgetController), "Bing Maps widget", Description = "Shows Bing map", IconClass = "icon-brand-bing")]
[assembly: RegisterWidget("LightboxGalleryWidget", typeof(LightboxWidgetController), "Lightbox Gallery", Description = "Widget displaying list of images as a lightbox gallery", IconClass = "icon-pictures")]
namespace Ondrabus.Kentico.Mvc.Widgets.LightboxGallery
{
    public class LightboxWidgetController : WidgetController<Properties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();
            IEnumerable<Picture> pictures = new List<Picture>();

            switch (properties.Type)
            {
                case Type.Attachments:
                    pictures = this.GetPage().Attachments.ToList().Where(a => a.AttachmentImageWidth > 0).Select(a => new Picture
                    {
                        Url = CMS.DocumentEngine.AttachmentURLProvider.GetAttachmentUrl(a.AttachmentName, this.GetPage().NodeAliasPath),
                        AltText = a.AttachmentTitle,
                        Thumbnail = $"{AttachmentURLProvider.GetAttachmentUrl(a.AttachmentName, this.GetPage().NodeAliasPath)}?maxsidesize=128"
                    });
                    break;

                case Type.MediaLibraryFolder:
                    /*var library = MediaLibraryInfoProvider.GetMediaLibraryInfo(properties.MediaLibraryFolder, this.GetPage().NodeSiteName);
                    if (string.IsNullOrEmpty(properties.MediaLibraryFolder))
                    {
                        properties.MediaLibraryFolder = "%";
                    }
                    var files = MediaFileInfoProvider.GetMediaFiles($"{nameof(MediaFileInfo.FileLibraryID)}={library.LibraryID} AND {nameof(MediaFileInfo.FilePath)} LIKE '{properties.MediaLibrarySubfolder}%'");
                    pictures = files.ToList().Select(f => new Picture
                    {
                        Url = MediaLibraryHelper.GetMediaFileUrl(f.FileGUID, this.GetPage().NodeSiteName),
                        AltText = f.FileTitle,
                        Thumbnail = $"{MediaFileURLProvider.GetMediaFileAbsoluteUrl(this.GetPage().NodeSiteName, f.FileGUID, f.FileName)}?maxsidesize=120"
                    });*/
                    if (properties.MediaFiles != null)
                    {
                        pictures = properties.MediaFiles.Select(m => new Picture
                        {
                            Url = MediaLibraryHelper.GetMediaFileUrl(m.FileGuid, this.GetPage().NodeSiteName),
                            AltText = MediaFileInfoProvider.GetMediaFileInfo(m.FileGuid, this.GetPage().NodeSiteName).FileTitle,
                            Thumbnail = $"{MediaFileURLProvider.GetMediaFileAbsoluteUrl(this.GetPage().NodeSiteName, m.FileGuid, MediaFileInfoProvider.GetMediaFileInfo(m.FileGuid, this.GetPage().NodeSiteName).FileName)}?maxsidesize=128"
                        });
                    }
                    break;

                case Type.External:
                    pictures = properties.External.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Select(f => new Picture
                    {
                        Url = f,
                        AltText = f,
                        Thumbnail = f
                    });
                    break;
            }

            var viewModel = new ViewModel
            {
                Pictures = pictures
            };
            return PartialView("Widgets/_LightboxGallery", viewModel);
        }
    }
}
