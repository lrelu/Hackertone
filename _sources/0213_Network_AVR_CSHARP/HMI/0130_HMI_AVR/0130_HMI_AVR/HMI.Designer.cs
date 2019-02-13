namespace _0130_HMI_AVR
{
	partial class HMI
	{
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		/// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 디자이너에서 생성한 코드

		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다. 
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
		/// </summary>
		private void InitializeComponent()
		{
			this.grbSetting = new System.Windows.Forms.GroupBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.cboBaudRate = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cboPort = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.grbAVR = new System.Windows.Forms.GroupBox();
			this.rdoLED = new System.Windows.Forms.RadioButton();
			this.btnAVR = new System.Windows.Forms.Button();
			this.btnA = new System.Windows.Forms.Button();
			this.btnB = new System.Windows.Forms.Button();
			this.btnC = new System.Windows.Forms.Button();
			this.txtRX = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTX = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.grbSetting.SuspendLayout();
			this.grbAVR.SuspendLayout();
			this.SuspendLayout();
			// 
			// grbSetting
			// 
			this.grbSetting.Controls.Add(this.btnConnect);
			this.grbSetting.Controls.Add(this.cboBaudRate);
			this.grbSetting.Controls.Add(this.label2);
			this.grbSetting.Controls.Add(this.cboPort);
			this.grbSetting.Controls.Add(this.label1);
			this.grbSetting.Location = new System.Drawing.Point(12, 12);
			this.grbSetting.Name = "grbSetting";
			this.grbSetting.Size = new System.Drawing.Size(427, 75);
			this.grbSetting.TabIndex = 0;
			this.grbSetting.TabStop = false;
			this.grbSetting.Text = "AVR 연결설정";
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(322, 31);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(99, 25);
			this.btnConnect.TabIndex = 2;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// cboBaudRate
			// 
			this.cboBaudRate.FormattingEnabled = true;
			this.cboBaudRate.Items.AddRange(new object[] {
            "9600",
            "115200"});
			this.cboBaudRate.Location = new System.Drawing.Point(233, 32);
			this.cboBaudRate.Name = "cboBaudRate";
			this.cboBaudRate.Size = new System.Drawing.Size(72, 23);
			this.cboBaudRate.TabIndex = 1;
			this.cboBaudRate.Text = "9600";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(156, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 15);
			this.label2.TabIndex = 0;
			this.label2.Text = "BaudRate";
			// 
			// cboPort
			// 
			this.cboPort.FormattingEnabled = true;
			this.cboPort.Location = new System.Drawing.Point(64, 32);
			this.cboPort.Name = "cboPort";
			this.cboPort.Size = new System.Drawing.Size(72, 23);
			this.cboPort.TabIndex = 1;
			this.cboPort.Text = "COM3";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "PORT";
			// 
			// grbAVR
			// 
			this.grbAVR.Controls.Add(this.btnC);
			this.grbAVR.Controls.Add(this.btnB);
			this.grbAVR.Controls.Add(this.btnA);
			this.grbAVR.Controls.Add(this.rdoLED);
			this.grbAVR.Controls.Add(this.btnAVR);
			this.grbAVR.Location = new System.Drawing.Point(12, 93);
			this.grbAVR.Name = "grbAVR";
			this.grbAVR.Size = new System.Drawing.Size(427, 68);
			this.grbAVR.TabIndex = 1;
			this.grbAVR.TabStop = false;
			this.grbAVR.Text = "AVR";
			// 
			// rdoLED
			// 
			this.rdoLED.AutoSize = true;
			this.rdoLED.Location = new System.Drawing.Point(142, 27);
			this.rdoLED.Name = "rdoLED";
			this.rdoLED.Size = new System.Drawing.Size(66, 19);
			this.rdoLED.TabIndex = 4;
			this.rdoLED.TabStop = true;
			this.rdoLED.Text = "isCon";
			this.rdoLED.UseVisualStyleBackColor = true;
			// 
			// btnAVR
			// 
			this.btnAVR.Location = new System.Drawing.Point(14, 24);
			this.btnAVR.Name = "btnAVR";
			this.btnAVR.Size = new System.Drawing.Size(122, 25);
			this.btnAVR.TabIndex = 3;
			this.btnAVR.Text = "AVR Button";
			this.btnAVR.UseVisualStyleBackColor = true;
			this.btnAVR.Click += new System.EventHandler(this.btnAVR_Click);
			// 
			// btnA
			// 
			this.btnA.BackColor = System.Drawing.Color.DimGray;
			this.btnA.Location = new System.Drawing.Point(282, 23);
			this.btnA.Name = "btnA";
			this.btnA.Size = new System.Drawing.Size(44, 26);
			this.btnA.TabIndex = 5;
			this.btnA.Text = "A";
			this.btnA.UseVisualStyleBackColor = false;
			this.btnA.Click += new System.EventHandler(this.btnA_Click);
			// 
			// btnB
			// 
			this.btnB.BackColor = System.Drawing.Color.DimGray;
			this.btnB.Location = new System.Drawing.Point(326, 23);
			this.btnB.Name = "btnB";
			this.btnB.Size = new System.Drawing.Size(44, 26);
			this.btnB.TabIndex = 5;
			this.btnB.Text = "B";
			this.btnB.UseVisualStyleBackColor = false;
			this.btnB.Click += new System.EventHandler(this.btnB_Click);
			// 
			// btnC
			// 
			this.btnC.BackColor = System.Drawing.Color.DimGray;
			this.btnC.Location = new System.Drawing.Point(370, 23);
			this.btnC.Name = "btnC";
			this.btnC.Size = new System.Drawing.Size(44, 26);
			this.btnC.TabIndex = 5;
			this.btnC.Text = "C";
			this.btnC.UseVisualStyleBackColor = false;
			this.btnC.Click += new System.EventHandler(this.btnC_Click);
			// 
			// txtRX
			// 
			this.txtRX.Location = new System.Drawing.Point(12, 196);
			this.txtRX.Name = "txtRX";
			this.txtRX.Size = new System.Drawing.Size(427, 25);
			this.txtRX.TabIndex = 3;
			this.txtRX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(180, 178);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "AVR --> PC";
			// 
			// txtTX
			// 
			this.txtTX.Location = new System.Drawing.Point(12, 258);
			this.txtTX.Name = "txtTX";
			this.txtTX.Size = new System.Drawing.Size(427, 25);
			this.txtTX.TabIndex = 3;
			this.txtTX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(180, 240);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 15);
			this.label4.TabIndex = 4;
			this.label4.Text = "AVR <-- PC";
			// 
			// HMI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(451, 293);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtTX);
			this.Controls.Add(this.txtRX);
			this.Controls.Add(this.grbAVR);
			this.Controls.Add(this.grbSetting);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HMI";
			this.Text = "AVR HMI";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HMI_FormClosed);
			this.grbSetting.ResumeLayout(false);
			this.grbSetting.PerformLayout();
			this.grbAVR.ResumeLayout(false);
			this.grbAVR.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox grbSetting;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.ComboBox cboBaudRate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboPort;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grbAVR;
		private System.Windows.Forms.RadioButton rdoLED;
		private System.Windows.Forms.Button btnAVR;
		private System.Windows.Forms.Button btnC;
		private System.Windows.Forms.Button btnB;
		private System.Windows.Forms.Button btnA;
		private System.Windows.Forms.TextBox txtRX;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTX;
		private System.Windows.Forms.Label label4;
	}
}

