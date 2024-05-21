using System;
using System.Threading.Tasks;
using L0gg3r.Base;

namespace SmartConsoleLogSinkTests.TimestampOutputTests;

[TestClass]
public class TheSmartConsoleLogSink : VerifyBase
{
    [TestMethod]
    public async Task ShouldWriteTimestampsToConsole()
    {
        // Arrange
        SmartConsoleLogSink logSink = new();
        string consoleOutput;
        LogMessage logMessage = new()
        {
            Timestamp = new DateTimeOffset(),
        };

        // Act
        using (TestConsole testConsole = new())
        {
            await logSink.SubmitAsync(logMessage).ConfigureAwait(false);
            await logSink.FlushAsync().ConfigureAwait(false);

            consoleOutput = testConsole.Output;
        }

        // Assert
        await Verify(consoleOutput);
    }
}
