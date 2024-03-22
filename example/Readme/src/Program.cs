using L0gg3r;
using L0gg3r.LogSinks.Console.SmartConsoleLogSink;

await using (Logger logger = Logger.CreateLogger().LogTo.SmartConsole().Build())
{
    logger.Info("Hello, World!");
}

string format = "{Timestamp:yyyy-MM-dd}[{LogLevel}] [{Senders:list:{}| > }] {Payload}";

await using (Logger logger = Logger.CreateLogger().LogTo.SmartConsole(console => console.Format = format).Build())
{
    logger.Info("Hello, World!");
}

