// ----------------------------------------------------------------------------
// <copyright file="SmartConsole.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using System;

using L0gg3r.LogSinks.Console.Base;

using SmartFormat;

namespace L0gg3r.LogSinks.Console.SmartConsoleLogSink;

public sealed class SmartConsole : IConsole
{
    public bool IsInteractive { get; set; }

    /// <inheritdoc/>
    public TValue Ask<TValue>(string question, Func<string, TValue> converter, TValue defaultAnswer)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public bool Confirm(string question, bool defaultAnswer)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void Write(string message) => WriteSmart(message);

    /// <inheritdoc/>
    public void WriteLine(string message) => WriteLineSmart(message);

    /// <inheritdoc/>
    public void WriteLine() => WriteLineSmart(string.Empty);

    public void WriteSmart(string format, params object[] parameters)
    {
        System.Console.Out.WriteSmart(format, parameters);
    }

    public void WriteLineSmart(string format, params object[] parameters)
    {
        System.Console.Out.WriteLineSmart(format, parameters);
    }
}
