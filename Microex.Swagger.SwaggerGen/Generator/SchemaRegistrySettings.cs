using System;
using System.Collections.Generic;
using Microex.Swagger.SwaggerGen.Model;

namespace Microex.Swagger.SwaggerGen.Generator
{
    public class SchemaRegistrySettings
    {
        public SchemaRegistrySettings()
        {
            CustomTypeMappings = new Dictionary<Type, Func<Schema>>();
            SchemaIdSelector = (type) => type.FriendlyId(false);
            SchemaFilters = new List<ISchemaFilter>();
        }

        public IDictionary<Type, Func<Schema>> CustomTypeMappings { get; private set; }

        public bool DescribeStringEnumsInCamelCase { get; set; }

        public bool AttachEnumDisplayNameMeta { get; set; }

        public Func<Type, string> SchemaIdSelector { get; set; }

        public bool IgnoreObsoleteProperties { get; set; }

        public IList<ISchemaFilter> SchemaFilters { get; private set; }

        internal SchemaRegistrySettings Clone()
        {
            return new SchemaRegistrySettings
            {
                CustomTypeMappings = CustomTypeMappings,
                DescribeStringEnumsInCamelCase = DescribeStringEnumsInCamelCase,
                IgnoreObsoleteProperties = IgnoreObsoleteProperties,
                AttachEnumDisplayNameMeta = AttachEnumDisplayNameMeta,
                SchemaIdSelector = SchemaIdSelector,
                SchemaFilters = SchemaFilters
            };
        }
    }
}