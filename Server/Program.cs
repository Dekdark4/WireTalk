using Server;

const int PORT = 11000;

ServerCore server = new(PORT);
server.Start();

await server.AcceptClientsAsync();