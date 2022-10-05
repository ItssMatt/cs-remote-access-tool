
namespace server
{
	partial class serverlog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(serverlog));
			this.serverlogtextbox = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// serverlogtextbox
			// 
			this.serverlogtextbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.serverlogtextbox.Location = new System.Drawing.Point(0, 0);
			this.serverlogtextbox.Name = "serverlogtextbox";
			this.serverlogtextbox.ReadOnly = true;
			this.serverlogtextbox.Size = new System.Drawing.Size(334, 371);
			this.serverlogtextbox.TabIndex = 0;
			this.serverlogtextbox.Text = "";
			// 
			// serverlog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 371);
			this.Controls.Add(this.serverlogtextbox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "serverlog";
			this.Text = "Server Log";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox serverlogtextbox;
	}
}