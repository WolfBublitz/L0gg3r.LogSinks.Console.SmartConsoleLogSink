# Smart Console Log Sink

This is a simple L0gg3r log sink that logs to the console and uses [SmartFormat](https://github.com/axuno/SmartFormat) to format log messages.

## Features

- Simple to use
- Customizable format string
- No Color support

## Installation

```console
dotnet add package L0gg3r.LogSinks.Console.SmartConsoleLogSink
```

## Configuration

The `SmartConsoleLogSink` as a `Format` property that can be set to a custom format string. The default format string is: `{Timestamp:yyyy-MM-dd HH\\:mm\\:ss.ffffff} [{LogLevel}] [{Senders:list:{}| > }] {Payload}`

Available placeholders are:

| Placeholder | Type       | Description                                       |
|-------------|------------|---------------------------------------------------|
| `Timestamp` | `DateTime` | The time the log message was created.             |
| `LogLevel`  | `LogLevel` | The log level of the message.                     |
| `Senders`   | `string[]` | The list of senders that created the log message. |
| `Payload`   | `object`   | The payload of the log message.                   |

```c#

## Examples

### Basic Usage

```c#
using L0gg3r;
using L0gg3r.LogSinks.Console.SmartConsoleLogSink;

await using (Logger logger = LoggerBuilder.Create().LogTo.Console())
{
    logger.Info("Hello, World!");
}
```
Output: `2024-03-22 13:54:02.457352 [Info] [Readme] Hello, World!`

### With Customized Format String

```c#
using L0gg3r;
using L0gg3r.LogSinks.Console.SmartConsoleLogSink;

// this is the new format string
string formatWithoutTime = "{Timestamp:yyyy-MM-dd} [{LogLevel}] [{Senders:list:{}| > }] {Payload}";

await using (Logger logger = Logger.CreateLogger().LogTo.SmartConsole(console => console.Format = formatWithoutTime).Build())
{
    logger.Info("Hello, World!");
}
```
Output: `2024-03-22 [Info] [Readme] Hello, World!`
