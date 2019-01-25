using System;
using System.Windows.Forms;

namespace _0125_OpenAPI
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.richTextBox1.Text = Dump.NaverOpenAPI.FindLocation(this.textBox1.Text.Trim());
		}
	}
}
