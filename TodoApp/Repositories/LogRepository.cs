using System.Collections.Generic;
using System.Linq;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public class LogRepository : ILog
    {
        private static ApplicationDbContext _context;

        public LogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Log log)
        {
            if (_context == null)
            {
                return 1;
            }
            _context.Logs.Add(log);
            return _context.SaveChanges();

        }

        public IEnumerable<Log> FindAll()
        {
            return _context.Logs.ToList();
        }

        public Log FindOne(int id)
        {
            return _context.Logs.Single(l => l.Id == id);
        }

        public void Remove(Log log)
        {
            if (log.Id > 0)
                _context.Logs.Remove(log);
        }
    }
}
