using System.Data.SqlClient;
using System.Data.SQLite;

namespace SwiftparserData.Interfaces
{
    public interface IDbMigrator
    {
        void CreateTables(SQLiteConnection connection);
    }
}