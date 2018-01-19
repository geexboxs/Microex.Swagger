﻿using System.Collections.Generic;
using System.Linq;
using Microex.Swagger.SwaggerGen.Generator;
using Microex.Swagger.SwaggerGen.Model;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Microex.Swagger.SwaggerGen.Annotations
{
    public class SwaggerResponseAttributeFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var apiDesc = context.ApiDescription;
            var attributes = GetActionAttributes(apiDesc);

            if (!attributes.Any())
                return;

            if (operation.Responses == null)
            {
                operation.Responses = new Dictionary<string, Response>();
            }

            foreach (var attribute in attributes)
            {
                ApplyAttribute(operation, context, attribute);
            }
        }

        private static void ApplyAttribute(Operation operation, OperationFilterContext context, SwaggerResponseAttribute attribute)
        {
            var key = attribute.StatusCode.ToString();
            Response response;
            if (!operation.Responses.TryGetValue(key, out response))
            {
                response = new Response();
            }

            if (attribute.Description != null)
                response.Description = attribute.Description;

            if (attribute.Type != null && attribute.Type != typeof(void))
                response.Schema = context.SchemaRegistry.GetOrRegister(attribute.Type);

            operation.Responses[key] = response;
        }

        private static IEnumerable<SwaggerResponseAttribute> GetActionAttributes(ApiDescription apiDesc)
        {
            var controllerAttributes = apiDesc.ControllerAttributes().OfType<SwaggerResponseAttribute>();
            var actionAttributes = apiDesc.ActionAttributes().OfType<SwaggerResponseAttribute>();
            return controllerAttributes.Union(actionAttributes);
        }
    }
}
