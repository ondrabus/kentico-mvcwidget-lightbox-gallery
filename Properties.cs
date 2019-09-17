using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Ondrabus.Kentico.Mvc.Widgets.LightboxGallery.TypeSelectorFormControl;
using System.Collections;
using System.Collections.Generic;

namespace Ondrabus.Kentico.Mvc.Widgets.LightboxGallery
{
    public class Properties : IWidgetProperties
    {
        [EditingComponent(LightboxGalleryTypeSelectorComponent.IDENTIFIER, Order = 1)]
        public Type Type { get; set; }
        [EditingComponent(MediaFilesSelector.IDENTIFIER, Order = 2)]
        [EditingComponentProperty(nameof(MediaFilesSelectorProperties.MaxFilesLimit), 0)]
        public IEnumerable<MediaFilesSelectorItem> MediaFiles { get; set; }
        [EditingComponent(TextAreaComponent.IDENTIFIER, Order = 3)]
        public string External { get; set; }
    }
}
