using System;
#if NET45
using System.Web.Mvc;
#else
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
#endif
namespace Canducci.ZipCodePostmon.Web
{ //http://www.hackered.co.uk/articles/globalization-model-binding-datetimes-with-asp-net-mvc
#if NET45
    public class ZipCodeNumberBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new Exception(nameof(bindingContext));
            }
            var value = bindingContext.ValueProvider.GetValue("ZipCodeRequestValue");
            if (!string.IsNullOrWhiteSpace(value.AttemptedValue))
            { 
                if (ZipCodeNumber.TryParse(value.AttemptedValue, out ZipCodeNumber zipCodeNumber))
                {
                    return zipCodeNumber;
                }
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Format ZipCode Error");
            }
            return null;
        }
    }
#else
    public class ZipCodeNumberBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new Exception(nameof(bindingContext));
            }

            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue("ZipCodeRequestValue");

            if (valueProviderResult != ValueProviderResult.None)
            {
                string value = valueProviderResult.FirstValue;
                if (ZipCodeNumber.TryParse(value, out _))
                {
                    bindingContext.Result = ModelBindingResult.Success(new ZipCodeNumber(value));
                }
                else
                {
                    bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Format ZipCode Error");
                }
            }
#if NET451 || NET452
            return Task.FromResult(0); //return new Task(() => { });
#else
            return Task.CompletedTask;
#endif
        }
    }
#endif
}
