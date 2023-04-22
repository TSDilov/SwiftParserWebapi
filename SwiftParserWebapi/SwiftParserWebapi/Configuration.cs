using SwiftparserData;

namespace SwiftParserWebapi
{
    public static class Configuration
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddSingleton<IDbMigrator, DbMigrator>();
            services.AddSingleton<IDbContext, DbContext>();
        }
    }
}
