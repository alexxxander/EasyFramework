﻿using System;
using System.Collections.Generic;
using EasyArchitecture.Common.Diagnostic;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace EasyArchitecture.Plugins.Log4net
{
    public class Log4NetPlugin : ILogPlugin
    {

        private static readonly Dictionary<string, ILog> Loggers = new Dictionary<string, ILog>();
        private static readonly object LogLock = new object(); //TODO: put lock tratment in 

        private static ILog GetLogger(string source)
        {
            lock (LogLock)
            {
                if (Loggers.ContainsKey(source))
                {
                    return Loggers[source];
                }
                ILog logger = LogManager.GetLogger(source);
                Loggers.Add(source, logger);
                return logger;
            }
        }

        private const string LogPattern = "%d [%t] %-5p %c - %m%n";

        private static Level GetLogLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Fatal:
                    return Level.Fatal;
                case LogLevel.Warn:
                    return Level.Warn;
                case LogLevel.Info:
                    return Level.Info;
                case LogLevel.Debug:
                    return Level.Debug;
                default:
                    return Level.Error;
            }
        }

        public void Configure(string moduleName, LogLevel logLevel)
        {
            BasicConfigurator.Configure();

            var configLogLevel = GetLogLevel(logLevel);

            var defaultPattern = new PatternLayout { ConversionPattern = LogPattern };
            defaultPattern.ActivateOptions();

            var rollingFileAppender = new RollingFileAppender
            {
                Name = "RollingFileAppender",
                File = "Log/" + moduleName + ".log",
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Size,
                MaxSizeRollBackups = 15,
                MaximumFileSize = "100MB",
                StaticLogFileName = true,
                Layout = defaultPattern
            };
            rollingFileAppender.ActivateOptions();

            var root = ((Hierarchy)log4net.LogManager.GetRepository()).Root;
            root.AddAppender(rollingFileAppender);
            root.Level = configLogLevel;
            root.Repository.Configured = true;

        }

        public void Log(LogLevel logLevel, string moduleName, object message, Exception exception)
        {
            var logger = GetLogger(moduleName);

            //HACK: preciso diferenciar com ou sem exception?
            switch (logLevel)
            {
                case LogLevel.Fatal:
                    logger.Fatal(message,exception);
                    break;
                case LogLevel.Error:
                    logger.Error(message, exception);
                    break;
                case LogLevel.Warn:
                    logger.Warn(message, exception);
                    break;
                case LogLevel.Info:
                    logger.Info(message, exception);
                    break;
                case LogLevel.Debug:
                    logger.Debug(message, exception);
                    break;
            }
        }

        //public void Configure(string logFile, string businessModuleName, LogLevel logLevel)
        //{
        //    //Log.To(typeof(LogManager)).Message("Configure log to [{0}] at [{1}] level", businessModuleName, logLevel).Debug();

        //    BasicConfigurator.Configure();

        //    var configLogLevel = GetLogLevel(logLevel);

        //    var defaultPattern = new PatternLayout { ConversionPattern = LogPattern };
        //    defaultPattern.ActivateOptions();


        //    var rollingFileAppender = new RollingFileAppender
        //    {
        //        Name = "RollingFileAppender",
        //        File = logFile,
        //        AppendToFile = true,
        //        RollingStyle = RollingFileAppender.RollingMode.Size,
        //        MaxSizeRollBackups = 15,
        //        MaximumFileSize = "100MB",
        //        StaticLogFileName = true,
        //        Layout = defaultPattern
        //    };
        //    rollingFileAppender.ActivateOptions();

        //    var logger = (Logger)log4net.LogManager.GetLogger(businessModuleName).Logger;
        //    logger.AddAppender(rollingFileAppender);
        //    logger.Level = configLogLevel;
        //    logger.Repository.Configured = true;
        //}


    }
}
