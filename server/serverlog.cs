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
	public partial class serverlog : Form
	{
		public static serverlog instance;
		public serverlog()
		{
			InitializeComponent();
			instance = this;
		}

		public void log(string message)
		{
			if(!serverlogtextbox.IsDisposed)
				serverlogtextbox.AppendText(message);
		}
	}
}
