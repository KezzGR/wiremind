using System.Net;
using System.Net.Sockets;
using System.Text;

TcpListener listener = new(IPAddress.Loopback, 5000);

listener.Start();

Console.WriteLine("Waiting for connection...");

TcpClient client = listener.AcceptTcpClient();

Console.WriteLine("Client connected!");

NetworkStream stream = client.GetStream();

Random random = new();

while (true)
{
    int distance = random.Next(100, 1000);
    int battery = random.Next(1, 101);

    string message = distance.ToString() + ", " + battery.ToString();

    byte[] data = Encoding.UTF8.GetBytes(message);

    stream.Write(data);

    Console.WriteLine($"Send distance: {distance} mm.");
    Console.WriteLine($"Send battery: {battery}.");

    Thread.Sleep(500);
}