using System.Net;
using System.Net.Sockets;

Console.WriteLine("Server is starting...");

TcpListener listener = new TcpListener(IPAddress.Any, 11000);

listener.Start();

Console.WriteLine("Server is listening on port 11000...");

Console.ReadLine();