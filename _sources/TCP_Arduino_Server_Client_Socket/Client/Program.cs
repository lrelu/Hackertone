using System;
using System.Windows.Forms;
using Client.lib;

namespace Client
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			//테스트
			//SocketClient.StartClient();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Board());
		}
	}
}
