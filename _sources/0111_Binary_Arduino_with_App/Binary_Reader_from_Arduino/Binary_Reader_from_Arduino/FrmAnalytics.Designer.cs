namespace Binary_Reader_from_Arduino
{
	partial class FrmAnalytics
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btnParsing = new System.Windows.Forms.Button();
			this.BtnRead = new System.Windows.Forms.Button();
			this.rtxtSerialRead = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btnParsing);
			this.splitContainer1.Panel1.Controls.Add(this.BtnRead);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.rtxtSerialRead);
			this.splitContainer1.Size = new System.Drawing.Size(960, 588);
			this.splitContainer1.SplitterDistance = 197;
			this.splitContainer1.TabIndex = 1;
			// 
			// btnParsing
			// 
			this.btnParsing.Enabled = false;
			this.btnParsing.Location = new System.Drawing.Point(12, 66);
			this.btnParsing.Name = "btnParsing";
			this.btnParsing.Size = new System.Drawing.Size(164, 48);
			this.btnParsing.TabIndex = 0;
			this.btnParsing.Text = "파싱모드 실행";
			this.btnParsing.UseVisualStyleBackColor = true;
			// 
			// BtnRead
			// 
			this.BtnRead.Location = new System.Drawing.Point(12, 12);
			this.BtnRead.Name = "BtnRead";
			this.BtnRead.Size = new System.Drawing.Size(164, 48);
			this.BtnRead.TabIndex = 0;
			this.BtnRead.Text = "COM7 포트 바이너리 읽기";
			this.BtnRead.UseVisualStyleBackColor = true;
			this.BtnRead.Click += new System.EventHandler(this.BtnRead_Click);
			// 
			// rtxtSerialRead
			// 
			this.rtxtSerialRead.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtxtSerialRead.Location = new System.Drawing.Point(0, 0);
			this.rtxtSerialRead.Name = "rtxtSerialRead";
			this.rtxtSerialRead.Size = new System.Drawing.Size(759, 588);
			this.rtxtSerialRead.TabIndex = 2;
			this.rtxtSerialRead.Text = "";
			// 
			// FrmAnalytics
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(960, 588);
			this.Controls.Add(this.splitContainer1);
			this.Name = "FrmAnalytics";
			this.Text = "아두이노와 바이너리 통신";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button btnParsing;
		private System.Windows.Forms.Button BtnRead;
		private System.Windows.Forms.RichTextBox rtxtSerialRead;
	}
}

