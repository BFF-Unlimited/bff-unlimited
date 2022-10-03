namespace Bff.Core.Framework.Logging
{
    public interface IRovictLogger
    {
        void Trace(Type sourceType, string message);

        void Trace(Type sourceType, string messageTemplate, params object[] parameters);

        void Trace(Type sourceType, Exception exception, string message);

        void Trace(Type sourceType, Exception exception, string message, params object[] parameters);

        void Debug(Type sourceType, string message);

        void Debug(Type sourceType, string messageTemplate, params object[] parameters);

        void Debug(Type sourceType, Exception exception, string message);

        void Debug(Type sourceType, Exception exception, string message, params object[] parameters);

        void Info(Type sourceType, string message);

        void Info(Type sourceType, string messageTemplate, params object[] parameters);

        void Info(Type sourceType, Exception exception, string message);

        void Info(Type sourceType, Exception exception, string message, params object[] parameters);

        void Warn(Type sourceType, string message);

        void Warn(Type sourceType, string messageTemplate, params object[] parameters);

        void Warn(Type sourceType, Exception exception, string message);

        void Warn(Type sourceType, Exception exception, string message, params object[] parameters);

        void Error(Type sourceType, string message);

        void Error(Type sourceType, string messageTemplate, params object[] parameters);

        void Error(Type sourceType, Exception exception, string message);

        void Error(Type sourceType, Exception exception, string message, params object[] parameters);

        void Fatal(Type sourceType, string message);

        void Fatal(Type sourceType, string messageTemplate, params object[] parameters);

        void Fatal(Type sourceType, Exception exception, string message);

        void Fatal(Type sourceType, Exception exception, string message, params object[] parameters);

        void Trace(string message);

        void Trace(string messageTemplate, params object[] parameters);

        void Trace(Exception exception, string message);

        void Trace(Exception exception, string message, params object[] parameters);

        void Debug(string message);

        void Debug(string messageTemplate, params object[] parameters);

        void Debug(Exception exception, string message);

        void Debug(Exception exception, string message, params object[] parameters);

        void Info(string message);

        void Info(string messageTemplate, params object[] parameters);

        void Info(Exception exception, string message);

        void Info(Exception exception, string message, params object[] parameters);

        void Warn(string message);

        void Warn(string messageTemplate, params object[] parameters);

        void Warn(Exception exception, string message);

        void Warn(Exception exception, string message, params object[] parameters);

        void Error(string message);

        void Error(string messageTemplate, params object[] parameters);

        void Error(Exception exception, string message);

        void Error(Exception exception, string message, params object[] parameters);

        void Fatal(string message);

        void Fatal(string messageTemplate, params object[] parameters);

        void Fatal(Exception exception, string message);

        void Fatal(Exception exception, string message, params object[] parameters);

        void Trace<TSource>(string message);

        void Trace<TSource>(string messageTemplate, params object[] parameters);

        void Trace<TSource>(Exception exception, string message);

        void Trace<TSource>(Exception exception, string message, params object[] parameters);

        void Debug<TSource>(string message);

        void Debug<TSource>(string messageTemplate, params object[] parameters);

        void Debug<TSource>(Exception exception, string message);

        void Debug<TSource>(Exception exception, string message, params object[] parameters);

        void Info<TSource>(string message);

        void Info<TSource>(string messageTemplate, params object[] parameters);

        void Info<TSource>(Exception exception, string message);

        void Info<TSource>(Exception exception, string message, params object[] parameters);

        void Warn<TSource>(string message);

        void Warn<TSource>(string messageTemplate, params object[] parameters);

        void Warn<TSource>(Exception exception, string message);

        void Warn<TSource>(Exception exception, string message, params object[] parameters);

        void Error<TSource>(string message);

        void Error<TSource>(string messageTemplate, params object[] parameters);

        void Error<TSource>(Exception exception, string message);

        void Error<TSource>(Exception exception, string message, params object[] parameters);

        void Fatal<TSource>(string message);

        void Fatal<TSource>(string messageTemplate, params object[] parameters);

        void Fatal<TSource>(Exception exception, string message);

        void Fatal<TSource>(Exception exception, string message, params object[] parameters);
    }
}
