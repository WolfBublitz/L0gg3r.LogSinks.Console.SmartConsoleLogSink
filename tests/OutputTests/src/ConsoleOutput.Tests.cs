using System.Threading.Tasks;

namespace SmartConsoleLogSinkTests.ConsoleOutput.Tests;

[TestClass]
public class TheSmartConsoleLogSink : VerifyBase
{
    [TestMethod]
    public async Task ShouldWriteLogMessageToConsole()
    {
        // Arrange
        SmartConsoleLogSink logSink = new();
        ConsoleOutputGrabber consoleOutputGrabber = new();

        // Act
        using (consoleOutputGrabber.Start())
        {
            await logSink.SubmitAsync(new LogMessage() { Payload = "Test" }).ConfigureAwait(false);
            await logSink.FlushAsync().ConfigureAwait(false);
        }

        string output = consoleOutputGrabber.Output.ScrubDateTime("yyyy-MM-dd HH\\:mm\\:ss.ffffff", replacement: "Timestamp");

        // Assert
        await Verify(output);
    }

    [TestMethod]
    public async Task ShouldWriteALogMessageWithANullPayloadToConsole()
    {
        // Arrange
        SmartConsoleLogSink logSink = new();
        ConsoleOutputGrabber consoleOutputGrabber = new();

        // Act
        using (consoleOutputGrabber.Start())
        {
            await logSink.SubmitAsync(new LogMessage() { Payload = null }).ConfigureAwait(false);
            await logSink.FlushAsync().ConfigureAwait(false);
        }

        string output = consoleOutputGrabber.Output.ScrubDateTime("yyyy-MM-dd HH\\:mm\\:ss.ffffff", replacement: "Timestamp");

        // Assert
        await Verify(output);
    }
}