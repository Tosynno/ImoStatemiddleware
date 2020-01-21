using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImoStatemiddleware.Utility
{
    public class BasicAuthFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var securityRequirements = new Dictionary<string, IEnumerable<string>>()
            {
                { "Basic", new string[] { }} };

            swaggerDoc.Security = new[]
            {
                securityRequirements
            };
        }
    }
}
