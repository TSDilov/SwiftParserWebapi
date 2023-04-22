using SwiftparserData;

namespace SwiftParserWebapi
{
    public static class Configuration
    {
        public static void AddWebServices(this IServiceCollection services)
        {
            services.AddSingleton<IDbContext, DbContext>();
        }
    }
}
