using System.Net;
using System.Net.Sockets;
using System.Text;

TcpListener listener = new(IPAddress.Loopback, 5000);

listener.Start();

Console.WriteLine("Waiting for connection...");

TcpClient client = listener.AcceptTcpClient();

Console.WriteLine("Client connected!");

NetworkStream stream = client.GetStream();

string message = "457";

byte[] data = Encoding.UTF8.GetBytes(message);

stream.Write(data);

Console.WriteLine($"Send message: {message}.");