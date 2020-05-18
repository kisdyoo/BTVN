using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace GameCaro_CT3
{
	public partial class Form1 : Form
	{
		bool luotchoi = true;
		int n;
		Button btnBatDau = new Button();
		TextBox txtinput = new TextBox();
		int [,] vitri;

		public Form1()
		{

			InitializeComponent();
			this.Size = new Size(800, 500);
			input();
		}
		public void input()
		{
			Panel pn_input = new Panel();
			pn_input.Size = new Size(300, 500);
			pn_input.Dock = DockStyle.Right;

			Label lblten = new Label();
			lblten.Size = new Size(250, 20);
			lblten.Text = "CỜ CARO";
			lblten.Location = new Point(130, 50);
			lblten.Font = new Font("Arial", 13, FontStyle.Bold);
			lblten.ForeColor = Color.Red;

			Label lbl = new Label();
			lbl.Size = new Size(250, 20);
			lbl.Text = "Nhập số dòng và cột cho bàn cờ: ";
			lbl.Location = new Point(100, 100);
			lbl.Font = new Font("Arial", 9, FontStyle.Regular);

			txtinput.Size = new Size(100, 30);
			txtinput.Top = 120;
			txtinput.Left = 130;

			btnBatDau.Text = "Bắt đầu";
			btnBatDau.Size = new Size(100, 30);
			btnBatDau.Top = 150;
			btnBatDau.Left = 130;
			btnBatDau.Click += new System.EventHandler(bt_ClickBD);


			pn_input.Controls.Add(lbl);
			pn_input.Controls.Add(lblten);
			pn_input.Controls.Add(txtinput);
			pn_input.Controls.Add(btnBatDau);
			pn_input.Show();
			txtinput.Focus();
			this.Controls.Add(pn_input);
		}

		private void bt_ClickBD(object sender, EventArgs e)
		{
			n = Int16.Parse(txtinput.Text.ToString());

			vitri = new int[n, n];
			for (int i = 0; i < n * 30; i += 30)
			{
				for (int j = 0; j < n * 30; j += 30)
				{
					Button btn = new Button();
					btn.Size = new Size(30, 30);
					btn.Name = "btn" + i.ToString() + j.ToString();
					btn.Top = i;
					btn.Left = j;
					btn.Font = new Font("Arial", 13, FontStyle.Bold);
					btn.Click += new System.EventHandler(bt_Click);
					btn.Tag = -1;
					vitri[i, j] = Int16.Parse(btn.Tag.ToString());

					this.Controls.Add(btn);
				}
			}
		}


		public void Ktra_o(){
			int count_o = 0;
			for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if(vitri[i,j] == 0)
					count_o++;
				}

			}
			MessageBox.Show(count_o.ToString());

		
		}
		private void bt_Click(object sender, EventArgs e)
		{

			Button btn = (Button) sender;

			if (Int16.Parse(btn.Tag.ToString()) == -1)
			{
				if (luotchoi == true)
				{
					btn.Tag = 0;
					btn.Text = "o";
					luotchoi = false;
					vitri[btn.Top / 30, btn.Left / 30] = Int16.Parse(btn.Tag.ToString());
				}
				else
				{
					btn.Tag = 1;
					btn.Text = "x";
					luotchoi = true;
					vitri[btn.Top / 30, btn.Left / 30] = Int16.Parse(btn.Tag.ToString());
				}
				Ktra_o();
			}
		}

	}
}
