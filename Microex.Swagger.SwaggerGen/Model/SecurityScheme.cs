using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microex.Swagger.SwaggerGen.Model
{
    public abstract class SecurityScheme
    {
        public SecurityScheme()
        {
            Extensions = new Dictionary<string, object>();
        }

        public string Type { get; set; }

        public string Description { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; private set; }
    }
}
