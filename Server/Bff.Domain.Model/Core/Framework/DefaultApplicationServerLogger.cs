﻿using Microsoft.Extensions.Logging;

namespace Bff.Domain.Model.Core.Framework
{
    public sealed class DefaultApplicationServerLogger : RovictLoggerBase
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger logger;

        public DefaultApplicationServerLogger(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory.CreateLogger("ApplicationServer");
        }

        protected override void Log(Type sourceType, RovictLogLevel level, string message, params object[] parameters)
        {
            // the factory is caching the loggers so we can just create the logger and be ignorant
            var typeLogger = this.loggerFactory.CreateLogger(sourceType);
            typeLogger.Log(MapLevel(level), message, parameters);
        }

        protected override void Log(Type sourceType, RovictLogLevel level, Exception exception, string message, params object[] parameters)
        {
            // the factory is caching the loggers so we can just create the logger and be ignorant
            var typeLogger = this.loggerFactory.CreateLogger(sourceType);
            typeLogger.Log(MapLevel(level), exception, message, parameters);
        }

        protected override void Log(RovictLogLevel level, string message, params object[] parameters) =>
            this.logger.Log(MapLevel(level), message, parameters);

        protected override void Log(RovictLogLevel level, Exception exception, string message, params object[] parameters) =>
            this.logger.Log(MapLevel(level), exception, message, parameters);

        private static LogLevel MapLevel(RovictLogLevel level)
        {
            switch (level)
            {
                case RovictLogLevel.Trace:
                    return LogLevel.Trace;
                case RovictLogLevel.Debug:
                    return LogLevel.Debug;
                case RovictLogLevel.Info:
                    return LogLevel.Information;
                case RovictLogLevel.Warn:
                    return LogLevel.Warning;
                case RovictLogLevel.Error:
                    return LogLevel.Error;
                case RovictLogLevel.Fatal:
                    return LogLevel.Critical;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level));
            }
        }
    }
}