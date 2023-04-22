using System.Data.SqlClient;
using System.Data.SQLite;

namespace SwiftparserData
{
    public interface IDbMigrator
    {
        void CreateTables(SQLiteConnection connection);
    }
}