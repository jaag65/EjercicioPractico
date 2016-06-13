using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TodoApp.Infrastructure;
using TodoApp.Interfaces;
using TodoApp.Models;
using TodoApp.Repositories;

namespace TodoApp.Tests.Infrastructure
{
    [TestClass]
    public class JobLoggerTest
    {

        [TestMethod]
        public void LogMessageToDatabaseTest()
        {
            ILog logs = new LogRepository(null);
            var log = new Log
            {
                Message = "Mensaje de prueba.",
                Type = LogType.Error
            };

            var result = logs.Add(log);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LogMessageToFileTest()
        {
            var jobLogger = new JobLogger(true, false, false, true, true, true);

            jobLogger.LogMessage("Test Message.", true, false, false);

            var result = File.Exists(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToString("ddMMyyyy") + ".txt");

            File.Delete(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToString("ddMMyyyy") + ".txt");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void LogMessageToConsoleTest()
        {
            var jobLogger = new JobLogger(false, true, false, true, true, true);

            jobLogger.LogMessage("Test Message.", true, false, false);

            Assert.IsTrue(true);
        }
    }
}
