using Server;

const int PORT = 11000;

ServerCore server = new(PORT);
server.Start();

await server.AcceptClientAsynk();

Console.WriteLine("Press enter to stop the server...");
Console.ReadLine();

server.Stop();