﻿using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Twila.CrediCarro.BFF.Web.DependencyInjection.Options
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, new()
                {
                    Title = AppDomain.CurrentDomain.FriendlyName,
                    Version = description.ApiVersion.ToString()
                });

            options.CustomSchemaIds(type => type.ToString().Replace("+", "."));
        }
    }
}
