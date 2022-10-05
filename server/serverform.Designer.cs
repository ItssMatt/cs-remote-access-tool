
namespace server
{
	partial class serverform
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(serverform));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.server_startbtn = new System.Windows.Forms.Button();
            this.porttextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.iptextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.server_clientslabel = new System.Windows.Forms.Label();
            this.server_portlabel = new System.Windows.Forms.Label();
            this.server_iplabel = new System.Windows.Forms.Label();
            this.server_statuslabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.server_startbtn);
            this.groupBox1.Controls.Add(this.porttextbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.iptextbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Data";
            // 
            // server_startbtn
            // 
            this.server_startbtn.Location = new System.Drawing.Point(9, 90);
            this.server_startbtn.Name = "server_startbtn";
            this.server_startbtn.Size = new System.Drawing.Size(228, 23);
            this.server_startbtn.TabIndex = 4;
            this.server_startbtn.Text = "Start";
            this.server_startbtn.UseVisualStyleBackColor = true;
            this.server_startbtn.Click += new System.EventHandler(this.server_startbtn_Click);
            // 
            // porttextbox
            // 
            this.porttextbox.Location = new System.Drawing.Point(56, 64);
            this.porttextbox.Name = "porttextbox";
            this.porttextbox.Size = new System.Drawing.Size(50, 20);
            this.porttextbox.TabIndex = 3;
            this.porttextbox.Text = "6666";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // iptextbox
            // 
            this.iptextbox.Location = new System.Drawing.Point(56, 28);
            this.iptextbox.Name = "iptextbox";
            this.iptextbox.Size = new System.Drawing.Size(107, 20);
            this.iptextbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bind IP:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.server_clientslabel);
            this.groupBox2.Controls.Add(this.server_portlabel);
            this.groupBox2.Controls.Add(this.server_iplabel);
            this.groupBox2.Controls.Add(this.server_statuslabel);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 146);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Info";
            // 
            // server_clientslabel
            // 
            this.server_clientslabel.AutoSize = true;
            this.server_clientslabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server_clientslabel.Location = new System.Drawing.Point(14, 112);
            this.server_clientslabel.Name = "server_clientslabel";
            this.server_clientslabel.Size = new System.Drawing.Size(112, 15);
            this.server_clientslabel.TabIndex = 5;
            this.server_clientslabel.Text = "Clients Connected: ";
            // 
            // server_portlabel
            // 
            this.server_portlabel.AutoSize = true;
            this.server_portlabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server_portlabel.Location = new System.Drawing.Point(14, 86);
            this.server_portlabel.Name = "server_portlabel";
            this.server_portlabel.Size = new System.Drawing.Size(69, 15);
            this.server_portlabel.TabIndex = 4;
            this.server_portlabel.Text = "Server Port:";
            // 
            // server_iplabel
            // 
            this.server_iplabel.AutoSize = true;
            this.server_iplabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server_iplabel.Location = new System.Drawing.Point(14, 58);
            this.server_iplabel.Name = "server_iplabel";
            this.server_iplabel.Size = new System.Drawing.Size(61, 15);
            this.server_iplabel.TabIndex = 3;
            this.server_iplabel.Text = "Server IP: ";
            // 
            // server_statuslabel
            // 
            this.server_statuslabel.AutoSize = true;
            this.server_statuslabel.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server_statuslabel.Location = new System.Drawing.Point(14, 30);
            this.server_statuslabel.Name = "server_statuslabel";
            this.server_statuslabel.Size = new System.Drawing.Size(92, 15);
            this.server_statuslabel.TabIndex = 2;
            this.server_statuslabel.Text = "Status: Stopped";
            // 
            // serverform
            // 
            this.AcceptButton = this.server_startbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 297);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "serverform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox porttextbox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox iptextbox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button server_startbtn;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label server_statuslabel;
		private System.Windows.Forms.Label server_iplabel;
		private System.Windows.Forms.Label server_portlabel;
		private System.Windows.Forms.Label server_clientslabel;
	}
}