using System.Net.Sockets;

namespace Server;

public sealed class ClientConnection : IDisposable
{
    public TcpClient Client { get; }

    public NetworkStream Stream { get; }

    public string Username { get; set; } = "Unknown";

    public ClientConnection(TcpClient client)
    {
        Client = client;
        Stream = client.GetStream();
    }

    public void Dispose()
    {
        Stream.Dispose();
        Client.Dispose();
    }
}