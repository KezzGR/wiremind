using System.Net;
using System.Net.Sockets;
using System.Text;

TcpClient client = new();

Console.WriteLine("Connecting...");

client.Connect(IPAddress.Loopback, 5000);

Console.WriteLine("Connected!");

NetworkStream stream = client.GetStream();
StreamReader reader = new(stream, Encoding.UTF8);

while (true)
{
    string? message = reader.ReadLine();

    if (message is null)
    {
        Console.WriteLine("Simulator disconnected.");
        break;
    }

    string[] telemetry = message.Split(", ");

    Console.WriteLine($"Distance: {telemetry[0]} mm.");
    Console.WriteLine($"Battery: {telemetry[1]}.");
}