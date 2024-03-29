﻿namespace VictoryRestaurant.Foods.Presentation.Configurations;

internal static class LoggingConfiguration
{
    /// <summary> Enable logging configuration. </summary>
    /// <param name="services"> IoC. </param>
    /// <param name="hostBuilder"> Builder. </param>
    public static void AddLoggingConfiguration(
        this IServiceCollection services,
        ConfigureHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog(
            configureLogger: (context, services, configuration) =>
                configuration.ReadFrom.Configuration(configuration: context.Configuration)
                .ReadFrom.Services(services));

        services.AddHttpContextAccessor();
    }
}