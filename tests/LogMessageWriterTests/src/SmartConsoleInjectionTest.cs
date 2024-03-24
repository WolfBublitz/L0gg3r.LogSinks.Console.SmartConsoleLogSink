using System.Threading.Tasks;
using L0gg3r;
using L0gg3r.LogSinks.Console.SmartConsoleLogSink;

namespace LogMessageWriterTests.SmartConsoleInjectionTest;

[LogMessageWriter<SmartConsoleLogSink, int>]
internal class LogMessageWriter : ILogMessageWriter
{
    public LogMessageWriter(SmartConsole smartConsole)
    {
        SmartConsole = smartConsole;
    }

    public static SmartConsole? SmartConsole { get; set; }

    public ValueTask<Continuation> WriteAsync(in LogMessage logMessage)
    {
        return ValueTask.FromResult(Continuation.Stop);
    }
}

[TestClass]
public class TheSmartConsoleLogSink
{
    [TestMethod]
    public async Task ShallInjectTheSmartConsoleIntoTheLogMessageWriter()
    {
        // Arrange
        SmartConsoleLogSink logSink = new();
        logSink.ServiceProvider.RegisterLogMessageWriter<LogMessageWriter>();

        // Act
        await logSink.SubmitAsync(new LogMessage() { Payload = 42 }).ConfigureAwait(false);
        await logSink.FlushAsync().ConfigureAwait(false);

        // Assert
        LogMessageWriter.SmartConsole.Should().NotBeNull();
    }
}