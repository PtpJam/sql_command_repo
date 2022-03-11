using System;

namespace ConsoleApp1.Model
{
    internal interface ISqlCommand : IDisposable
    {
        void Execute();
    }
}
