using System.Net;
using System.Net.Sockets;

namespace Server;

public class ServerCore
{
    private readonly TcpListener _listener;

    public ServerCore(int port)
    {
        _listener = new TcpListener(IPAddress.Any, port);
    }
}