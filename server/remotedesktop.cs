using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class remotedesktop : Form
    {
        public static remotedesktop instance;
        public Form1.Client selected_client;
        public Thread thrd;
        bool closed = false;

        PictureBox screen_picturebox = new PictureBox
        {
            Name = "pictureBox",
            Size = new Size(1280, 720),
            Location = new Point(14, 17),
            Visible = true,
            Dock = DockStyle.Fill,
            SizeMode = PictureBoxSizeMode.StretchImage
        };

        public remotedesktop()
        {
            InitializeComponent();
            instance = this;
        }

        public remotedesktop(Form1.Client cli)
        {
            instance = this;
            selected_client = cli;
            closed = false;
            this.Text = "Remote Desktop - Environment: " + selected_client.environment + " [" +
                selected_client.IP + ":" + selected_client.port.ToString() + "]";

            this.Controls.Add(screen_picturebox);

            thrd = new Thread(new ThreadStart(Threadd));
            thrd.IsBackground = true;
            thrd.Start();
        }

        private void Threadd()
        {
            MessageBox.Show("Entered Thread");
            while (!this.IsDisposed)
            {
                if (!screen_picturebox.Enabled) continue;
                screen_picturebox.Invoke((MethodInvoker)delegate ()
                {
                    screen_picturebox.Size = new Size(selected_client.screenshot_desktop.Width, selected_client.screenshot_desktop.Height);
                    screen_picturebox.Image = selected_client.screenshot_desktop;
                });
                Thread.Sleep(2000);
            }
            closed = false;
        }

        private void remotedesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            closed = true;
            thrd.Abort();
        }
    }
}
