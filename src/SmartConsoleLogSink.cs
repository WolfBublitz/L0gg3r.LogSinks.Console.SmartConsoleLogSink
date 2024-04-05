// ----------------------------------------------------------------------------
// <copyright file="SmartConsoleLogSink.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

using L0gg3r.LogSinks.Console.Base;

using SmartFormat.Core.Parsing;

namespace L0gg3r.LogSinks.Console.SmartConsoleLogSink;

/// <summary>
/// A simple log sink that writes <see cref="LogMessage"/>s to the console.
/// </summary>
public class SmartConsoleLogSink : ConsoleLogSinkBase<SmartConsole>
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
        : base(new SmartConsole())
    {
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
    protected sealed override ValueTask WriteAsync(in LogMessage logMessage, SmartConsole console)
    {
        ArgumentNullException.ThrowIfNull(this.smartConsole, nameof(SmartConsoleLogSink.smartConsole));

        try
        {
            this.smartConsole.WriteLineSmart(Format, logMessage);
        }
        catch (ParsingErrors parsingErrors)
        {
            System.Console.WriteLine(parsingErrors.Message);
        }

        return ValueTask.CompletedTask;
    }
}
