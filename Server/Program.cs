using Server;

const int PORT = 11000;

ServerCore server = new(PORT);

Console.WriteLine("Server is running on port " + PORT);

Console.ReadLine();