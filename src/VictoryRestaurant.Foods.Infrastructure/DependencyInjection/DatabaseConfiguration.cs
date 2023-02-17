namespace VictoryRestaurant.Foods.Infrastructure.DependencyInjection;

public static class DatabaseConfiguration
{
    /// <summary> Add database configuration. </summary>
    /// <param name="services"> IoC. </param>
    /// <param name="configuration"> Configuration. </param>
    public static void AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<DbContext, ApplicationContext>();

        services.AddDbContext<ApplicationContext>(optionsAction: options =>
            options.UseNpgsql(
                connectionString: configuration.GetConnectionString(name: "PostgresConnection"),
                npsqlOptions => npsqlOptions.MigrationsAssembly(
                    assemblyName: Assembly.GetExecutingAssembly().GetName().Name)));
    }
}