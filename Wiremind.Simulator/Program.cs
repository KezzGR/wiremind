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
int distance = 400;
int battery = 100;

while (true)
{
    distance = random.Next(distance - 10, distance + 10);
    distance = Math.Clamp(distance, 100, 1000);

    if (random.NextDouble() < 0.1 && battery > 0)
        battery -= 1;

    string message = distance.ToString() + ", " + battery.ToString();

    byte[] data = Encoding.UTF8.GetBytes(message);

    stream.Write(data);

    Console.WriteLine($"Send distance: {distance} mm.");
    Console.WriteLine($"Send battery: {battery}.");

    Thread.Sleep(500);
}