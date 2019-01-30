using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace _0130_HMI_AVR
{
	public partial class HMI : Form
	{
		private SerialPort _avr = new SerialPort();
		private Thread _thread;

		public HMI()
		{
			InitializeComponent();
			this.grbAVR.Enabled = false;
			_thread = new Thread(new ThreadStart(Serial_Read_AVR));
			_thread.IsBackground = true;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			Connect(cboPort.Text, Int32.Parse(cboBaudRate.Text));
		}

		private void Connect(string port, int baudrate)
		{
			_avr.PortName = port;
			_avr.BaudRate = baudrate;
			_avr.DataBits = 8;
			_avr.Parity = Parity.None;
			_avr.StopBits = StopBits.One;

			_avr.Open();

			if (_avr.IsOpen)
			{
				this.grbAVR.Enabled = true;
				this.grbSetting.Enabled = false;
				_thread.Start();
			}
				
		}

		private void Serial_Read_AVR()
		{
			int data;
			while (true)
			{
				data = _avr.ReadByte();

				this.richTextBox1.Text += data.ToString() + " ";

				// 프로토콜의 시작이 도착했다면
				if (data == 0x02)
				{
					data = _avr.ReadByte();
					if (data == 0x46)
						rdoLED.Checked = false;
					else if (data == 0x54)
						rdoLED.Checked = true;

					this.richTextBox1.Text += data.ToString() + " ";
				}
			}
		}

		private void HMI_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_avr.IsOpen)
				_avr.Close();
		}

		private void btnAVR_Click(object sender, EventArgs e)
		{
			if (rdoLED.Checked)
				_avr.Write(new byte[] { 0x02, 0x46, 0x03 }, 0, 3);
			else
				_avr.Write(new byte[] { 0x02, 0x54, 0x03 }, 0, 3);

			//if (_avr.IsOpen)
			//{
			//	_avr.Write(new byte[]{ 0x02, 0x54, 0x03}, 0, 3);
			//}
		}
	}
}
