// -----------------------------------------------------------------------
// CharArrayPoolTests.cs Copyright 2022 Craig Gjeltema
// -----------------------------------------------------------------------

namespace TestStringInterpolation
{
    using NUnit.Framework;
    using StringInterpolations;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [TestFixture]
    public class CharArrayPoolTests
    {
        [TestCase(255)]
        [TestCase(123456)]
        public void TestInterpolator(int valueToInterpolate)
        {
            string expectedValue = "123456789012345678901234567890123456789012345678901234567890123456789" + valueToInterpolate + "0123456789" + GetString(valueToInterpolate)
                + "123456789012345678901234567890123456789012345678901234567890123456789"
                + "123456789012345678901234567890123456789012345678901234567890123456789"
                + "123456789012345678901234567890123456789012345678901234567890123456789"
                + "123456789012345678901234567890123456789012345678901234567890123456789"
                + "123456789012345678901234567890123456789012345678901234567890123456789";
            string interpolatedValue = $"123456789012345678901234567890123456789012345678901234567890123456789{valueToInterpolate}0123456789{GetString(valueToInterpolate)}"
                + "123456789012345678901234567890123456789012345678901234567890123456789"
                + "123456789012345678901234567890123456789012345678901234567890123456789"
                + "123456789012345678901234567890123456789012345678901234567890123456789"
                + "123456789012345678901234567890123456789012345678901234567890123456789"
                + "123456789012345678901234567890123456789012345678901234567890123456789";

            string getCachedArrayCheck = $"123456789012345678901234567890123456789012345678901234567890123456789{valueToInterpolate}";

            Assert.That(expectedValue, Is.EqualTo(interpolatedValue));
        }

        [TestCase(0, 7)]
        [TestCase(1, 7)]
        [TestCase(254, 7)]
        [TestCase(255, 7)]
        [TestCase(256, 8)]
        [TestCase(511, 8)]
        [TestCase(512, 9)]
        [TestCase(1_073_741_791, 29)]
        [TestCase(1_073_741_824, 30)]
        [TestCase(2_000_000_000, 30)]
        public void TestLog2(int input, int expectedValue)
        {
            int actual = CharArrayPool.Log2((uint)input);
            Assert.That(expectedValue, Is.EqualTo(actual));
        }

        [TestCase(LogLevel.Info, 4)]
        [TestCase(LogLevel.Critical, 1)]
        [TestCase(LogLevel.Trace, 6)]
        public void TestLogCall(LogLevel level, int numberOfExpectedMessages)
        {
            TestLogTarget logTarget = InitializeLogger(level);

            Log.Critical($"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            Log.Error($"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            Log.Warning($"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            Log.Info($"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            Log.Debug($"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            Log.Trace($"Number of expected messages is {numberOfExpectedMessages}: {level}.");

            Assert.That(logTarget.LogMessages, Has.Count.EqualTo(numberOfExpectedMessages));

            string expectedMessage = $"Number of expected messages is {numberOfExpectedMessages}: {level}.";

            foreach (var message in logTarget.LogMessages)
                Assert.That(message, Is.EqualTo(expectedMessage));
        }

        [TestCase(LogLevel.Info, 4)]
        [TestCase(LogLevel.Critical, 1)]
        [TestCase(LogLevel.Trace, 6)]
        public void TestLogTargetCall(LogLevel level, int numberOfExpectedMessages)
        {
            TestLogTarget logTarget = InitializeLogger(level);

            logTarget.Log(LogLevel.Critical, $"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            logTarget.Log(LogLevel.Error, $"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            logTarget.Log(LogLevel.Warning, $"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            logTarget.Log(LogLevel.Info, $"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            logTarget.Log(LogLevel.Debug, $"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            logTarget.Log(LogLevel.Trace, $"Number of expected messages is {numberOfExpectedMessages}: {level}.");

            Assert.That(logTarget.LogMessages, Has.Count.EqualTo(numberOfExpectedMessages));

            string expectedMessage = $"Number of expected messages is {numberOfExpectedMessages}: {level}.";

            foreach (var message in logTarget.LogMessages)
                Assert.That(message, Is.EqualTo(expectedMessage));
        }

        [TestCase(LogLevel.Info, 4)]
        [TestCase(LogLevel.Critical, 1)]
        [TestCase(LogLevel.Trace, 6)]
        public void TestLogTargetExtensionCall(LogLevel level, int numberOfExpectedMessages)
        {
            TestLogTarget logTarget = InitializeLogger(level);

            logTarget.Critical($"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            logTarget.Error($"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            logTarget.Warning($"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            logTarget.Info($"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            logTarget.Debug($"Number of expected messages is {numberOfExpectedMessages}: {level}.");
            logTarget.Trace($"Number of expected messages is {numberOfExpectedMessages}: {level}.");

            Assert.That(logTarget.LogMessages, Has.Count.EqualTo(numberOfExpectedMessages));

            string expectedMessage = $"Number of expected messages is {numberOfExpectedMessages}: {level}.";

            foreach (var message in logTarget.LogMessages)
                Assert.That(message, Is.EqualTo(expectedMessage));
        }

        [TestCase(1, 255)]
        [TestCase(100, 255)]
        [TestCase(255, 255)]
        [TestCase(256, 511)]
        [TestCase(511, 511)]
        [TestCase(512, 1023)]
        [TestCase(513, 1023)]
        [TestCase(1000, 1023)]
        [TestCase(1024, 2047)]
        [TestCase(1025, 2047)]
        [TestCase(1_000_000, 1_048_575)]
        [TestCase(1_048_576, 1_048_576)]
        [TestCase(1_048_577, 1_048_577)]
        [TestCase(2_000_000, 2_000_000)]
        public void TestRentWhenArraysWereAdded(int sizeRequested, int sizeArrayReturned)
        {
            var array = CharArrayPool.Rent(sizeRequested);
            CharArrayPool.Return(array);
            array = CharArrayPool.Rent(sizeRequested);
            Assert.That(sizeArrayReturned, Is.EqualTo(array.Length));
        }

        [TestCase(1, 255)]
        [TestCase(100, 255)]
        [TestCase(255, 255)]
        [TestCase(256, 511)]
        [TestCase(511, 511)]
        [TestCase(512, 1023)]
        [TestCase(513, 1023)]
        [TestCase(1000, 1023)]
        [TestCase(1024, 2047)]
        [TestCase(1025, 2047)]
        [TestCase(1_000_000, 1_048_575)]
        [TestCase(1_048_576, 1_048_576)]
        [TestCase(1_048_577, 1_048_577)]
        [TestCase(1_073_741_791, 1_073_741_791)]
        public void TestRentWhenNoArraysAdded(int sizeRequested, int sizeArrayReturned)
        {
            var array = CharArrayPool.Rent(sizeRequested);
            Assert.That(sizeArrayReturned, Is.EqualTo(array.Length));
        }

        private string GetString(int numberOfChars)
            => new('A', numberOfChars);

        private TestLogTarget InitializeLogger(LogLevel level)
        {
            var newTarget = new TestLogTarget()
            {
                LoggingLevel = level
            };
            Log.LogTarget = newTarget;
            return newTarget;
        }
    }

    public sealed class TestLogTarget : ILogTarget
    {
        public LogLevel LoggingLevel { get; set; }

        public ICollection<string> LogMessages { get; } = new List<string>();

        public void Log(LogLevel level, string message)
        {
            if (LoggingLevel.IsLevelLoggable(level))
                LogMessages.Add(message);
        }

        public void Log(LogLevel level, [InterpolatedStringHandlerArgument("", "level")] LoggerInterpolator message)
        {
            if (message.CreatedLogMessage)
                LogMessages.Add(message.ToStringAndClear());
        }
    }
}
