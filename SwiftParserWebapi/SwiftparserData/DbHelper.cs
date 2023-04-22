using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftparserData.Interfaces;

namespace SwiftparserData
{
    public class DbHelper : IDbHelper
    {
        public SQLiteConnection OpenConnection(bool isNew = false)
        {
            var connection = new SQLiteConnection($"Data Source=Swift_Messages.sqlite;New={isNew.ToString().ToLower()}");
            connection.Open();

            return connection;
        }
    }
}
