// ----------------------------------------------------------------------------
// <copyright file="SimpleConsoleWriter.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace L0gg3r.LogSinks.Console;

public sealed class SimpleConsoleWriter : ILogMessageWriter
{
    /// <inheritdoc/>
    public ILogSink? LogSink { get; set; }

    /// <inheritdoc/>
    public ValueTask<Continuation> WriteAsync(in LogMessage logMessage)
    {
        System.Console.WriteLine(logMessage);

        return ValueTask.FromResult(Continuation.Stop);
    }
}
