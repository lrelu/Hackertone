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
		private Thread _thread_serial_check;

		public HMI()
		{
			InitializeComponent();
			this.grbAVR.Enabled = false;
			_thread = new Thread(new ThreadStart(Serial_Read_AVR));
			_thread_serial_check = new Thread(new ThreadStart(SerialCheck));
			_thread.IsBackground = true;
			_thread_serial_check.IsBackground = true;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			Connect(cboPort.Text, Int32.Parse(cboBaudRate.Text));
			_avr.Write(new byte[] { 0x02, 0x54, 0x03 }, 0, 3);
			this.txtTX.Text = "STX " + 0x54.ToString("X") + " ETX";
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
				_thread_serial_check.Start();
			}
				
		}

		private void SerialCheck()
		{
			// 0.1초마다 연결 메세지를 전송
			while (true)
			{
				_avr.Write(new byte[] { 0x02, 0x54, 0x03 }, 0, 3);
				Thread.Sleep(100);
			}
			
		}

		private void Serial_Read_AVR()
		{
			int data;
			while (true)
			{
				data = _avr.ReadByte();

				// 프로토콜의 시작이 도착했다면
				if (data == 0x02)
				{
					data = _avr.ReadByte();
					btnA.BackColor = System.Drawing.Color.DimGray;
					btnB.BackColor = System.Drawing.Color.DimGray;
					btnC.BackColor = System.Drawing.Color.DimGray;

					if (data == 0x31)
						btnA.BackColor = System.Drawing.Color.LightCoral;
					else if (data == 0x32)
						btnB.BackColor = System.Drawing.Color.LightCoral;
					else if (data == 0x33)
						btnC.BackColor = System.Drawing.Color.LightCoral;

					this.txtRX.Text =  "STX " + data.ToString("X") + " ETX";
				}
			}
		}

		private void HMI_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (_avr.IsOpen)
			{
				_avr.Write(new byte[] { 0x02, 0x46, 0x03 }, 0, 3);
				Thread.Sleep(300);
				_avr.Close();
			}
		}

		private void btnAVR_Click(object sender, EventArgs e)
		{
			_avr.Write(new byte[] { 0x02, 0x4E, 0x03 }, 0, 3);
			this.txtTX.Text = "STX " + 0x4E.ToString("X") + " ETX";
		}

		private void btnA_Click(object sender, EventArgs e)
		{
			_avr.Write(new byte[] { 0x02, 0x41, 0x03 }, 0, 3);
			this.txtTX.Text = "STX " + 0x41.ToString("X") + " ETX";
		}

		private void btnB_Click(object sender, EventArgs e)
		{
			_avr.Write(new byte[] { 0x02, 0x42, 0x03 }, 0, 3);
			this.txtTX.Text = "STX " + 0x42.ToString("X") + " ETX";
		}

		private void btnC_Click(object sender, EventArgs e)
		{
			_avr.Write(new byte[] { 0x02, 0x43, 0x03 }, 0, 3);
			this.txtTX.Text = "STX " + 0x43.ToString("X") + " ETX";
		}
	}
}
