using System.Net;
using System.Net.Sockets;

TcpListener listener = new(IPAddress.Loopback, 5000);

listener.Start();

Console.WriteLine("Waiting for connection...");

TcpClient client = listener.AcceptTcpClient();

Console.WriteLine("Client connected!");
