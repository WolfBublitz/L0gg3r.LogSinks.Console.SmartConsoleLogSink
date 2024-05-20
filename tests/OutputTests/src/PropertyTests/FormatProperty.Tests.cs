using System.Threading.Tasks;
using L0gg3r.Base;

namespace SmartConsoleLogSinkTests.PropertyTests.FormatPropertyTests;

[TestClass]
public class TheFormatProperty : VerifyBase
{
    [TestMethod]
    public async Task ShouldFormatMessage()
    {
        // Arrange
        SmartConsoleLogSink logSink = new()
        {
            Format = "{Timestamp:yyyy-MM-dd HH} ({LogLevel}) ({Senders:list:{}| > }) -> {Payload}"
        };

        string consoleOutput;

        // Act
        using (TestConsole testConsole = new())
        {
            await logSink.SubmitAsync(new LogMessage() { Payload = "Test" }).ConfigureAwait(false);
            await logSink.FlushAsync().ConfigureAwait(false);

            consoleOutput = testConsole.Output;
        }

        string output = consoleOutput.ScrubDateTime("yyyy-MM-dd HH", replacement: "Timestamp");

        // Assert
        await Verify(output);
    }

    [TestMethod]
    public async Task ShouldPrintAnErrorMessageIfTheFormatIsInvalid()
    {
        // Arrange
        string output = string.Empty;
        SmartConsoleLogSink logSink = new()
        {
            Format = "Timestamp:yyyy-MM-dd HH} ({LogLevel}) ({Senders:list:{}| > }) -> {Payload}"
        };

        string consoleOutput;

        // Act
        using (TestConsole testConsole = new())

        {
            await logSink.SubmitAsync(new LogMessage() { Payload = "Test" }).ConfigureAwait(false);
            await logSink.FlushAsync().ConfigureAwait(false);

            consoleOutput = testConsole.Output;
        }

        output = consoleOutput.ScrubDateTime("yyyy-MM-dd HH", replacement: "Timestamp");

        // Assert
        await Verify(output);
    }
}
