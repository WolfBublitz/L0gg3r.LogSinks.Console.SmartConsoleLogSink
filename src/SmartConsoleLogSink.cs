// ----------------------------------------------------------------------------
// <copyright file="SmartConsoleLogSink.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using SmartFormat.Core.Parsing;

namespace L0gg3r.LogSinks.Console.SmartConsoleLogSink;

/// <summary>
/// A simple log sink that writes <see cref="LogMessage"/>s to the console.
/// </summary>
public class SmartConsoleLogSink : LogSinkBase
{
    // ┌────────────────────────────────────────────────────────────────────────────────┐
    // │ Private Fields                                                                 │
    // └────────────────────────────────────────────────────────────────────────────────┘
    private readonly SmartConsole smartConsole = new();

    // ┌────────────────────────────────────────────────────────────────────────────────┐
    // │ Public Constructors                                                            │
    // └────────────────────────────────────────────────────────────────────────────────┘

    /// <summary>
    /// Initializes a new instance of the <see cref="SmartConsoleLogSink"/> class.
    /// </summary>
    public SmartConsoleLogSink()
    {
        ServiceProvider.RegisterServiceInstance(smartConsole);
    }

    /// <summary>
    /// Gets or sets the format of the <see cref="LogMessage"/>.
    /// </summary>
    public string Format { get; set; } = "{Timestamp:yyyy-MM-dd HH\\:mm\\:ss.ffffff} [{LogLevel}] [{Senders:list:{}| > }] {Payload}";

    // ┌────────────────────────────────────────────────────────────────────────────────┐
    // │ Protected Methods                                                              │
    // └────────────────────────────────────────────────────────────────────────────────┘

    /// <inheritdoc/>
    /// <seealso cref="WriteAsync(in LogMessage, SmartConsole)"/>
    protected sealed override ValueTask WriteAsync(in LogMessage logMessage)
    {
        return WriteAsync(logMessage, smartConsole);
    }

    /// <summary>
    /// Writes the <see cref="LogMessage"/> to the console using the <paramref name="smartConsole"/>.
    /// </summary>
    /// <param name="logMessage">The <see cref="LogMessage"/> to write.</param>
    /// <param name="smartConsole">The <see cref="SmartConsole"/> that shall be written to.</param>
    /// <returns>A <see cref="ValueTask"/> that completes when the writing has finished.</returns>
    protected virtual ValueTask WriteAsync(in LogMessage logMessage, SmartConsole smartConsole)
    {
        ArgumentNullException.ThrowIfNull(smartConsole, nameof(smartConsole));

        try
        {
            smartConsole.WriteLine(Format, logMessage);
        }
        catch (ParsingErrors parsingErrors)
        {
            System.Console.WriteLine(parsingErrors.Message);
        }

        return ValueTask.CompletedTask;
    }
}
