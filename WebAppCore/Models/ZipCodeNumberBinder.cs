using Canducci.ZipCodePostmon;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;
//https://docs.microsoft.com/pt-br/aspnet/core/mvc/advanced/custom-model-binding?view=aspnetcore-2.2
namespace WebAppCore.Models
{
    public class ZipCodeNumberBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new Exception(nameof(bindingContext));
            }

            var value = bindingContext.ValueProvider.GetValue("Value").ToString();

            if (ZipCodeNumber.TryParse(value, out _))
            {
                bindingContext.Result = ModelBindingResult.Success((ZipCodeNumber)"01414000");
            }
            else
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Format ZipCode Error");
            }
            return Task.CompletedTask;
        }
    }
}
