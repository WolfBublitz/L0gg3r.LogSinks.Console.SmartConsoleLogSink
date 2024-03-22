// ----------------------------------------------------------------------------
// <copyright file="LogToExtensions.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using System;

namespace L0gg3r.LogSinks.Console.SmartConsoleLogSink;

/// <summary>
/// Provides extension methods for <see cref="LogSinkBuilder"/>.
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
        SmartConsoleLogSink consoleLogSinkBuilder = new();

        return @this.LogSink(consoleLogSinkBuilder);
    }

    public static LoggerBuilder SmartConsole(this LogTo @this, Action<SmartConsoleLogSink> logSinkBuilder)
    {
        ArgumentNullException.ThrowIfNull(logSinkBuilder, nameof(logSinkBuilder));

        SmartConsoleLogSink consoleLogSinkBuilder = new();

        logSinkBuilder(consoleLogSinkBuilder);

        return @this.LogSink(consoleLogSinkBuilder);
    }
}
