using SwiftparserData;
using SwiftparserData.Interfaces;

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
    }
}
