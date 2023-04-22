using System.Data.SQLite;

namespace SwiftparserData
{
    public class DbContext : IDbContext
    {
        public void CreateIfNotExist()
        {
            if (!File.Exists("Swift_Messages.sqlite"))
            {
                using (var connection = new SQLiteConnection("Data Source=Swift_Messages.sqlite;New=true"))
                {
                    connection.Open();

                    // Perform database operations here...
                }
            }
        }
    }
}