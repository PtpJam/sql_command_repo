using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Commands
{
    class InsertCommand : ISqlCommand
    {
        public string _TableName { get; set; }
        public List<string> _Values { get; set; }

        public InsertCommand(string tableName, List<string> values)
        {
            _TableName = tableName;
            _Values = values;
        }

        public void Execute()
        {
            using (SqlCommand command = new SqlCommand("", SqlSingle.GetInstance()))
            {
                
                command.CommandText = $"INSERT INTO {_TableName} VALUES({String.Join(",", _Values)});";
                command.ExecuteNonQuery();
            }
        }
        public void Dispose()
        {
            GC.Collect(GC.GetGeneration(_TableName));
            GC.Collect(GC.GetGeneration(_Values));
        }

    }
}
