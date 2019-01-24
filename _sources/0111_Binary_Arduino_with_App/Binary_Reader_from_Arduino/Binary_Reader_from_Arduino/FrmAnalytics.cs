using System;
using System.Windows.Forms;
using Binary_Reader_from_Arduino.lib;

namespace Binary_Reader_from_Arduino
{
	public partial class FrmAnalytics : Form
	{
		// 시리얼 통신 객체
		Serial _serial;

		public FrmAnalytics()
		{
			InitializeComponent();

			// 시리얼 객체 생성 및 초기화 (생성자에 COM7, 9600), 
			// this를 넘겨서 시리얼 포트에 데이터 들어왔을때 자동으로 화면에 출력되도록 진행
			_serial = new Serial(this);
		}

		// 시리얼 포트에 값이 전달되면 자동으로 호출되도록 진행
		public void Print_SerialData(string data)
		{
			rtxtSerialRead.Text += data;
			rtxtSerialRead.Text += '\n';
		}

		private void BtnRead_Click(object sender, EventArgs e)
		{
			// 시리얼 포트 오픈
			// 포트 읽기 시작
			if (_serial.StartReading())
			{
				this.BtnRead.Enabled = false;
				this.btnParsing.Enabled = true;
			}
		}
	}
}
