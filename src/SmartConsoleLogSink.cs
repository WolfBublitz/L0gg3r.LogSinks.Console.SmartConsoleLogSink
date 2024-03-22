// ----------------------------------------------------------------------------
// <copyright file="SmartConsoleLogSink.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using System.Threading.Tasks;

using SmartFormat;

namespace L0gg3r.LogSinks.Console.SmartConsoleLogSink;

/// <summary>
/// A simple log sink that writes <see cref="LogMessage"/>s to the console.
/// </summary>
public sealed class SmartConsoleLogSink : LogSinkBase
{
    /// <summary>
    /// Gets or sets the format of the <see cref="LogMessage"/>.
    /// </summary>
    public string Format { get; set; } = "{Timestamp:yyyy-MM-dd HH\\:mm\\:ss.ffffff} [{LogLevel}] [{Senders:list:{}| > }] {Payload}";

    // ┌────────────────────────────────────────────────────────────────────────────────┐
    // │ Protected Methods                                                              │
    // └────────────────────────────────────────────────────────────────────────────────┘

    /// <inheritdoc/>
    protected override ValueTask WriteAsync(in LogMessage logMessage)
    {
        string output = Smart.Format(Format, logMessage);

        System.Console.WriteLine(output);

        return ValueTask.CompletedTask;
    }
}
