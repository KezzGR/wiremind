using System.Net;
using System.Net.Sockets;
using System.Text;
using Wiremind.Desktop;

TcpClient client = new();

Console.WriteLine("Connecting...");

client.Connect(IPAddress.Loopback, 5000);

Console.WriteLine("Connected!");

NetworkStream stream = client.GetStream();
StreamReader reader = new(stream, Encoding.UTF8);

while (true)
{
    string[]? telemetry = TelemetryReader.Read(reader);

    if (telemetry is null)
    {
        Console.WriteLine("Simulator disconnected.");
        break;
    }

    Console.WriteLine($"Distance: {telemetry[0]} mm.");
    Console.WriteLine($"Battery: {telemetry[1]}.");
}