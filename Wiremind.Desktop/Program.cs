using System.Net;
using System.Net.Sockets;
using System.Text;

TcpClient client = new();

Console.WriteLine("Connecting...");

client.Connect(IPAddress.Loopback, 5000);

Console.WriteLine("Connected!");

NetworkStream stream = client.GetStream();

byte[] buffer = new byte[1024];

while (true)
{
    int bytesCount = stream.Read(buffer);

    string message = Encoding.UTF8.GetString(buffer, 0, bytesCount);

    string[] telemetry = message.Split(", ");

    Console.WriteLine($"Distance: {telemetry[0]} mm.");
    Console.WriteLine($"Battery: {telemetry[1]}.");
}