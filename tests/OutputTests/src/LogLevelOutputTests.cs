using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using L0gg3r.Base;

namespace SmartConsoleLogSinkTests.LogLevelOutputTests;

internal sealed class DebugLogLevelDataAttribute : Attribute, ITestDataSource
{
    public IEnumerable<object?[]> GetData(MethodInfo methodInfo)
    {
        yield return new object?[] { LogLevel.Debug };
    }

    public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
        => LogLevel.Debug.ToString();
}

internal sealed class InfoLogLevelDataAttribute : Attribute, ITestDataSource
{
    public IEnumerable<object?[]> GetData(MethodInfo methodInfo)
    {
        yield return new object?[] { LogLevel.Info };
    }

    public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
        => LogLevel.Info.ToString();
}

internal sealed class WarningLogLevelDataAttribute : Attribute, ITestDataSource
{
    public IEnumerable<object?[]> GetData(MethodInfo methodInfo)
    {
        yield return new object?[] { LogLevel.Warning };
    }

    public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
        => LogLevel.Warning.ToString();
}

internal sealed class ErrorLogLevelDataAttribute : Attribute, ITestDataSource
{
    public IEnumerable<object?[]> GetData(MethodInfo methodInfo)
    {
        yield return new object?[] { LogLevel.Error };
    }

    public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
        => LogLevel.Error.ToString();
}

internal sealed class FatalLogLevelDataAttribute : Attribute, ITestDataSource
{
    public IEnumerable<object?[]> GetData(MethodInfo methodInfo)
    {
        yield return new object?[] { LogLevel.Fatal };
    }

    public string? GetDisplayName(MethodInfo methodInfo, object?[]? data)
        => LogLevel.Fatal.ToString();
}

[TestClass]
public class TheSmartConsoleLogSink : VerifyBase
{
    [DataTestMethod]
    [DebugLogLevelData]
    [InfoLogLevelData]
    [WarningLogLevelData]
    [ErrorLogLevelData]
    [FatalLogLevelData]
    public async Task ShouldWriteAllLogLevels(LogLevel logLevel)
    {
        // Arrange
        SmartConsoleLogSink logSink = new();
        string consoleOutput;

        // Act
        using (TestConsole testConsole = new())
        {
            await logSink.SubmitAsync(new LogMessage() { LogLevel = logLevel }).ConfigureAwait(false);
            await logSink.FlushAsync().ConfigureAwait(false);

            consoleOutput = testConsole.Output;
        }

        string output = consoleOutput.ScrubDateTime("yyyy-MM-dd HH\\:mm\\:ss.ffffff", replacement: "Timestamp");

        // Assert
        await Verify(output).UseParameters(logLevel.ToString());
    }
}
