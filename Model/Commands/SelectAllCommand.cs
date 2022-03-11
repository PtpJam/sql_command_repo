using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Commands
{
    class SelectAllCommand : ISqlCommand
    {
        public string _TableName { get; set; }
        public StringBuilder _Result { get; set; }
        public SelectAllCommand(string TableName)
        {
            _TableName = TableName;
            _Result = new StringBuilder();
        }
        public void Execute()
        {
            using (SqlCommand command = new SqlCommand("", SqlSingle.GetInstance()))
            {
                command.CommandText = $"SELECT * FROM {_TableName}";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        _Result.Append(reader.GetString(i));
                        _Result.Append(" ");
                    }
                    _Result.Append("\n");
                }

            }

        }

        public void Dispose()
        {
            GC.Collect(GC.GetGeneration(_TableName));
        }
    }
}
