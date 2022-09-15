namespace Bff.Core.Framework.Logging
{
    public abstract class RovictLoggerBase : IRovictLogger
    {
        public void Trace(string message) => Log(RovictLogLevel.Trace, message);

        public void Trace(string messageTemplate, params object[] parameters) => Log(RovictLogLevel.Trace, messageTemplate, parameters);

        public void Trace(Exception exception, string message) => Log(RovictLogLevel.Trace, exception, message);

        public void Trace(Exception exception, string message, params object[] parameters) => Log(RovictLogLevel.Trace, exception, message, parameters);

        public void Debug(string message) => Log(RovictLogLevel.Debug, message);

        public void Debug(string messageTemplate, params object[] parameters) => Log(RovictLogLevel.Debug, messageTemplate, parameters);

        public void Debug(Exception exception, string message) => Log(RovictLogLevel.Debug, exception, message);

        public void Debug(Exception exception, string message, params object[] parameters) => Log(RovictLogLevel.Debug, exception, message, parameters);

        public void Info(string message) => Log(RovictLogLevel.Info, message);

        public void Info(string messageTemplate, params object[] parameters) => Log(RovictLogLevel.Info, messageTemplate, parameters);

        public void Info(Exception exception, string message) => Log(RovictLogLevel.Info, exception, message);

        public void Info(Exception exception, string message, params object[] parameters) => Log(RovictLogLevel.Info, exception, message, parameters);

        public void Warn(string message) => Log(RovictLogLevel.Warn, message);

        public void Warn(string messageTemplate, params object[] parameters) => Log(RovictLogLevel.Warn, messageTemplate, parameters);

        public void Warn(Exception exception, string message) => Log(RovictLogLevel.Warn, exception, message);

        public void Warn(Exception exception, string message, params object[] parameters) => Log(RovictLogLevel.Warn, exception, message, parameters);

        public void Error(string message) => Log(RovictLogLevel.Error, message);

        public void Error(string messageTemplate, params object[] parameters) => Log(RovictLogLevel.Error, messageTemplate, parameters);

        public void Error(Exception exception, string message) => Log(RovictLogLevel.Error, exception, message);

        public void Error(Exception exception, string message, params object[] parameters) => Log(RovictLogLevel.Error, exception, message, parameters);

        public void Fatal(string message) => Log(RovictLogLevel.Fatal, message);

        public void Fatal(string messageTemplate, params object[] parameters) => Log(RovictLogLevel.Fatal, messageTemplate, parameters);

        public void Fatal(Exception exception, string message) => Log(RovictLogLevel.Fatal, exception, message);

        public void Fatal(Exception exception, string message, params object[] parameters) => Log(RovictLogLevel.Fatal, exception, message, parameters);

        public void Trace(Type sourceType, string message) => Log(sourceType, RovictLogLevel.Trace, message);

        public void Trace(Type sourceType, string messageTemplate, params object[] parameters) => Log(sourceType, RovictLogLevel.Trace, messageTemplate, parameters);

        public void Trace(Type sourceType, Exception exception, string message) => Log(sourceType, RovictLogLevel.Trace, exception, message);

        public void Trace(Type sourceType, Exception exception, string message, params object[] parameters) => Log(sourceType, RovictLogLevel.Trace, exception, message, parameters);

        public void Debug(Type sourceType, string message) => Log(sourceType, RovictLogLevel.Debug, message);

        public void Debug(Type sourceType, string messageTemplate, params object[] parameters) => Log(sourceType, RovictLogLevel.Debug, messageTemplate, parameters);

        public void Debug(Type sourceType, Exception exception, string message) => Log(sourceType, RovictLogLevel.Debug, exception, message);

        public void Debug(Type sourceType, Exception exception, string message, params object[] parameters) => Log(sourceType, RovictLogLevel.Debug, exception, message, parameters);

        public void Info(Type sourceType, string message) => Log(sourceType, RovictLogLevel.Info, message);

        public void Info(Type sourceType, string messageTemplate, params object[] parameters) => Log(sourceType, RovictLogLevel.Info, messageTemplate, parameters);

        public void Info(Type sourceType, Exception exception, string message) => Log(sourceType, RovictLogLevel.Info, exception, message);

        public void Info(Type sourceType, Exception exception, string message, params object[] parameters) => Log(sourceType, RovictLogLevel.Info, exception, message, parameters);

        public void Warn(Type sourceType, string message) => Log(sourceType, RovictLogLevel.Warn, message);

        public void Warn(Type sourceType, string messageTemplate, params object[] parameters) => Log(sourceType, RovictLogLevel.Warn, messageTemplate, parameters);

        public void Warn(Type sourceType, Exception exception, string message) => Log(sourceType, RovictLogLevel.Warn, exception, message);

        public void Warn(Type sourceType, Exception exception, string message, params object[] parameters) => Log(sourceType, RovictLogLevel.Warn, exception, message, parameters);

        public void Error(Type sourceType, string message) => Log(sourceType, RovictLogLevel.Error, message);

        public void Error(Type sourceType, string messageTemplate, params object[] parameters) => Log(sourceType, RovictLogLevel.Error, messageTemplate, parameters);

        public void Error(Type sourceType, Exception exception, string message) => Log(sourceType, RovictLogLevel.Error, exception, message);

        public void Error(Type sourceType, Exception exception, string message, params object[] parameters) => Log(sourceType, RovictLogLevel.Error, exception, message, parameters);

        public void Fatal(Type sourceType, string message) => Log(sourceType, RovictLogLevel.Fatal, message);

        public void Fatal(Type sourceType, string messageTemplate, params object[] parameters) => Log(sourceType, RovictLogLevel.Fatal, messageTemplate, parameters);

        public void Fatal(Type sourceType, Exception exception, string message) => Log(sourceType, RovictLogLevel.Fatal, exception, message);

        public void Fatal(Type sourceType, Exception exception, string message, params object[] parameters) => Log(sourceType, RovictLogLevel.Fatal, exception, message, parameters);

        public void Trace<TSource>(string message) => Log<TSource>(RovictLogLevel.Trace, message);

        public void Trace<TSource>(string messageTemplate, params object[] parameters) => Log<TSource>(RovictLogLevel.Trace, messageTemplate, parameters);

        public void Trace<TSource>(Exception exception, string message) => Log<TSource>(RovictLogLevel.Trace, exception, message);

        public void Trace<TSource>(Exception exception, string message, params object[] parameters) => Log<TSource>(RovictLogLevel.Trace, exception, message, parameters);

        public void Debug<TSource>(string message) => Log<TSource>(RovictLogLevel.Debug, message);

        public void Debug<TSource>(string messageTemplate, params object[] parameters) => Log<TSource>(RovictLogLevel.Debug, messageTemplate, parameters);

        public void Debug<TSource>(Exception exception, string message) => Log<TSource>(RovictLogLevel.Debug, exception, message);

        public void Debug<TSource>(Exception exception, string message, params object[] parameters) => Log<TSource>(RovictLogLevel.Debug, exception, message, parameters);

        public void Info<TSource>(string message) => Log<TSource>(RovictLogLevel.Info, message);

        public void Info<TSource>(string messageTemplate, params object[] parameters) => Log<TSource>(RovictLogLevel.Info, messageTemplate, parameters);

        public void Info<TSource>(Exception exception, string message) => Log<TSource>(RovictLogLevel.Info, exception, message);

        public void Info<TSource>(Exception exception, string message, params object[] parameters) => Log<TSource>(RovictLogLevel.Info, exception, message, parameters);

        public void Warn<TSource>(string message) => Log<TSource>(RovictLogLevel.Warn, message);

        public void Warn<TSource>(string messageTemplate, params object[] parameters) => Log<TSource>(RovictLogLevel.Warn, messageTemplate, parameters);

        public void Warn<TSource>(Exception exception, string message) => Log<TSource>(RovictLogLevel.Warn, exception, message);

        public void Warn<TSource>(Exception exception, string message, params object[] parameters) => Log<TSource>(RovictLogLevel.Warn, exception, message, parameters);

        public void Error<TSource>(string message) => Log<TSource>(RovictLogLevel.Error, message);

        public void Error<TSource>(string messageTemplate, params object[] parameters) => Log<TSource>(RovictLogLevel.Error, messageTemplate, parameters);

        public void Error<TSource>(Exception exception, string message) => Log<TSource>(RovictLogLevel.Error, exception, message);

        public void Error<TSource>(Exception exception, string message, params object[] parameters) => Log<TSource>(RovictLogLevel.Error, exception, message, parameters);

        public void Fatal<TSource>(string message) => Log<TSource>(RovictLogLevel.Fatal, message);

        public void Fatal<TSource>(string messageTemplate, params object[] parameters) => Log<TSource>(RovictLogLevel.Fatal, messageTemplate, parameters);

        public void Fatal<TSource>(Exception exception, string message) => Log<TSource>(RovictLogLevel.Fatal, exception, message);

        public void Fatal<TSource>(Exception exception, string message, params object[] parameters) => Log<TSource>(RovictLogLevel.Fatal, exception, message, parameters);

        private void Log<TSource>(RovictLogLevel level, Exception exception, string message, params object[] parameters) => Log(typeof(TSource), level, exception, message, parameters);

        private void Log<TSource>(RovictLogLevel level, string message, params object[] parameters) => Log(typeof(TSource), level, message, parameters);

        protected abstract void Log(Type sourceType, RovictLogLevel level, string message, params object[] parameters);
        protected abstract void Log(Type sourceType, RovictLogLevel level, Exception exception, string message, params object[] parameters);

        protected abstract void Log(RovictLogLevel level, string message, params object[] parameters);
        protected abstract void Log(RovictLogLevel level, Exception exception, string message, params object[] parameters);
    }
}
