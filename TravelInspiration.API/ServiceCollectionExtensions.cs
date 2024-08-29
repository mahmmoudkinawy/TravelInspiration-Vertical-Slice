using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TravelInspiration.API.Shared.Behaviours;
using TravelInspiration.API.Shared.Matrices;
using TravelInspiration.API.Shared.Networking;
using TravelInspiration.API.Shared.Persistence;
using TravelInspiration.API.Shared.Security;
using TravelInspiration.API.Shared.Slices;

namespace TravelInspiration.API;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
	{
		services.AddScoped<IDestinationSearchApiClient, DestinationSearchApiClient>();

		services.RegisterSlices();

		var currentAssembly = Assembly.GetExecutingAssembly();

		services.AddAutoMapper(currentAssembly);

		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssemblies(currentAssembly);
			cfg.AddOpenRequestPreProcessor(typeof(LoggingBehaviour<>));
			cfg.AddOpenBehavior(typeof(ModelValidationBehaviour<,>));
			cfg.AddOpenBehavior(typeof(HandlerPerformanceMetricBehaviour<,>));
		});

		services.AddValidatorsFromAssembly(currentAssembly);

		services.AddSingleton<HandlerPerformanceMetric>();

		services.AddScoped<ICurrentUserService, CurrentUserService>();

		return services;
	}

	public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration config)
	{
		services.AddDbContext<TravelInspirationDbContext>(options =>
			options.UseSqlServer(config.GetConnectionString("TravelInspirationDbConnection"))
		);

		return services;
	}
}
