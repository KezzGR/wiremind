using System.Net;
using System.Net.Sockets;

TcpClient client = new();

Console.WriteLine("Connecting...");

client.Connect(IPAddress.Loopback, 5000);

Console.WriteLine("Connected!");
