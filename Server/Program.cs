using System.Net;
using System.Net.Sockets;

const int PORT = 11000;


Console.WriteLine("Server is starting...");


TcpListener listener = new TcpListener(IPAddress.Any, PORT);
listener.Start();

Console.WriteLine("Server is listening on port {0}...", PORT);


Console.WriteLine("Waiting for client...");

TcpClient client = listener.AcceptTcpClient();

Console.WriteLine("Client connected.");


Console.ReadLine();