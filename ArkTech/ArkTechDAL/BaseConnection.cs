using System.Data.SqlClient;

namespace ArkTechDAL
{
    public class BaseConnection
    {
        public const string DB_CONNECTION_STRING = "Server=mssqlstud.fhict.local;Database=dbi511127_arktech;User Id=dbi511127_arktech;Password=ArkTechAdmin@2023;";
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(DB_CONNECTION_STRING);
        }
    }
} 