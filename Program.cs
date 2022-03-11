using ConsoleApp1.Model.Commands;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = SqlSingle.GetInstance().ClientConnectionId.ToString();

            //new CreateTable(
            //    new System.Collections.Generic.Dictionary<string, string>()
            //    {
            //        {"[NAME_1]", "varchar(255)" },
            //        {"[NAME_2]", "varchar(255)" },
            //        {"[NAME_3]", "varchar(255)" }
            //    }, "[TEST_TABLE]").Execute();

            //new InsertCommand("[TEST_TABLE]",
            //    new List<string>()
            //    { "\'[TEST_1]\'",
            //    "\'[TEST_2]\'",
            //    "\'[TEST_3]\'"
            //    }
            //   ).Execute();
            var res = new SelectAllCommand("[TEST_TABLE]");
            res.Execute();
            Console.WriteLine(res._Result);
        }
    }
}
