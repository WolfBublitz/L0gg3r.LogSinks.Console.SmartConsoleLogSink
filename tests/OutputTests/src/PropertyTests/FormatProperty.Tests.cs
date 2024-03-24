using System.Threading.Tasks;

namespace SmartConsoleLogSinkTests.PropertyTests.FormatPropertyTests;

[TestClass]
public class TheFormatProperty
{
    [TestMethod]
    public async Task ShouldFormatMessage()
    {
        // Arrange
        string output = string.Empty;
        SmartConsoleLogSink logSink = new();
        ConsoleOutputGrabber consoleOutputGrabber = new();

        // Act
        using (consoleOutputGrabber.Start())

        {
            await logSink.SubmitAsync(new LogMessage() { Payload = "Test" }).ConfigureAwait(false);
            await logSink.FlushAsync().ConfigureAwait(false);
        }

        // Assert
        output.Should().Contain("Test");
    }
}