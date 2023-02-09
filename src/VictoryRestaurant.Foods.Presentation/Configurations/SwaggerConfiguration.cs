﻿namespace VictoryRestaurant.Foods.Presentation.Configurations;

internal static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(
        this IServiceCollection services)
    {
        services.AddSwaggerGen(setupAction: options =>
        {
            options.CustomOperationIds(
                operationIdSelector: selector =>
                @$"{Regex.Replace(
                    input: selector?.RelativePath ?? string.Empty,
                    pattern: "{|}",
                    replacement: string.Empty)}{selector?.HttpMethod}");

            options.SwaggerDoc(name: "v1", info: new OpenApiInfo
            {
                Title = Assembly.GetExecutingAssembly().GetName().Name,
                Version = $"v{Assembly.GetExecutingAssembly().GetName().Version}"
            });

            Span<string?> xmlFiles = Directory.GetFiles(
                path: AppContext.BaseDirectory,
                searchPattern: "*.xml",
                searchOption: SearchOption.TopDirectoryOnly);

            foreach (var xmlFile in xmlFiles)
            {
                options.IncludeXmlComments(filePath: xmlFile);
            }
        });
    }

    public static void UseSwaggerSetup(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(setupAction: setup =>
        {
            setup.SwaggerEndpoint(
                url: "/swagger/v1/swagger.json",
                name: $"{Assembly.GetExecutingAssembly().GetName().Name} v1");
        });
    }
}