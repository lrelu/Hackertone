using System;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;

namespace Server.lib
{
	class SocketServer
	{
		// 읽어올 데이터 저장할 곳
		public static string _data = null;

		public static void StartListening()
		{
			// 읽어올 사이즈 정의
			byte[] bytes = new byte[1024];

			// 호스트 정보 가져오기
			IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
			// 호스트에서 IP정보 가져오기
			IPAddress ipAddress = ipHostInfo.AddressList[0];

			IPAddress ip = new IPAddress()
			// 엔드포인트(서버쪽) 설정하기
			IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 7000);

			// 소켓을 생성하고 초기화 설정하기
			Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

			try
			{
				// 소켓과 엔드포인트 바인딩하기
				listener.Bind(localEndPoint);
				// 소켓을 오픈하며 대기자 10명까지 기다리기
				listener.Listen(10);

				// 기다림 시작
				while (true)
				{
					Console.WriteLine("막연한 기다림 시작... 과연 올까??");
					// 접속된 소켓이 있다면 연결
					Socket handler = listener.Accept();

					_data = null;
					while (true)
					{
						// 연결된 소켓으로 정해준 사이즈만큼 데이터 읽기
						int byteRec = handler.Receive(bytes);
						// 받은 바이너리 데이터를 UTF8로 변경
						_data += Encoding.UTF8.GetString(bytes, 0, byteRec);

						// 받은 데이터 중에 마침문자 ::가 있으면 종료, 아님 계속 읽기
						if (_data.IndexOf("::") > -1)
							break;
					}

					// 데이터를 다 받았다면 출력
					Console.WriteLine("Text received : {0}", _data);

					// 받은 데이터를 바이트 배열로 변경
					byte[] msg = Encoding.UTF8.GetBytes(_data);

					// 연결된 소켓으로 에코
					handler.Send(msg);

					// 소켓 닫음
					handler.Shutdown(SocketShutdown.Both);
					handler.Close();
				}
			}
			catch (Exception ex)
			{
				Debug.Print(ex.Message);
			}

			Console.WriteLine("\nPress ENTER to continue...");
			Console.Read();
		}
	}
}
