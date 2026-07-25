using System.Text;
using System.Net.Sockets;

const string SERVER_IP = "127.0.0.1";
const int SERVER_PORT = 11000;
const string EXIT_COMMAND = "/exit";

Console.WriteLine("Client is starting...");

using TcpClient client = new();

Console.WriteLine("Connecting to server...");

await client.ConnectAsync(SERVER_IP, SERVER_PORT);

Console.WriteLine("Connected to server.");
Console.WriteLine($"Type {EXIT_COMMAND} to disconnect.");

NetworkStream stream = client.GetStream();

while(true)
{
    Console.Write("Message to send: ");
    string message = Console.ReadLine() ?? string.Empty;

    if(message == EXIT_COMMAND)
    {
        break;
    }

    if(message.Length == 0)
    {
        Console.WriteLine("Message cannot be empty.");
        continue;
    }

    byte[] data = Encoding.UTF8.GetBytes(message);

    await stream.WriteAsync(data);

    Console.WriteLine("Message sent.");
}


Console.WriteLine("Press enter to disconnect...");
Console.ReadLine();