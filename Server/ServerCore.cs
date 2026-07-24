using System.Net;
using System.Net.Sockets;

namespace Server;

public class ServerCore
{
    private readonly TcpListener _listener;
    private bool _isRunning;

    public ServerCore(int port)
    {
        _listener = new TcpListener(IPAddress.Any, port);
    }

    public void Start()
    {
        _listener.Start();
        _isRunning = true;
        Console.WriteLine("Server is started and waiting for client...");
    }
}