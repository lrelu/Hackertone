using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client.lib
{
	class SocketClient
	{
		public static Socket _sender;

		public static void StartClient()
		{
			// 보낼 버퍼사이즈 선언
			byte[] bytes = new byte[1024];
  
			try
			{
				// 호스트 정보 가져오기
				IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
				// 호스트에서 IP정보 가져오기
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				// 엔드포인트(서버쪽) 설정하기
				IPEndPoint remoteEP = new IPEndPoint(ipAddress, 7000);

				// 소켓 생성 및 타입 초기화
				_sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

				try
				{
					// 서버 엔드포인트로 소켓 연결
					_sender.Connect(remoteEP);

					// 서버쪽 엔드 포인트 정보 표시
					Console.WriteLine("Socket connected to {0}", _sender.RemoteEndPoint.ToString());

					// 데이터를 바이너리로 변경 ::는 마지막 데이터  
					byte[] msg = Encoding.UTF8.GetBytes("클라이언트에서 데이터 보내요!::");

					// 연결된 소켓으로 데이터 전송
					int bytesSent = _sender.Send(msg);

					// 연결된 소켓으로 데이터 받기  
					int bytesRec = _sender.Receive(bytes);
					// 받은 데이터를 UTF8변환하고 출력
					Console.WriteLine("Echoed test = {0}", Encoding.UTF8.GetString(bytes, 0, bytesRec));

					// 소켓 닫기
					_sender.Shutdown(SocketShutdown.Both);
					_sender.Close();
				}
				catch (Exception e)
				{
					Console.WriteLine("Unexpected exception : {0}", e.ToString());
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		public static void Receive()
		{

		}
	}
}
