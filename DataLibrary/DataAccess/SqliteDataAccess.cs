using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.DataAccess
{
    public static class SqliteDataAccess
    {

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SQLiteConnection("Data Source=C:\\Users\\Dini Home\\source\\repos\\BondoraAngular1\\BondoraAngular1\\BondoraDB.db;Version=3;", true))
            {
                //cnn.Open();
                var output = cnn.Query<T>(sql, new DynamicParameters());

                return output.ToList();
                //Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SQLiteConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public static string GetConnectionString(string connectionName = "Default")
        {

            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            //return string "Data Source = C:\Users\Dini Home\source\repos\WebAPIapplicationTest\WebAPIapplicationTest\BondoraDB.db; Version = 3;";
        }
    }
}
