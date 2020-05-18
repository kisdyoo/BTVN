using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemoveTextDeQuy
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			XoaControlTextBox(this);
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		public void XoaControlTextBox(Control ctrl)
		{
			foreach (Control item in ctrl.Controls.OfType<Panel>())
			{
				if (item.Controls.Count == 0)
					break;
				foreach (Control txtbox in item.Controls.OfType<TextBox>())
				{
					txtbox.Text = string.Empty;
				}
				XoaControlTextBox(item);
			}
		}
	}
}

