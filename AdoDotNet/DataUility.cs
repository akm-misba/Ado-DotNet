using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNet
{
    public class DataUility
    {
        private string _connectionString;
        public DataUility(string connectionString)
        {
            _connectionString = connectionString;
        }
        private SqlCommand CreateCommand(string sql)
        {
             SqlConnection connection = new SqlConnection(_connectionString);
             SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = sql;
            return command;

        }

        public void ExecuteCommand(string sql)
        {
            //string connectionString = "Server=DESKTOP-IDIVHCD\\SQLEXPRESS;Database=AdoDotNet;User Id=AdoDotNet;Password=123456;";
            // using SqlConnection connection = new SqlConnection(_connectionString);
            // connection.ConnectionString= connectionString; 
            //var sql = "insert into Students(Id,[Name],CGPA,DateOfBirth)Values (5,'Misbahul',3.52,'1-1-2022')";
            // SqlCommand command = new SqlCommand("sql", connection);
            // using SqlCommand command =new SqlCommand();
            //command.Connection = connection;
            //command.CommandText = sql;
           using var command = CreateCommand(sql);
            if (command.Connection.State != System.Data.ConnectionState.Open)
               command.Connection.Open();
            command.ExecuteNonQuery();
           // connection.Close();
            //command.Dispose();
            //connection.Dispose(); using jonn0 commont korlam 

        }
        public List<Dictionary<string, object>> ExecuteQuery(string query)
        {
            using var command = CreateCommand(query);
            if (command.Connection.State != System.Data.ConnectionState.Open)
                command.Connection.Open();
           using SqlDataReader reader= command.ExecuteReader();
            List<Dictionary<string, object>> values = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)

                {
                   

                    row.Add(reader.GetName(i), reader.GetValue(i));
                }
                values.Add(row);
                
                //int id = (int)reader["ID"];
                //string name = (string)reader["Name"];
                //decimal cgpa = (decimal)reader["CGPA"];
                //DateTime dateOfBirth = (DateTime)reader["DateOfBirth"];

                //Console.WriteLine($"Id={id},Name={name},CGPA={cgpa},DateOfBirth={dateOfBirth}");
            }
            return values;
            
        }
    }
}
