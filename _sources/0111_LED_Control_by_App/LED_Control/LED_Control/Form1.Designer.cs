namespace LED_Control
{
	partial class Form1
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
			this.btnLEDControl = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.btnServoLeft = new System.Windows.Forms.Button();
			this.btnServoRight = new System.Windows.Forms.Button();
			this.grpServo = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.grpServo.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnLEDControl
			// 
			this.btnLEDControl.Enabled = false;
			this.btnLEDControl.Location = new System.Drawing.Point(12, 52);
			this.btnLEDControl.Name = "btnLEDControl";
			this.btnLEDControl.Size = new System.Drawing.Size(295, 43);
			this.btnLEDControl.TabIndex = 0;
			this.btnLEDControl.Text = "LED 켜기";
			this.btnLEDControl.UseVisualStyleBackColor = true;
			this.btnLEDControl.Click += new System.EventHandler(this.btnLEDControl_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(12, 12);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(295, 34);
			this.btnConnect.TabIndex = 1;
			this.btnConnect.Text = "아두이노 연결";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// trackBar1
			// 
			this.trackBar1.Enabled = false;
			this.trackBar1.LargeChange = 10;
			this.trackBar1.Location = new System.Drawing.Point(3, 21);
			this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
			this.trackBar1.Maximum = 180;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(287, 56);
			this.trackBar1.SmallChange = 10;
			this.trackBar1.TabIndex = 2;
			this.trackBar1.TickFrequency = 10;
			this.trackBar1.Value = 90;
			// 
			// btnServoLeft
			// 
			this.btnServoLeft.Location = new System.Drawing.Point(23, 80);
			this.btnServoLeft.Name = "btnServoLeft";
			this.btnServoLeft.Size = new System.Drawing.Size(100, 50);
			this.btnServoLeft.TabIndex = 4;
			this.btnServoLeft.Text = "좌";
			this.btnServoLeft.UseVisualStyleBackColor = true;
			this.btnServoLeft.Click += new System.EventHandler(this.btnServoLeft_Click);
			// 
			// btnServoRight
			// 
			this.btnServoRight.Location = new System.Drawing.Point(168, 80);
			this.btnServoRight.Name = "btnServoRight";
			this.btnServoRight.Size = new System.Drawing.Size(100, 50);
			this.btnServoRight.TabIndex = 4;
			this.btnServoRight.Text = "우";
			this.btnServoRight.UseVisualStyleBackColor = true;
			this.btnServoRight.Click += new System.EventHandler(this.btnServoRight_Click);
			// 
			// grpServo
			// 
			this.grpServo.Controls.Add(this.trackBar1);
			this.grpServo.Controls.Add(this.btnServoRight);
			this.grpServo.Controls.Add(this.btnServoLeft);
			this.grpServo.Enabled = false;
			this.grpServo.Location = new System.Drawing.Point(12, 101);
			this.grpServo.Name = "grpServo";
			this.grpServo.Size = new System.Drawing.Size(295, 147);
			this.grpServo.TabIndex = 5;
			this.grpServo.TabStop = false;
			this.grpServo.Text = "서보모터 제어";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(319, 267);
			this.Controls.Add(this.grpServo);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.btnLEDControl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "아두이노 제어";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.grpServo.ResumeLayout(false);
			this.grpServo.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnLEDControl;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Button btnServoLeft;
		private System.Windows.Forms.Button btnServoRight;
		private System.Windows.Forms.GroupBox grpServo;
	}
}

