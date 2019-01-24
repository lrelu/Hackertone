using Server.lib;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			SocketServer.StartListening();
		}
	}
}
