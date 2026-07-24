using Server;

const int PORT = 11000;

ServerCore server = new(PORT);
server.Start();

Console.WriteLine("Press enter to stop the server...");
Console.ReadLine();

server.Stop();