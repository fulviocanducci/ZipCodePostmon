using System.Threading.Tasks;
#if NETSTANDARD2_0 || NETCOREAPP2_0 || NETCOREAPP2_1
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
#endif
namespace Canducci.ZipCodePostmon.Web
{
#if NETSTANDARD2_0 || NETCOREAPP2_0 || NETCOREAPP2_1

    [HtmlTargetElement("zipcode-textbox", Attributes = cTextBoxClass)]
    [HtmlTargetElement("zipcode-textbox", Attributes = cTextBoxMaxLength)]
    [HtmlTargetElement("zipcode-textbox", Attributes = cTextBoxAutoFocus)]
    [HtmlTargetElement("zipcode-textbox", Attributes = cTextBoxDisabled)]
    [HtmlTargetElement("zipcode-textbox", Attributes = cTextBoxPlaceholder)]
    public class ZipCodeNumberTextBoxTagHelper: TagHelper
    {
        protected const string cTextBoxClass = "textbox-class";
        protected const string cTextBoxMaxLength = "textbox-max-length";
        protected const string cTextBoxAutoFocus = "textbox-auto-focus";
        protected const string cTextBoxDisabled = "textbox-disabled";
        protected const string cTextBoxPlaceholder = "textbox-placeholder";

        [HtmlAttributeName(cTextBoxClass)]
        public string TextBoxClass { get; set; } = "";

        [HtmlAttributeName(cTextBoxMaxLength)]
        public int MaxLength { get; set; } = 10;

        [HtmlAttributeName(cTextBoxAutoFocus)]
        public bool AutoFocus { get; set; } = false;

        [HtmlAttributeName(cTextBoxDisabled)]
        public bool Disabled { get; set; } = false;

        [HtmlAttributeName(cTextBoxPlaceholder)]
        public string Placeholder { get; set; } = "Number ...";

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Render(context, output);
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            if (childContent.IsEmptyOrWhiteSpace)
            {
                Render(context, output);
            }
        }

        protected void Render(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.SetAttribute("type", "text");
            output.Attributes.SetAttribute("name", "ZipCodeRequestValue");
            output.Attributes.SetAttribute("id", "ZipCodeRequestValue");
            output.Attributes.SetAttribute("maxlength", MaxLength);
            if (!string.IsNullOrEmpty(Placeholder))
            {
                output.Attributes.SetAttribute("placeholder", Placeholder);
            }
            if (AutoFocus)
            {
                output.Attributes.SetAttribute("autofocus", "autofocus");
            }
            if (Disabled)
            {
                output.Attributes.SetAttribute("disabled", "disabled");
            }
            if (!string.IsNullOrEmpty(TextBoxClass))
            {
                output.Attributes.SetAttribute("class", TextBoxClass);
            }
            if (ViewContext.ViewData["ZipCodeRequestValue"] != null)
            {
                output.Attributes.SetAttribute("value", ViewContext.ViewData["ZipCodeRequestValue"].ToString());
            }
        }
    }

#endif
}
