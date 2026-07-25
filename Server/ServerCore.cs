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

    public async Task AcceptClientsAsync()
    {
        while (_isRunning)
        {
            TcpClient client = await _listener.AcceptTcpClientAsync();

            Console.WriteLine("Client connected.");

            _ =  HandleClientAsync(client);
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        using (client)
        {
            Console.WriteLine("Client handling started.");

            NetworkStream stream = client.GetStream();

            Console.WriteLine("Client stream received.");

            await Task.Delay(5000);

            Console.WriteLine("Client handling finished.");
        }
    }

    public void Stop()
    {
        _listener.Stop();
        _isRunning = false;
        Console.WriteLine("Server is stopped.");
    }
}