using System;
using System.Threading.Tasks;
using L0gg3r.Base;

namespace SmartConsoleLogSinkTests.PayloadOutputTests;

[TestClass]
public class TheSmartConsoleLogSink : VerifyBase
{
    [TestMethod]
    public async Task ShouldWriteLogMessageToConsole()
    {
        // Arrange
        SmartConsoleLogSink logSink = new();
        string consoleOutput;

        // Act
        using (TestConsole testConsole = new())
        {
            await logSink.SubmitAsync(new LogMessage() { Payload = "Test" }).ConfigureAwait(false);
            await logSink.FlushAsync().ConfigureAwait(false);

            consoleOutput = testConsole.Output;
        }

        string output = consoleOutput.ScrubDateTime("yyyy-MM-dd HH\\:mm\\:ss.ffffff", replacement: "Timestamp");

        // Assert
        await Verify(output);
    }

    [TestMethod]
    public async Task ShouldWriteALogMessageWithAExceptionPayloadToConsole()
    {
        // Arrange
        SmartConsoleLogSink logSink = new();
        string consoleOutput;
        LogMessage logMessage = new();

        static void action() => throw new Exception("Some error");

        try
        {
            action();
        }
        catch (Exception exception)
        {
            // Act
            using (TestConsole testConsole = new())
            {
                await logSink.SubmitAsync(new LogMessage() { Payload = exception, }).ConfigureAwait(false);
                await logSink.FlushAsync().ConfigureAwait(false);

                consoleOutput = testConsole.Output;
            }
        }

        string output = consoleOutput.ScrubDateTime("yyyy-MM-dd HH\\:mm\\:ss.ffffff", replacement: "Timestamp");

        // Assert
        await Verify(output);
    }

    [TestMethod]
    public async Task ShouldWriteALogMessageWithANullPayloadToConsole()
    {
        // Arrange
        SmartConsoleLogSink logSink = new();
        string consoleOutput;

        // Act
        using (TestConsole testConsole = new())
        {
            await logSink.SubmitAsync(new LogMessage() { Payload = null }).ConfigureAwait(false);
            await logSink.FlushAsync().ConfigureAwait(false);

            consoleOutput = testConsole.Output;
        }

        string output = consoleOutput.ScrubDateTime("yyyy-MM-dd HH\\:mm\\:ss.ffffff", replacement: "Timestamp");

        // Assert
        await Verify(output);
    }
}
