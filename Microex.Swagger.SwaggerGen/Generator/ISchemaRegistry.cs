using System;
using System.Collections.Generic;
using Microex.Swagger.SwaggerGen.Model;

namespace Microex.Swagger.SwaggerGen.Generator
{
    public interface ISchemaRegistry
    {
        Schema GetOrRegister(Type type);

        IDictionary<string, Schema> Definitions { get; }
    }
}
