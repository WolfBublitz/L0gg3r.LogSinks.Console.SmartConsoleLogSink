using System.Threading.Tasks;

namespace SmartConsoleLogSinkTests.PropertyTests.FormatPropertyTests;

[TestClass]
public class TheFormatProperty : VerifyBase
{
    [TestMethod]
    public async Task ShouldFormatMessage()
    {
        // Arrange
        string output = string.Empty;
        SmartConsoleLogSink logSink = new()
        {
            Format = "{Timestamp:yyyy-MM-dd HH} ({LogLevel}) ({Senders:list:{}| > }) -> {Payload}"
        };
        ConsoleOutputGrabber consoleOutputGrabber = new();

        // Act
        using (consoleOutputGrabber.Start())

        {
            await logSink.SubmitAsync(new LogMessage() { Payload = "Test" }).ConfigureAwait(false);
            await logSink.FlushAsync().ConfigureAwait(false);
        }

        output = consoleOutputGrabber.Output.ScrubDateTime("yyyy-MM-dd HH", replacement: "Timestamp");

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
        ConsoleOutputGrabber consoleOutputGrabber = new();

        // Act
        using (consoleOutputGrabber.Start())

        {
            await logSink.SubmitAsync(new LogMessage() { Payload = "Test" }).ConfigureAwait(false);
            await logSink.FlushAsync().ConfigureAwait(false);
        }

        output = consoleOutputGrabber.Output.ScrubDateTime("yyyy-MM-dd HH", replacement: "Timestamp");

        // Assert
        await Verify(output);
    }
}