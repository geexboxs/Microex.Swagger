﻿using Microex.Swagger.SwaggerGen.Model;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Microex.Swagger.SwaggerGen.Generator
{
    public interface IOperationFilter
    {
        void Apply(Operation operation, OperationFilterContext context);
    }

    public class OperationFilterContext
    {
        public OperationFilterContext(ApiDescription apiDescription, ISchemaRegistry schemaRegistry)
        {
            ApiDescription = apiDescription;
            SchemaRegistry = schemaRegistry;
        }

        public ApiDescription ApiDescription { get; private set; }

        public ISchemaRegistry SchemaRegistry { get; private set; }
    }
}
