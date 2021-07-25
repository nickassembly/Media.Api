using Media.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Media.Api.Infrastructure
{
	public static class StartupSetup
	{
		// TODO: Need to create in SQL Server, and check startup class
		public static void AddDbContext(this IServiceCollection services, string connectionString) =>
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlite(connectionString)); // will be created in web project root
	}
}
