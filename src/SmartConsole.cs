// ----------------------------------------------------------------------------
// <copyright file="SmartConsole.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using SmartFormat;

namespace L0gg3r.LogSinks.Console.SmartConsoleLogSink;

public sealed class SmartConsole 
{
    public void WriteLine(string format, params object[] parameters)
    {
        System.Console.Out.WriteLineSmart(format, parameters);
    }
}
