using System;
using System.Collections.Generic;
using System.Net;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace BGGallery.Utils
{
    public static class HLog
    {
        private static LogTargets type;

        private static string name = "Log";

        private static string format = "[%d{yyyy-MM-dd HH:mm:ss,fff}][%-5level][%c]%message%newline";
        public static bool DisableDebugLog = true;

        public static void Start(string name1, LogTargets target) //server remote mode will be set auto when use SetRemote
        {
            name = name1;
            type = target;
            List<IAppender> appenders = new List<IAppender>();

            if ((type & LogTargets.ServerConsole) != 0)
            {
                ColoredConsoleAppender appender = new ColoredConsoleAppender();
                appender.Layout = new PatternLayout(format);
                ColoredConsoleAppender.LevelColors mapcolor = new ColoredConsoleAppender.LevelColors();
                mapcolor.Level = Level.Fatal;
                mapcolor.BackColor = ColoredConsoleAppender.Colors.Red;
                appender.AddMapping(mapcolor);
                mapcolor = new ColoredConsoleAppender.LevelColors();
                mapcolor.Level = Level.Error;
                mapcolor.BackColor = ColoredConsoleAppender.Colors.Red;
                appender.AddMapping(mapcolor);
                mapcolor = new ColoredConsoleAppender.LevelColors();
                mapcolor.Level = Level.Warn;
                mapcolor.ForeColor = ColoredConsoleAppender.Colors.Purple;
                appender.AddMapping(mapcolor);
                mapcolor = new ColoredConsoleAppender.LevelColors();
                mapcolor.Level = Level.Info;
                mapcolor.ForeColor = ColoredConsoleAppender.Colors.Green;
                appender.AddMapping(mapcolor);
                appender.ActivateOptions();
                appenders.Add(appender);
            }

            if ((type & LogTargets.File) != 0)
            {
                var appender1 = new RollingFileAppender();
                appender1.Layout = new PatternLayout(format);
                appender1.File = string.Format("Log/{0}.log", name);
                appender1.RollingStyle = RollingFileAppender.RollingMode.Date;
                appender1.DatePattern = "-yyyy-MM-dd";
                appender1.StaticLogFileName = false;
                appender1.AppendToFile = true;
                appender1.PreserveLogFileNameExtension = true;
                appender1.ActivateOptions();
                appenders.Add(appender1);
            }

            BasicConfigurator.Configure(appenders.ToArray());
        }

        public static void Debug(object message, params object[] args)
        {
            if (DisableDebugLog)
                return;
            var outputText = args == null || args.Length == 0 ? message.ToString() : string.Format(message.ToString(), args);
            Debug(outputText);
        }

        private static void Debug(object message)
        {
            if (DisableDebugLog)
                return;
            LogManager.GetLogger(name).Debug(message);
        }
        public static void Info(object message, params object[] args)
        {
            var outputText = args == null || args.Length == 0 ? message.ToString() : string.Format(message.ToString(), args);
            Info(outputText);
        }
        private static void Info(object message)
        {
            LogManager.GetLogger(name).Info(message);
        }

        public static void Error(object message, params object[] args)
        {
            var outputText = args == null || args.Length == 0 ? message.ToString() : string.Format(message.ToString(), args);
            Error(outputText);
        }

        private static void Error(object message)
        {
            LogManager.GetLogger(name).Error(message);
        }

        public static void Warn(object message, params object[] args)
        {
            var outputText = args == null || args.Length == 0 ? message.ToString() : string.Format(message.ToString(), args);
            Warn(outputText);
        }

        private static void Warn(object message)
        {
            LogManager.GetLogger(name).Warn(message);
        }
    }

    [Flags]
    public enum LogTargets
    {
        ServerConsole = 1,
        File = 4,
        Custom = 8,
        All = ServerConsole |  File   }

    public delegate void NLog4NetLogEventHandler(string name, object message);
}
