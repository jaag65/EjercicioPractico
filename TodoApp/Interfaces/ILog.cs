using System.Collections.Generic;
using TodoApp.Models;

namespace TodoApp.Interfaces
{
    public interface ILog
    {
        int Add(Log log);
        IEnumerable<Log> FindAll();
        Log FindOne(int id);
        void Remove(Log log);
    }
}
