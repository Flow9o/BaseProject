using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

public class MakeOptionalPropertiesRequiredAndNullableSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema?.Properties == null)
        {
            return;
        }

        var optionalPropertyNames = schema.Properties.Keys
            .Except(schema.Required ?? Enumerable.Empty<string>())
            .ToList();

        foreach (var propertyName in optionalPropertyNames)
        {
            if (schema.Properties.TryGetValue(propertyName, out var propertySchema))
            {
                if (schema.Required == null)
                {
                    schema.Required = new HashSet<string>();
                }
                schema.Required.Add(propertyName);

                propertySchema.Nullable = true;
            }
        }
    }
}