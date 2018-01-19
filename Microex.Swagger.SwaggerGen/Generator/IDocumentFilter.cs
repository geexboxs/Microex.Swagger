﻿using Microex.Swagger.SwaggerGen.Model;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Microex.Swagger.SwaggerGen.Generator
{
    public interface IDocumentFilter
    {
        void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context);
    }

    public class DocumentFilterContext
    {
        public DocumentFilterContext(
            ApiDescriptionGroupCollection apiDescriptionsGroups,
            ISchemaRegistry schemaRegistry)
        {
            ApiDescriptionsGroups = apiDescriptionsGroups;
            SchemaRegistry = schemaRegistry;
        }

        public ApiDescriptionGroupCollection ApiDescriptionsGroups { get; private set; }

        public ISchemaRegistry SchemaRegistry { get; private set; }
    }
}
