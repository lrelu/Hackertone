using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace LED_Control
{
	public partial class Form1 : Form
	{
		SerialPort _serial;
		bool _isLED;

		public Form1()
		{
			InitializeComponent();
			
			// 시리얼 포트 설정
			_serial = new SerialPort("COM7", 9600);
			// LED 기본값을 꺼짐
			_isLED = false;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			// 포트 오픈 (차후에 에러처리 필요함)
			_serial.Open();
			// 버튼 제어
			this.btnConnect.Enabled = false;
			this.btnLEDControl.Enabled = true;
			this.grpServo.Enabled = true;
		}

		private void btnLEDControl_Click(object sender, EventArgs e)
		{
			_isLED = !_isLED;
			
			_serial.Write((_isLED) ? "1" : "0");
			this.btnLEDControl.Text = (_isLED) ? "LED 끄기" : "LED 켜기";
		}

		private void btnServoLeft_Click(object sender, EventArgs e)
		{
			_serial.Write("L");
		}

		private void btnServoRight_Click(object sender, EventArgs e)
		{
			_serial.Write("R");
		}
	}
}
