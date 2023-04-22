using System.Data.SqlClient;
using System.Data.SQLite;
using SwiftparserData.Interfaces;

namespace SwiftparserData
{
    public class DbContext : IDbContext
    {
        private readonly IDbMigrator dbMigrator;
        private readonly IDbHelper dbHelper;

        public DbContext(IDbMigrator dbMigrator, IDbHelper dbHelper)
        {
            this.dbMigrator = dbMigrator;
            this.dbHelper = dbHelper;
        }

        public void CreateIfNotExist()
        {
            if (!File.Exists("Swift_Messages.sqlite"))
            {
                using (var connection = this.dbHelper.OpenConnection(true))
                {
                    this.dbMigrator.CreateTables(connection);
                }
            }
        }
    }
}