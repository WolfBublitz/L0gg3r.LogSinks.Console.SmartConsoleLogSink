// ----------------------------------------------------------------------------
// <copyright file="LogToExtensions.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using System;

using L0gg3r.Builder;

namespace L0gg3r.LogSinks.Console.SmartConsoleLogSink;

/// <summary>
/// Provides extension methods for <see cref="LogTo"/>.
/// </summary>
public static class LogToExtensions
{
    /// <summary>
    /// Creates a new <see cref="SmartConsoleLogSink"/> and adds it to the <see cref="LogSinkBuilder"/>.
    /// </summary>
    /// <param name="this">This <see cref="LogSinkBuilder"/>.</param>
    /// <returns>The <see cref="LoggerBuilder"/>.</returns>
    public static LoggerBuilder SmartConsole(this LogTo @this)
    {
        return @this.SmartConsole(new SmartConsoleLogSink());
    }

    public static LoggerBuilder SmartConsole(this LogTo @this, SmartConsoleLogSink smartConsoleLogSink)
    {
        ArgumentNullException.ThrowIfNull(@this, nameof(@this));
        ArgumentNullException.ThrowIfNull(smartConsoleLogSink, nameof(smartConsoleLogSink));

        return @this.LogSink(smartConsoleLogSink);
    }

    public static LoggerBuilder SmartConsole(this LogTo @this, Action<SmartConsoleLogSink> logSinkBuilder)
    {
        ArgumentNullException.ThrowIfNull(@this, nameof(@this));
        ArgumentNullException.ThrowIfNull(logSinkBuilder, nameof(logSinkBuilder));

        SmartConsoleLogSink smartConsoleLogSink = new();

        logSinkBuilder(smartConsoleLogSink);

        return @this.SmartConsole(smartConsoleLogSink);
    }
}
