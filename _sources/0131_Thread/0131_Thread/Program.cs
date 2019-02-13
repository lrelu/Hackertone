using System;
using System.Threading;

namespace _0131_Thread
{
	class Program
	{
		static Thread _thread;

		static void Main(string[] args)
		{
			_thread = new Thread(new ThreadStart(Temp));
			_thread.Start();
			_thread.IsBackground = true;
		}

		static void Temp()
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine(i.ToString());
			}
		}
	}
}
