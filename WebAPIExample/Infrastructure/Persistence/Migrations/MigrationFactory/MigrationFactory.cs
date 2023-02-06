using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace Infrastructure.Persistence.Migrations.MigrationFactory
{
    public class MigrationFactory : IMigrationFactory
    {
        private readonly IServiceProvider serviceProvider;
        private readonly AppDBContext appDBContext;
        private readonly DbConnection dbConnection;
        public MigrationFactory(IServiceProvider _serviceProvider)
        {
            serviceProvider = _serviceProvider;
            appDBContext = serviceProvider.GetService<AppDBContext>()!;
            dbConnection = appDBContext!.Database.GetDbConnection();
        }
        public async Task Migrate()
        {
            Console.WriteLine($"Actual AppDB connection: {dbConnection.ToString()} {Environment.NewLine} {dbConnection.ConnectionString}");
            Console.WriteLine("******Accessing...******");
            try
            {
                Console.WriteLine("********Base entity is able: " + appDBContext.Database.CanConnect());
                await appDBContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"********Error connecting: {ex.Message}");
            }
        }
    }
}
