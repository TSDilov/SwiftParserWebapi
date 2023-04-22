using SwiftparserData.Interfaces;
using SwiftparserData.Models;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace SwiftparserData
{
    public class DbMigrator : IDbMigrator
    {
        public void CreateTables(SQLiteConnection connection)
        {
            CreateSwiftMessages(connection);
        }

        private static void CreateSwiftMessages(SQLiteConnection connection)
        {
            var createTableSql = @"
            CREATE TABLE [SwiftMessages] (
                [Id] INTEGER PRIMARY KEY AUTOINCREMENT,
                [SenderCode] TEXT NOT NULL,
                [MessageType] TEXT NOT NULL,
                [TextBlock] TEXT NOT NULL,
                [AuthenticationCode] TEXT NOT NULL
            )";

            var createTableCommand = new SQLiteCommand(createTableSql, connection);
            createTableCommand.ExecuteNonQuery();

            
        }
    }
}
