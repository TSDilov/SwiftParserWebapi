using System.Data.SqlClient;
using System.Data.SQLite;

namespace SwiftparserData
{
    public class DbContext : IDbContext
    {
        private readonly IDbMigrator dbMigrator;

        public DbContext(IDbMigrator dbMigrator)
        {
            this.dbMigrator = dbMigrator;
        }

        public void CreateIfNotExist()
        {
            if (!File.Exists("Swift_Messages.sqlite"))
            {
                using (var connection = new SQLiteConnection("Data Source=Swift_Messages.sqlite;New=true"))
                {
                    connection.Open();

                    this.dbMigrator.CreateTables(connection);
                }
            }
        }
    }
}