using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Commands
{
   class CreateTable : ISqlCommand  
    {
        public Dictionary<string, string> _Columns { get; set; }
        public string _TableName { get; set; }
        public CreateTable(Dictionary<string, string> columns, string TableName)
        {
            _Columns = columns;
            _TableName = TableName;
        }

        public void Execute()
        {
            using (SqlCommand command = new SqlCommand("", SqlSingle.GetInstance()))
            {
                StringBuilder commText = new StringBuilder();
                foreach (var item in _Columns)
                {
                    commText.Append($"{item.Key} {item.Value} NOT NULL,");
                }
                command.CommandText = $"CREATE TABLE {_TableName}(";
                command.CommandText += $" {commText.ToString()}";
                command.CommandText += $");";

                command.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            GC.Collect(GC.GetGeneration(_Columns));
            GC.Collect(GC.GetGeneration(_TableName));
        }
    }
}
