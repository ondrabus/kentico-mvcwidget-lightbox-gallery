using CMS.DataEngine;
using Kentico.Forms.Web.Mvc;

namespace Ondrabus.Kentico.Mvc.Widgets.LightboxGallery.TypeSelectorFormControl
{
    public class Properties : FormComponentProperties<Type>
    {
        [DefaultValueEditingComponent(LightboxGalleryTypeSelectorComponent.IDENTIFIER, DefaultValue = Type.Attachments)]
        public override Type DefaultValue
        {
            get; set;
        }

        public Properties() : base(FieldDataType.Unknown)
        {
        }
    }
}
