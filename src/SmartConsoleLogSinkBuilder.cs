// ----------------------------------------------------------------------------
// <copyright file="SmartConsoleLogSinkBuilder.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using L0gg3r.Builder;

namespace L0gg3r.LogSinks.Console.SmartConsoleLogSink;

/// <summary>
/// The builder for <see cref="SmartConsoleLogSink"/>.
/// </summary>
public class SmartConsoleLogSinkBuilder : LogSinkBuilder<SmartConsoleLogSink, SmartConsoleLogSinkBuilder>
{
    // ┌────────────────────────────────────────────────────────────────┐
    // │ Public Methods                                                 │
    // └────────────────────────────────────────────────────────────────┘

    /// <summary>
    /// Creates a <see cref="SmartConsoleLogSink"/> with the specified <paramref name="format"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The format string is
    /// </para>
    /// <para>
    /// The default format is "{Timestamp:yyyy-MM-dd HH\\:mm\\:ss.ffffff} [{LogLevel}] [{Senders:list:{}| > }] {Payload}".
    /// </para>
    /// </remarks>
    /// <param name="format">The format string.</param>
    /// <returns>This <see cref="SmartConsoleLogSinkBuilder"/> instance.</returns>
    public SmartConsoleLogSinkBuilder WithFormat(string format)
    {
        return WithModification(logSink => logSink.Format = format);
    }
}
