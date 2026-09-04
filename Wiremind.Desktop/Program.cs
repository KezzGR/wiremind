using System.Net;
using System.Net.Sockets;
using System.Text;

TcpClient client = new();

Console.WriteLine("Connecting...");

client.Connect(IPAddress.Loopback, 5000);

Console.WriteLine("Connected!");


NetworkStream stream = client.GetStream();

byte[] buffer = new byte[1024];

int bytesRead = stream.Read(buffer);

string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

System.Console.WriteLine($"Received message: {message}.");