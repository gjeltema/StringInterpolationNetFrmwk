// -----------------------------------------------------------------------
 // CharArrayPoolTests.cs Copyright 2022 Craig Gjeltema
 // -----------------------------------------------------------------------

namespace StringInterpolations
{
    using System;
    using System.Runtime.CompilerServices;

    [InterpolatedStringHandler]
    public ref struct LoggerInfoInterpolator
    {
        public bool CreatedLogMessage { get; }
        private DefaultInterpolatedStringHandler interpolator;
        public LoggerInfoInterpolator(int literalLength, int formattedCount, out bool createLogMessage)
            : this(literalLength, formattedCount, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerInfoInterpolator(int literalLength, int formattedCount, IFormatProvider provider, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerInfoInterpolator(int literalLength, int formattedCount, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerInfoInterpolator(int literalLength, int formattedCount, IFormatProvider provider, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerInfoInterpolator(int literalLength, int formattedCount, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Info))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public LoggerInfoInterpolator(int literalLength, int formattedCount, IFormatProvider provider, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Info))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount, provider);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public override string ToString() => interpolator.ToString();

        public string ToStringAndClear() => interpolator.ToStringAndClear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLiteral(string value) => interpolator.AppendLiteral(value);

        public void AppendFormatted<T>(T value) => interpolator.AppendFormatted(value);

        public void AppendFormatted<T>(T value, string format) => interpolator.AppendFormatted(value, format);

        public void AppendFormatted<T>(T value, int alignment) => interpolator.AppendFormatted(value, alignment);

        public void AppendFormatted<T>(T value, int alignment, string format)  => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(string value) => interpolator.AppendFormatted(value);

        public void AppendFormatted(string value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(object value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);
    }

    [InterpolatedStringHandler]
    public ref struct LoggerDebugInterpolator
    {
        public bool CreatedLogMessage { get; }
        private DefaultInterpolatedStringHandler interpolator;
        public LoggerDebugInterpolator(int literalLength, int formattedCount, out bool createLogMessage)
            : this(literalLength, formattedCount, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerDebugInterpolator(int literalLength, int formattedCount, IFormatProvider provider, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerDebugInterpolator(int literalLength, int formattedCount, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerDebugInterpolator(int literalLength, int formattedCount, IFormatProvider provider, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerDebugInterpolator(int literalLength, int formattedCount, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Debug))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public LoggerDebugInterpolator(int literalLength, int formattedCount, IFormatProvider provider, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Debug))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount, provider);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public override string ToString() => interpolator.ToString();

        public string ToStringAndClear() => interpolator.ToStringAndClear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLiteral(string value) => interpolator.AppendLiteral(value);

        public void AppendFormatted<T>(T value) => interpolator.AppendFormatted(value);

        public void AppendFormatted<T>(T value, string format) => interpolator.AppendFormatted(value, format);

        public void AppendFormatted<T>(T value, int alignment) => interpolator.AppendFormatted(value, alignment);

        public void AppendFormatted<T>(T value, int alignment, string format) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(string value) => interpolator.AppendFormatted(value);

        public void AppendFormatted(string value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(object value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);
    }

    [InterpolatedStringHandler]
    public ref struct LoggerCriticalInterpolator
    {
        public bool CreatedLogMessage { get; }
        private DefaultInterpolatedStringHandler interpolator;
        public LoggerCriticalInterpolator(int literalLength, int formattedCount, out bool createLogMessage)
            : this(literalLength, formattedCount, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerCriticalInterpolator(int literalLength, int formattedCount, IFormatProvider provider, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerCriticalInterpolator(int literalLength, int formattedCount, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerCriticalInterpolator(int literalLength, int formattedCount, IFormatProvider provider, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerCriticalInterpolator(int literalLength, int formattedCount, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Critical))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public LoggerCriticalInterpolator(int literalLength, int formattedCount, IFormatProvider provider, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Critical))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount, provider);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public override string ToString() => interpolator.ToString();

        public string ToStringAndClear() => interpolator.ToStringAndClear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLiteral(string value) => interpolator.AppendLiteral(value);

        public void AppendFormatted<T>(T value) => interpolator.AppendFormatted(value);

        public void AppendFormatted<T>(T value, string format) => interpolator.AppendFormatted(value, format);

        public void AppendFormatted<T>(T value, int alignment) => interpolator.AppendFormatted(value, alignment);

        public void AppendFormatted<T>(T value, int alignment, string format) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(string value) => interpolator.AppendFormatted(value);

        public void AppendFormatted(string value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(object value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);
    }

    [InterpolatedStringHandler]
    public ref struct LoggerErrorInterpolator
    {
        public bool CreatedLogMessage { get; }
        private DefaultInterpolatedStringHandler interpolator;
        public LoggerErrorInterpolator(int literalLength, int formattedCount, out bool createLogMessage)
            : this(literalLength, formattedCount, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerErrorInterpolator(int literalLength, int formattedCount, IFormatProvider provider, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerErrorInterpolator(int literalLength, int formattedCount, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerErrorInterpolator(int literalLength, int formattedCount, IFormatProvider provider, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerErrorInterpolator(int literalLength, int formattedCount, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Error))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public LoggerErrorInterpolator(int literalLength, int formattedCount, IFormatProvider provider, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Error))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount, provider);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public override string ToString() => interpolator.ToString();

        public string ToStringAndClear() => interpolator.ToStringAndClear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLiteral(string value) => interpolator.AppendLiteral(value);

        public void AppendFormatted<T>(T value) => interpolator.AppendFormatted(value);

        public void AppendFormatted<T>(T value, string format) => interpolator.AppendFormatted(value, format);

        public void AppendFormatted<T>(T value, int alignment) => interpolator.AppendFormatted(value, alignment);

        public void AppendFormatted<T>(T value, int alignment, string format) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(string value) => interpolator.AppendFormatted(value);

        public void AppendFormatted(string value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(object value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);
    }

    [InterpolatedStringHandler]
    public ref struct LoggerWarningInterpolator
    {
        public bool CreatedLogMessage { get; }
        private DefaultInterpolatedStringHandler interpolator;
        public LoggerWarningInterpolator(int literalLength, int formattedCount, out bool createLogMessage)
            : this(literalLength, formattedCount, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerWarningInterpolator(int literalLength, int formattedCount, IFormatProvider provider, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerWarningInterpolator(int literalLength, int formattedCount, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerWarningInterpolator(int literalLength, int formattedCount, IFormatProvider provider, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerWarningInterpolator(int literalLength, int formattedCount, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Warning))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public LoggerWarningInterpolator(int literalLength, int formattedCount, IFormatProvider provider, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Warning))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount, provider);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public override string ToString() => interpolator.ToString();

        public string ToStringAndClear() => interpolator.ToStringAndClear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLiteral(string value) => interpolator.AppendLiteral(value);

        public void AppendFormatted<T>(T value) => interpolator.AppendFormatted(value);

        public void AppendFormatted<T>(T value, string format) => interpolator.AppendFormatted(value, format);

        public void AppendFormatted<T>(T value, int alignment) => interpolator.AppendFormatted(value, alignment);

        public void AppendFormatted<T>(T value, int alignment, string format) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(string value) => interpolator.AppendFormatted(value);

        public void AppendFormatted(string value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(object value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);
    }

    [InterpolatedStringHandler]
    public ref struct LoggerTraceInterpolator
    {
        private DefaultInterpolatedStringHandler interpolator;
        public bool CreatedLogMessage { get; }

        public LoggerTraceInterpolator(int literalLength, int formattedCount, out bool createLogMessage)
            : this(literalLength, formattedCount, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerTraceInterpolator(int literalLength, int formattedCount, IFormatProvider provider, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, Log.LogTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerTraceInterpolator(int literalLength, int formattedCount, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerTraceInterpolator(int literalLength, int formattedCount, IFormatProvider provider, ILogTarget logTarget, out bool createLogMessage)
            : this(literalLength, formattedCount, provider, logTarget.LoggingLevel, out createLogMessage)
        {
        }

        public LoggerTraceInterpolator(int literalLength, int formattedCount, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Trace))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public LoggerTraceInterpolator(int literalLength, int formattedCount, IFormatProvider provider, LogLevel logLevel, out bool createLogMessage)
        {
            if (logLevel.IsLevelLoggable(LogLevel.Trace))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount, provider);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public override string ToString() => interpolator.ToString();

        public string ToStringAndClear() => interpolator.ToStringAndClear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLiteral(string value) => interpolator.AppendLiteral(value);

        public void AppendFormatted<T>(T value) => interpolator.AppendFormatted(value);

        public void AppendFormatted<T>(T value, string format) => interpolator.AppendFormatted(value, format);

        public void AppendFormatted<T>(T value, int alignment) => interpolator.AppendFormatted(value, alignment);

        public void AppendFormatted<T>(T value, int alignment, string format) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(string value) => interpolator.AppendFormatted(value);

        public void AppendFormatted(string value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(object value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);
    }

    [InterpolatedStringHandler]
    public ref struct LoggerInterpolator
    {
        private DefaultInterpolatedStringHandler interpolator;
        public bool CreatedLogMessage { get; }

        public LoggerInterpolator(int literalLength, int formattedCount, ILogTarget logTarget, LogLevel logLevel, out bool createLogMessage)
        {
            if (logTarget.LoggingLevel.IsLevelLoggable(logLevel))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public LoggerInterpolator(int literalLength, int formattedCount, IFormatProvider provider, ILogTarget logTarget, LogLevel logLevel, out bool createLogMessage)
        {
            if (logTarget.LoggingLevel.IsLevelLoggable(logLevel))
            {
                CreatedLogMessage = createLogMessage = true;
                interpolator = new DefaultInterpolatedStringHandler(literalLength, formattedCount, provider);
                return;
            }

            CreatedLogMessage = createLogMessage = false;
            interpolator = default;
        }

        public override string ToString() => interpolator.ToString();

        public string ToStringAndClear() => interpolator.ToStringAndClear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AppendLiteral(string value) => interpolator.AppendLiteral(value);

        public void AppendFormatted<T>(T value) => interpolator.AppendFormatted(value);

        public void AppendFormatted<T>(T value, string format) => interpolator.AppendFormatted(value, format);

        public void AppendFormatted<T>(T value, int alignment) => interpolator.AppendFormatted(value, alignment);

        public void AppendFormatted<T>(T value, int alignment, string format) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(string value) => interpolator.AppendFormatted(value);

        public void AppendFormatted(string value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);

        public void AppendFormatted(object value, int alignment = 0, string format = null) => interpolator.AppendFormatted(value, alignment, format);
    }
}
