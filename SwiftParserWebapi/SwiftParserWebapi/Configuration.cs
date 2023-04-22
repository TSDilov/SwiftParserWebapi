using SwiftparserData;
using SwiftparserData.Interfaces;
using SwiftparserData.Repositories;
using SwiftParserServices;

namespace SwiftParserWebapi
{
    public static class Configuration
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddSingleton<IDbHelper, DbHelper>();
            services.AddSingleton<IDbMigrator, DbMigrator>();
            services.AddSingleton<IDbContext, DbContext>();
        }

        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ISwiftParserService, SwiftParserService>();
        }

        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<ISwiftMessageRepository, SwiftMessageRepository>();
        }
    }
}
