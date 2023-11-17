using System;
using System.Data.SqlClient;
using System.IO;

namespace ArkTechDAL
{
    public class SqlExceptionLogger
    {
        private string logFilePath;

        public SqlExceptionLogger()
        {
            string solutionDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logsFolder = Path.Combine(solutionDirectory, "Logs");
            logFilePath = Path.Combine(logsFolder, "error.log");
        }

        public void LogSqlException(SqlException ex)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine($"Log Entry: {DateTime.Now}");
                    writer.WriteLine($"Type: {ex.GetType().Name}");
                    writer.WriteLine($"Message: {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    writer.WriteLine(new string('-', 30));
                }
            }
            catch (Exception logEx)
            {
                Console.WriteLine($"Error writing to log file: {logEx.Message}");
            }
        }
    }
}
