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

    public async Task AcceptClientAsynk()
    {
        TcpClient client = await _listener.AcceptTcpClientAsync();
        Console.WriteLine("Client connected.");
        client.Close();
    }

    public void Stop()
    {
        _listener.Stop();
        _isRunning = false;
        Console.WriteLine("Server is stopped.");
    }
}