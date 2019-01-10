using System;
using System.Threading;
using System.Windows.Forms;
using Protocol_Parser.lib;

namespace Protocol_Parser
{
	public partial class FrmAnalytics : Form
	{
		private Serial _serial;
		private bool _isPasing;
		private Thread _thread;

		public FrmAnalytics()
		{
			InitializeComponent();

			// 초기화
			// 시리얼포트 생성 및 연결
			_serial = new Serial();
			// 읽기 모드는 우선 중지
			_isPasing = false;
			// 안전하지 않지만 테스트 스레드 생성
			_thread = new Thread(new ThreadStart(ReadSerial));
			_thread.IsBackground = true;
		}

		private void ReadSerial()
		{
			// 임시 저장 변수 선언
			string str = string.Empty;
			string temperature = string.Empty;
			string huminity = string.Empty;
			string bright = string.Empty;
			string distance = string.Empty;

			// 1초마다 지정된 COM6포트에서 데이터 읽기
			while (true)
			{
				str = _serial.Read().Trim();

				// 파싱모드일 경우엔
				if (_isPasing)
				{
					// 입력받은 데이터가 Json 타입일 경우
					if (Parser.IsJson(str))
					{
						// Json 파싱
						if (Parser.Json(str, out temperature, out huminity, out bright, out distance))
							str = string.Format("온도: {0} 습도: {1} 조도: {2} 거리: {3}", temperature, huminity, bright, distance);
						else
							str = "Json Parsing Error...";
					}
					else
					{
						// 텍스트파싱
						if (Parser.Text(str, out temperature, out huminity, out bright, out distance))
							str = string.Format("온도: {0} 습도: {1} 조도: {2} 거리: {3}", temperature, huminity, bright, distance);
						else
							str = "Protocol Parsing Error...";
					}
				}

				this.rtxtSerialRead.Text += str;
				this.rtxtSerialRead.Text += '\n';
				this.rtxtSerialRead.Select(this.rtxtSerialRead.Text.Length - 1, 0);
				this.rtxtSerialRead.ScrollToCaret();

				Thread.Sleep(1000);
			}
		}

		private void BtnRead_Click(object sender, EventArgs e)
		{
			// 시리얼포트 읽기 스레드 시작
			_thread.Start();
			this.btnParsing.Enabled = true;
			this.BtnRead.Enabled = false;
		}

		private void btnParsing_Click(object sender, EventArgs e)
		{
			// 파싱모드 변경
			_isPasing = !_isPasing;

			if (_isPasing)
				this.btnParsing.Text = "파싱모드 중지";
			else
				this.btnParsing.Text = "파싱모드 실행";
		}
	}
}
