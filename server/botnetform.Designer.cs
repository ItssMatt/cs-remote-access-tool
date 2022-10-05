
namespace server
{
	partial class botnetform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(botnetform));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statuslabel = new System.Windows.Forms.Label();
            this.actionbtn = new System.Windows.Forms.Button();
            this.allbox = new System.Windows.Forms.CheckBox();
            this.portbox = new System.Windows.Forms.TextBox();
            this.ipbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.howToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemlabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statuslabel);
            this.groupBox1.Controls.Add(this.actionbtn);
            this.groupBox1.Controls.Add(this.allbox);
            this.groupBox1.Controls.Add(this.portbox);
            this.groupBox1.Controls.Add(this.ipbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target";
            // 
            // statuslabel
            // 
            this.statuslabel.AutoSize = true;
            this.statuslabel.Location = new System.Drawing.Point(284, 77);
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(81, 13);
            this.statuslabel.TabIndex = 6;
            this.statuslabel.Text = "Status: Inactive";
            // 
            // actionbtn
            // 
            this.actionbtn.Location = new System.Drawing.Point(219, 38);
            this.actionbtn.Name = "actionbtn";
            this.actionbtn.Size = new System.Drawing.Size(86, 28);
            this.actionbtn.TabIndex = 5;
            this.actionbtn.Text = "Start";
            this.actionbtn.UseVisualStyleBackColor = true;
            this.actionbtn.Click += new System.EventHandler(this.actionbtn_Click);
            // 
            // allbox
            // 
            this.allbox.AutoSize = true;
            this.allbox.Location = new System.Drawing.Point(19, 76);
            this.allbox.Name = "allbox";
            this.allbox.Size = new System.Drawing.Size(124, 17);
            this.allbox.TabIndex = 4;
            this.allbox.Text = "attack with all clients";
            this.allbox.UseVisualStyleBackColor = true;
            // 
            // portbox
            // 
            this.portbox.Location = new System.Drawing.Point(45, 50);
            this.portbox.Name = "portbox";
            this.portbox.Size = new System.Drawing.Size(65, 20);
            this.portbox.TabIndex = 3;
            this.portbox.Text = "80";
            // 
            // ipbox
            // 
            this.ipbox.Location = new System.Drawing.Point(45, 23);
            this.ipbox.Name = "ipbox";
            this.ipbox.Size = new System.Drawing.Size(122, 20);
            this.ipbox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(395, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // howToToolStripMenuItem
            // 
            this.howToToolStripMenuItem.Name = "howToToolStripMenuItem";
            this.howToToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.howToToolStripMenuItem.Text = "How To";
            this.howToToolStripMenuItem.Click += new System.EventHandler(this.howToToolStripMenuItem_Click);
            // 
            // systemlabel
            // 
            this.systemlabel.AutoSize = true;
            this.systemlabel.Location = new System.Drawing.Point(12, 34);
            this.systemlabel.Name = "systemlabel";
            this.systemlabel.Size = new System.Drawing.Size(66, 13);
            this.systemlabel.TabIndex = 6;
            this.systemlabel.Text = "Environment";
            // 
            // botnetform
            // 
            this.AcceptButton = this.actionbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 162);
            this.Controls.Add(this.systemlabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "botnetform";
            this.Text = "(D)DOS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem howToToolStripMenuItem;
        private System.Windows.Forms.Button actionbtn;
        private System.Windows.Forms.CheckBox allbox;
        private System.Windows.Forms.TextBox portbox;
        private System.Windows.Forms.TextBox ipbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statuslabel;
        private System.Windows.Forms.Label systemlabel;
    }
}