using SwiftparserData.Interfaces;
using SwiftparserData.Models;
using System.Data.SQLite;

namespace SwiftparserData.Repositories
{
    public class SwiftMessageRepository : ISwiftMessageRepository
    {
        private readonly IDbHelper dbHelper;

        public SwiftMessageRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }
        public async Task InsertSwiftMessage(SwiftMessage message)
        {
            using (var connection = dbHelper.OpenConnection(true))
            {
                // Define the SQL command to insert a SwiftMessage into the table
                var insertSql = @"
                    INSERT INTO [SwiftMessages] ([SenderCode], [MessageType], [TextBlock], [AuthenticationCode])
                    VALUES (@senderCode, @messageType, @textBlock, @authenticationCode);
                    SELECT last_insert_rowid();";

                // Create an SQLiteCommand object with the INSERT statement and parameters
                var insertCommand = new SQLiteCommand(insertSql, connection);
                insertCommand.Parameters.AddWithValue("@senderCode", message.SenderCode);
                insertCommand.Parameters.AddWithValue("@messageType", message.MessageType);
                insertCommand.Parameters.AddWithValue("@textBlock", message.TextBlock);
                insertCommand.Parameters.AddWithValue("@authenticationCode", message.AuthenticationCode);

                // Execute the command and retrieve the generated ID
                var generatedId = (long)await insertCommand.ExecuteScalarAsync();

                // Set the ID property of the SwiftMessage object
                message.Id = (int)generatedId;
            }
        }
    }
}
