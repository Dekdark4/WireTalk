using System.Net.Sockets;

const string SERVER_IP = "127.0.0.1";
const int SERVER_PORT = 11000;

Console.WriteLine("Client is starting...");

using TcpClient client = new();

Console.WriteLine("Connecting to server...");

await client.ConnectAsync(SERVER_IP, SERVER_PORT);

Console.WriteLine("Connected to server.");

Console.WriteLine("Press enter to disconnect...");
Console.ReadLine();