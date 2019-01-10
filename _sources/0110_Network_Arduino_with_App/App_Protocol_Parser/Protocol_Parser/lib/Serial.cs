using System.IO.Ports;

namespace Protocol_Parser.lib
{
	class Serial
	{
		private SerialPort _arduino = new SerialPort();  //시리얼 포트 객체 생성

		public Serial()
		{
			_arduino.PortName = "COM6";		//포트 지정
			_arduino.BaudRate = 9600;			//비트레이트 설정
			_arduino.Open();							//오픈
		}

		public string Read()
		{
			// 시리얼 포트 값 읽기
			return _arduino.ReadLine();
		}
	}
}
