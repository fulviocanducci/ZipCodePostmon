#if NET45
using System.Web.Mvc;
#else
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
#endif
using System.Linq;

namespace Canducci.ZipCodePostmon.Web
{
    public static class ZipCodeNumberHelpers
    {
#if NET45
        public static MvcHtmlString ZipCodeNumberTextBox(this HtmlHelper helper, object htmlAttributes = null)
        {
            var value = "";
            if (helper.ViewData["ZipCodeRequestValue"] != null)
            {
                value = helper.ViewData["ZipCodeRequestValue"].ToString();
            }            
            var tagZipCodeNumberTextBox = new TagBuilder("input");
            tagZipCodeNumberTextBox.MergeAttribute("type", "text");
            tagZipCodeNumberTextBox.MergeAttribute("value", value);
            tagZipCodeNumberTextBox.MergeAttribute("name", "ZipCodeRequestValue");
            tagZipCodeNumberTextBox.MergeAttribute("id", "ZipCodeRequestValue");
            if (htmlAttributes != null)
            {
                var attrs = htmlAttributes.GetType();
                foreach (var attr in attrs.GetProperties())
                {
                    if (tagZipCodeNumberTextBox.Attributes.Keys.Any(x => x == attr.Name))
                    {
                        tagZipCodeNumberTextBox.Attributes[attr.Name] = attr.GetValue(attrs).ToString();
                    }
                    else
                    {
                        tagZipCodeNumberTextBox.MergeAttribute(attr.Name, attr.GetValue(attrs).ToString());
                    }
                }
            }
            return new MvcHtmlString(tagZipCodeNumberTextBox.ToString());            
        }
#else
        public static IHtmlContent ZipCodeNumberTextBox(this IHtmlHelper helper, object htmlAttributes = null)
        {            
            return helper.TextBox("ZipCodeRequestValue", helper.ViewData["ZipCodeRequestValue"] ?? null, htmlAttributes);
        }
#endif
    }
}
