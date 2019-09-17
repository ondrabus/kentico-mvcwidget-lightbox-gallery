using Kentico.Forms.Web.Mvc;
using Ondrabus.Kentico.Mvc.Widgets.LightboxGallery.TypeSelectorFormControl;
using System;

[assembly: RegisterFormComponent(LightboxGalleryTypeSelectorComponent.IDENTIFIER, typeof(LightboxGalleryTypeSelectorComponent), "Type selector", Description = "Enables editors to select type of lightbox gallery source.", IconClass = "icon-palette")]
namespace Ondrabus.Kentico.Mvc.Widgets.LightboxGallery.TypeSelectorFormControl
{
    public class LightboxGalleryTypeSelectorComponent : FormComponent<Properties, Type>
    {
        public const string IDENTIFIER = "LightboxGalleryTypeSelectorComponent";

        [BindableProperty]
        public Type Type { get; set; } = Type.Attachments;

        public override Type GetValue()
        {
            return this.Type;
        }

        public override void SetValue(Type value)
        {
            this.Type = value;
        }
    }
}
