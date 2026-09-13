namespace Wiremind.Desktop;

public static class TelemetryReader
{
    public static string[]? Read(StreamReader reader)
    {
        string? message = reader.ReadLine();

        if (message is null)
            return null;

        return message.Split(", ");
    }
}