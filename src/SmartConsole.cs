// ----------------------------------------------------------------------------
// <copyright file="SmartConsole.cs" company="L0gg3r">
// Copyright (c) L0gg3r Project
// </copyright>
// ----------------------------------------------------------------------------

using System;

using L0gg3r.LogSinks.Console.Base;

using SmartFormat;

namespace L0gg3r.LogSinks.Console.SmartConsoleLogSink;

/// <summary>
/// A console that uses SmartFormat to write messages.
/// </summary>
public sealed class SmartConsole : IConsole
{
    // ┌────────────────────────────────────────────────────────────────────────────────┐
    // │ Public Methods                                                                 │
    // └────────────────────────────────────────────────────────────────────────────────┘

    /// <inheritdoc/>
    public TValue Ask<TValue>(string question, Func<string, TValue> converter, TValue defaultAnswer)
    {
        if (((IConsole)this).IsInteractive)
        {
            ArgumentNullException.ThrowIfNull(converter, nameof(converter));

            while (true)
            {
                System.Console.Write($"{question}: ");

                string? input = System.Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

#pragma warning disable CA1031 // Do not catch general exception types
                try
                {
                    return converter(input);
                }
                catch (Exception)
                {
                }
#pragma warning restore CA1031 // Do not catch general exception types
            }
        }
        else
        {
            return defaultAnswer;
        }
    }

    /// <inheritdoc/>
    public bool Confirm(string question, bool defaultAnswer)
    {
        if (((IConsole)this).IsInteractive)
        {
            while (true)
            {
                System.Console.Write($"{question} (y/n): ");

                string? input = System.Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }
                else if (input.Equals("y", StringComparison.OrdinalIgnoreCase) || input.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
                else if (input.Equals("n", StringComparison.OrdinalIgnoreCase) || input.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
        }
        else
        {
            return defaultAnswer;
        }
    }

    /// <inheritdoc/>
    public void Write(string message) => WriteSmart(message);

    /// <inheritdoc/>
    public void WriteLine(string message) => WriteLineSmart(message);

    /// <inheritdoc/>
    public void WriteLine() => WriteLineSmart(string.Empty);

    /// <summary>
    /// Writes a formatted string to the console.
    /// </summary>
    /// <remarks>
    /// The <paramref name="message"/> can be a format string using the SmartFormat syntax. The placeholders
    /// will be replaced by the <paramref name="parameters"/>.
    /// </remarks>
    /// <param name="message">The message or format string.</param>
    /// <param name="parameters">A list parameters.</param>
    /// <seealso cref="WriteLineSmart(string, object[])"/>
#pragma warning disable CA1822 // Mark members as static
    public void WriteSmart(string message, params object[] parameters) => System.Console.Out.WriteSmart(message, parameters);
#pragma warning restore CA1822 // Mark members as static

    /// <summary>
    /// Writes a formatted string followed by a line terminator to the console.
    /// </summary>
    /// <remarks>
    /// The <paramref name="message"/> can be a format string using the SmartFormat syntax. The placeholders
    /// will be replaced by the <paramref name="parameters"/>.
    /// </remarks>
    /// <param name="message">The message or format string.</param>
    /// <param name="parameters">A list parameters.</param>
    /// <seealso cref="WriteSmart(string, object[])"/>
#pragma warning disable CA1822 // Mark members as static
    public void WriteLineSmart(string message, params object[] parameters) => System.Console.Out.WriteLineSmart(message, parameters);
#pragma warning restore CA1822 // Mark members as static
}
