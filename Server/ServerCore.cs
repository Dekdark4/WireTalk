using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Server;

public class ServerCore
{
    private readonly TcpListener _listener;
    private readonly List<ClientConnection> _connections = new();
    private readonly object _connectionsLock = new();
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

            ClientConnection connection = new ClientConnection(client);

            lock (_connectionsLock)
            {
                _connections.Add(connection);
            }

            Console.WriteLine("Client connected.");

            _ = HandleClientAsync(connection);
        }
    }

    private async Task HandleClientAsync(ClientConnection connection)
    {
        try
        {
            using (connection)
            {
                Console.WriteLine("Client handling started.");

                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = await connection.Stream.ReadAsync(buffer);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Console.WriteLine($"Received {bytesRead} bytes.");
                    Console.WriteLine($"Client message: {message}");


                    string response = $"Server received: {message}";

                    byte[] responseData = Encoding.UTF8.GetBytes(response);

                    await connection.Stream.WriteAsync(responseData);
                }
            }
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Client connection error: {exception.Message}");
        }
        catch (SocketException exception)
        {
            Console.WriteLine($"Socket error: {exception.Message}");
        }
        finally
        {
            lock (_connectionsLock)
            {
                _connections.Remove(connection);
            }

            Console.WriteLine("Client disconnected.");
        }

        
    }

    public void Stop()
    {
        _listener.Stop();
        _isRunning = false;
        Console.WriteLine("Server is stopped.");
    }
}