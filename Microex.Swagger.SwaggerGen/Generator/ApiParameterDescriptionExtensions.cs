using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Microex.Swagger.SwaggerGen.Generator
{
    public static class ApiParameterDescriptionExtensions
    {
        public static bool IsPartOfCancellationToken(this ApiParameterDescription parameterDescription)
        {
            if (parameterDescription.Source != BindingSource.ModelBinding) return false;

            var name = parameterDescription.Name;
            return name == "CanBeCanceled"
                || name == "IsCancellationRequested"
                || name.StartsWith("WaitHandle.");
        }

        public static bool IsRequired(this ApiParameterDescription parameterDescription)
        {
            if (parameterDescription.ParameterDescriptor is ControllerParameterDescriptor parameterDescriptor)
            {
                if (!parameterDescriptor.ParameterInfo.HasDefaultValue && parameterDescriptor.ParameterType.IsClass)
                {
                    return true;
                }
                if (parameterDescriptor.ParameterInfo.CustomAttributes.Any(x => x.AttributeType == typeof(RequiredAttribute)))
                {
                    throw new AmbiguousMatchException("Required parameter should never have a default value!");
                }
            }
           
            var modelMetadata = parameterDescription.ModelMetadata;
            return (modelMetadata == null) ? false : modelMetadata.IsRequired;
        }
    }
}
