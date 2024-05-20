using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using L0gg3r.Base;
using L0gg3r.LogSinks.Base;
using L0gg3r.LogSinks.Console.SmartConsoleLogSink;

namespace LogMessageWriterTests.SmartConsoleInjectionTest;

[LogMessageWriter<SmartConsoleLogSink>]
internal class LogMessageWriter : ILogMessageWriter<object>
{
    [Inject]
    public static SmartConsole? SmartConsole { get; set; }

    public ValueTask WriteAsync(in DateTimeOffset timestamp, LogLevel logLevel, IReadOnlyCollection<string> senders, object payload)
    {
        return ValueTask.CompletedTask;
    }
}

[TestClass]
public class TheSmartConsoleLogSink
{
    [TestMethod]
    public void ShallInjectTheSmartConsoleIntoTheLogMessageWriter()
    {
        // Arrange
        LogMessageWriter logMessageWriter = new();
        SmartConsoleLogSink logSink = new();

        // Act
        logSink.RegisterLogMessageWriter(logMessageWriter);

        // Assert
        LogMessageWriter.SmartConsole.Should().NotBeNull();
    }
}
