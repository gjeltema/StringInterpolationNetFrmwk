// -----------------------------------------------------------------------
// CharArrayPoolTests.cs Copyright 2022 Craig Gjeltema
// -----------------------------------------------------------------------

namespace StringInterpolations
{
    using System.Runtime.CompilerServices;

    // These are just some example logger abstraction implementations to demonstrate how to use the custom string interpolators.

    public interface ILogTarget
    {
        /// <summary>Gets or sets the level of logs to be added to the log output.</summary>
        LogLevel LoggingLevel { get; set; }

        /// <summary>Writes a message to the log.</summary>
        /// <param name="level">Level at which to log.</param>
        /// <param name="message">The message to be logged.</param>
        void Log(LogLevel level, string message);
    }

    public static class Log
    {
        public static ILogTarget LogTarget { get; set; }

        public static void Info(string message)
        {
            LogTarget.Log(LogLevel.Info, message);
        }

        public static void Warning(string message)
        {
            LogTarget.Log(LogLevel.Warning, message);
        }

        public static void Critical(string message)
        {
            LogTarget.Log(LogLevel.Critical, message);
        }

        public static void Error(string message)
        {
            LogTarget.Log(LogLevel.Error, message);
        }

        public static void Debug(string message)
        {
            LogTarget.Log(LogLevel.Debug, message);
        }

        public static void Trace(string message)
        {
            LogTarget.Log(LogLevel.Trace, message);
        }

        public static void Info(LoggerInfoInterpolator message)
        {
            if (message.CreatedLogMessage)
                LogTarget.Log(LogLevel.Info, message.ToStringAndClear());
        }

        public static void Warning(LoggerWarningInterpolator message)
        {
            if (message.CreatedLogMessage)
                LogTarget.Log(LogLevel.Warning, message.ToStringAndClear());
        }

        public static void Critical(LoggerCriticalInterpolator message)
        {
            if (message.CreatedLogMessage)
                LogTarget.Log(LogLevel.Critical, message.ToStringAndClear());
        }

        public static void Error(LoggerErrorInterpolator message)
        {
            if (message.CreatedLogMessage)
                LogTarget.Log(LogLevel.Error, message.ToStringAndClear());
        }

        public static void Debug(LoggerDebugInterpolator message)
        {
            if (message.CreatedLogMessage)
                LogTarget.Log(LogLevel.Debug, message.ToStringAndClear());
        }

        public static void Trace(LoggerTraceInterpolator message)
        {
            if (message.CreatedLogMessage)
                LogTarget.Log(LogLevel.Trace, message.ToStringAndClear());
        }

        public static void Critical(this ILogTarget logTarget, string message)
            => logTarget.Log(LogLevel.Critical, message);

        public static void Critical(this ILogTarget logTarget, [InterpolatedStringHandlerArgument("logTarget")] LoggerCriticalInterpolator message)
        {
            if (message.CreatedLogMessage)
                logTarget.Log(LogLevel.Critical, message.ToStringAndClear());
        }

        public static void Info(this ILogTarget logTarget, string message)
            => logTarget.Log(LogLevel.Info, message);

        public static void Info(this ILogTarget logTarget, [InterpolatedStringHandlerArgument("logTarget")] LoggerInfoInterpolator message)
        {
            if (message.CreatedLogMessage)
                logTarget.Log(LogLevel.Info, message.ToStringAndClear());
        }

        public static void Debug(this ILogTarget logTarget, string message)
            => logTarget.Log(LogLevel.Debug, message);

        public static void Debug(this ILogTarget logTarget, [InterpolatedStringHandlerArgument("logTarget")] LoggerDebugInterpolator message)
        {
            if (message.CreatedLogMessage)
                logTarget.Log(LogLevel.Debug, message.ToStringAndClear());
        }

        public static void Warning(this ILogTarget logTarget, string message)
            => logTarget.Log(LogLevel.Warning, message);

        public static void Warning(this ILogTarget logTarget, [InterpolatedStringHandlerArgument("logTarget")] LoggerWarningInterpolator message)
        {
            if (message.CreatedLogMessage)
                logTarget.Log(LogLevel.Warning, message.ToStringAndClear());
        }

        public static void Error(this ILogTarget logTarget, string message)
            => logTarget.Log(LogLevel.Error, message);

        public static void Error(this ILogTarget logTarget, [InterpolatedStringHandlerArgument("logTarget")] LoggerErrorInterpolator message)
        {
            if (message.CreatedLogMessage)
                logTarget.Log(LogLevel.Error, message.ToStringAndClear());
        }

        public static void Trace(this ILogTarget logTarget, string message)
            => logTarget.Log(LogLevel.Trace, message);

        public static void Trace(this ILogTarget logTarget, [InterpolatedStringHandlerArgument("logTarget")] LoggerTraceInterpolator message)
        {
            if (message.CreatedLogMessage)
                logTarget.Log(LogLevel.Trace, message.ToStringAndClear());
        }


        public static bool IsLevelLoggable(this LogLevel setLevel, LogLevel messageLevel)
            => setLevel >= messageLevel;
    }

    public enum LogLevel
    {
        /// <summary>
        ///     Critical errors and errors that are fatal for the application.
        /// </summary>
        Critical = 1,

        /// <summary>
        ///     Run-time errors and unexpected conditions.
        /// </summary>
        Error = 2,

        /// <summary>
        ///     Unusual conditions and not-quite-errors.
        /// </summary>
        Warning = 3,

        /// <summary>
        ///     Interesting run-time events, such as start/stop of a process.
        /// </summary>
        Info = 4,

        /// <summary>
        ///     Debugging information - helpful for issue diagnosis.
        /// </summary>
        Debug = 5,

        /// <summary>
        ///     Event tracing information - highest level of detail.
        /// </summary>
        Trace = 6
    }
}
