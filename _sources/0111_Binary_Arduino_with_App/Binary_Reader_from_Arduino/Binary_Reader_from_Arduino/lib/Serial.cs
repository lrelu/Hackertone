using System;
using System.Collections;
using System.IO.Ports;
using System.Text;

namespace Binary_Reader_from_Arduino.lib
{
	class Serial
	{
		private SerialPort _arduino = new SerialPort();  //시리얼 포트 객체 생성
		FrmAnalytics _frmAnalytics;

		public Serial(FrmAnalytics frm)
		{
			_arduino.PortName = "COM7";		//포트 지정
			_arduino.BaudRate = 9600;			//비트레이트 설정

			// 호출 폼을 인자로 받아 차후에 내부에서 데이터가 들어왔을때 델리게이트 실행
			// 즉 데이터가 수신되었을때, 호출폼에서 연결된 함수로 자동 실행되게끔 진행
			_frmAnalytics = frm;
			_arduino.DataReceived += _arduino_DataReceived;
		}

		// 연결된 시리얼 포트에 데이터가 수신되었을 경우
		private void _arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			// 데이터 읽기
			string data = Read();
			// 데이터 확인용으로 바이너리로 보여지도록 처리
			data = StringToBinary(data);
			// 호출폼의 출력 함수 실행
			_frmAnalytics.Print_SerialData(data);
		}

		// 시리얼 오픈
		public bool StartReading()
		{
			try
			{
				_arduino.Open();                     //오픈
				return true;
			}
			catch
			{
				return false;
			}
		}

		public string Read()
		{
			// 시리얼 포트 값 읽기
			return _arduino.ReadLine();
		}

		// 임시 테스트, 프로토콜에서 명시한 한줄 읽어서 바이너리모습으로 리턴 (데이터 확인용)
		public string StringToBinary(string data)
		{
			byte[] bin;
			bin = System.Text.Encoding.UTF8.GetBytes(data);
			Array.Reverse(bin);
			BitArray bit = new BitArray(bin);
			StringBuilder sb = new StringBuilder();

			for (int i = bit.Length - 1; i >= 0; i--)
			{
				if (bit[i] == true)
					sb.Append(1);
				else
					sb.Append(0);
			}


			return sb.ToString();
		}
	}
}
