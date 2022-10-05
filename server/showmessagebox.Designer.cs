
namespace server
{
	partial class showmessagebox
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(showmessagebox));
			this.titlebox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.messagebox = new System.Windows.Forms.RichTextBox();
			this.sendbtn = new System.Windows.Forms.Button();
			this.systemlabel = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.howToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// titlebox
			// 
			this.titlebox.Location = new System.Drawing.Point(48, 53);
			this.titlebox.Name = "titlebox";
			this.titlebox.Size = new System.Drawing.Size(234, 20);
			this.titlebox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Title:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Message:";
			// 
			// messagebox
			// 
			this.messagebox.Location = new System.Drawing.Point(14, 94);
			this.messagebox.Name = "messagebox";
			this.messagebox.Size = new System.Drawing.Size(268, 142);
			this.messagebox.TabIndex = 3;
			this.messagebox.Text = "";
			// 
			// sendbtn
			// 
			this.sendbtn.Location = new System.Drawing.Point(15, 242);
			this.sendbtn.Name = "sendbtn";
			this.sendbtn.Size = new System.Drawing.Size(267, 23);
			this.sendbtn.TabIndex = 4;
			this.sendbtn.Text = "Send";
			this.sendbtn.UseVisualStyleBackColor = true;
			this.sendbtn.Click += new System.EventHandler(this.sendbtn_Click);
			// 
			// systemlabel
			// 
			this.systemlabel.AutoSize = true;
			this.systemlabel.Location = new System.Drawing.Point(11, 28);
			this.systemlabel.Name = "systemlabel";
			this.systemlabel.Size = new System.Drawing.Size(66, 13);
			this.systemlabel.TabIndex = 5;
			this.systemlabel.Text = "Environment";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(294, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// howToToolStripMenuItem
			// 
			this.howToToolStripMenuItem.Name = "howToToolStripMenuItem";
			this.howToToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.howToToolStripMenuItem.Text = "How To";
			this.howToToolStripMenuItem.Click += new System.EventHandler(this.howToToolStripMenuItem_Click);
			// 
			// showmessagebox
			// 
			this.AcceptButton = this.sendbtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(294, 277);
			this.Controls.Add(this.systemlabel);
			this.Controls.Add(this.sendbtn);
			this.Controls.Add(this.messagebox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.titlebox);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "showmessagebox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Show MessageBox";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox titlebox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox messagebox;
		private System.Windows.Forms.Button sendbtn;
		private System.Windows.Forms.Label systemlabel;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem howToToolStripMenuItem;
	}
}