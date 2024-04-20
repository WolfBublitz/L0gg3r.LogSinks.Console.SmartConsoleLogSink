using System.Threading.Tasks;
using L0gg3r;
using L0gg3r.LogSinks.Console.SmartConsoleLogSink;

namespace LogMessageWriterTests.SmartConsoleInjectionTest;

[LogMessageWriter<SmartConsoleLogSink>]
internal class LogMessageWriter
{
    public LogMessageWriter(SmartConsole smartConsole)
    {
        SmartConsole = smartConsole;
    }

    public static SmartConsole? SmartConsole { get; set; }
}

[TestClass]
public class TheSmartConsoleLogSink
{
    [TestMethod]
    public async Task ShallInjectTheSmartConsoleIntoTheLogMessageWriter()
    {
        // Arrange
        SmartConsoleLogSink logSink = new();

        // Act
        await logSink.SubmitAsync(new LogMessage() { Payload = 42 }).ConfigureAwait(false);
        await logSink.FlushAsync().ConfigureAwait(false);

        // Assert
        LogMessageWriter.SmartConsole.Should().NotBeNull();
    }
}
