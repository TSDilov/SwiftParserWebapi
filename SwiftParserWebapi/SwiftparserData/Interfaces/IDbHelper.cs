using System.Data.SQLite;

namespace SwiftparserData.Interfaces
{
    public interface IDbHelper
    {
        SQLiteConnection OpenConnection(bool isNew = false);
    }
}
