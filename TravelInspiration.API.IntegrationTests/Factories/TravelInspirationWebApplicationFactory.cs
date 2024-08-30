using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace TravelInspiration.API.IntegrationTests.Factories;

public sealed class TravelInspirationWebApplicationFactory : WebApplicationFactory<Program>
{
	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureAppConfiguration(
			(_, configBuilder) =>
			{
				configBuilder.AddInMemoryCollection(
					new Dictionary<string, string?>
					{
						{
							"ConnectionStrings:TravelInspirationDbConnection",
							"Server=localhost,1433;Initial Catalog=TravelInspirationDb_IntegrationTests;User Id=SA;Password=d0_n0t_be_l@zy_h3r3;Trusted_Connection=False;TrustServerCertificate=True;"
						}
					}
				);
			}
		);

		base.ConfigureWebHost(builder);
	}
}
