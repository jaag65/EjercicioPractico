using System;
using TodoApp.Interfaces;
using TodoApp.Models;
using TodoApp.Repositories;

namespace TodoApp.Infrastructure
{


    public class JobLogger

    {

        private static bool _logToFile;

        private static bool _logToConsole;

        private static bool _logMessage;

        private static bool _logWarning;

        private static bool _logError;

        private static bool _logToDatabase;

        private bool _initialized;

        private readonly ApplicationDbContext _context;


        public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, bool logMessage, bool logWarning, bool logError, ApplicationDbContext context = null)

        {
            _context = context;
            _logError = logError;
            _logMessage = logMessage;
            _logWarning = logWarning;
            _logToDatabase = logToDatabase;
            _logToFile = logToFile;
            _logToConsole = logToConsole;
        }


        public void LogMessage(string logText, bool message, bool warning, bool error)

        {
            ILog logs = new LogRepository(_context);

            var text = logText.Trim();

            if (text.Length == 0)

            {

                return;

            }

            if (!_logToConsole && !_logToFile && !_logToDatabase)

            {

                throw new Exception("Invalid configuration");

            }

            if ((!_logError && !_logMessage && !_logWarning) || (!message && !warning && !error))

            {

                throw new Exception("Error or Warning or Message must be specified");

            }

            if (_logToDatabase)
            {
                var t = 0;

                if (message && _logMessage)

                {

                    t = (int)LogType.Message;

                }

                if (error && _logError)

                {

                    t = (int)LogType.Error;

                }

                if (warning && _logWarning)

                {

                    t = (int)LogType.Warning;

                }

                var log = new Log
                {
                    Message = logText,
                    Type = (LogType)t
                };

                logs.Add(log);

            }

            if (_logToFile)
            {
                var l = "";

                if (System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToString("ddMMyyyy") + ".txt"))
                {
                    l = System.IO.File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToString("ddMMyyyy") + ".txt");
                }

                if (error && _logError)
                {

                    l = l + DateTime.Now.ToShortDateString() + text;

                }

                if (warning && _logWarning)
                {

                    l = l + DateTime.Now.ToShortDateString() + text;

                }

                if (message && _logMessage)
                {

                    l = l + DateTime.Now.ToShortDateString() + text;

                }

                System.IO.File.WriteAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToString("ddMMyyyy") + ".txt", l);
            }

            if (_logToConsole)
            {

                if (error && _logError)

                {

                    Console.ForegroundColor = ConsoleColor.Red;

                }

                if (warning && _logWarning)

                {

                    Console.ForegroundColor = ConsoleColor.Yellow;

                }

                if (message && _logMessage)

                {

                    Console.ForegroundColor = ConsoleColor.White;

                }

                Console.WriteLine(DateTime.Now.ToShortDateString() + text);
            }

        }

    }
}

