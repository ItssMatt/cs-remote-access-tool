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
	public partial class showmessagebox : Form
	{
		public static showmessagebox instance;
		public Form1.Client selected_client;
		public showmessagebox()
		{
			InitializeComponent();
			instance = this;
		}

		public showmessagebox(Form1.Client cli)
		{
			InitializeComponent();
			instance = this;
			selected_client = cli;
			systemlabel.Text = "Environment: " + selected_client.environment + " [" +
				selected_client.IP + ":" + selected_client.port.ToString() + "]";
		}

		private void sendbtn_Click(object sender, EventArgs e)
		{
			serverlog.instance.log(string.Format("MessageBox (title: {0} | message: {1}) sent to {2} [{3}:{4}].\n",
				titlebox.Text, messagebox.Text, selected_client.environment, selected_client.IP,
				selected_client.port.ToString()));
			Form1.instance.server.BroadcastLine(
				Form1.instance.encryptus("[****]" + selected_client.IP + ":" +
				selected_client.port.ToString() + "[****]" + titlebox.Text+ " [****]" + messagebox.Text+ " ", "D4MVCINM42XS"));
			titlebox.Text = string.Empty;
			messagebox.Text = string.Empty;
		}

		private void howToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"First box: Title of the message box.\n" +
				"Second box: The string of the message you want to show in the message box.\n" +
				"(!) The messagebox's type will be Error.\n" +
				"Always use the Server Log to keep track of your activities.", "How To", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
