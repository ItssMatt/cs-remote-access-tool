
namespace server
{
	partial class filemanager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(filemanager));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            " .."}, 12, System.Drawing.Color.Empty, System.Drawing.Color.Empty, new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            this.hubimg = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filelistview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.directorybox = new System.Windows.Forms.TextBox();
            this.searchbutton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.searchfilebutton = new System.Windows.Forms.Button();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.howToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivescombo = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hubimg
            // 
            this.hubimg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("hubimg.ImageStream")));
            this.hubimg.TransparentColor = System.Drawing.Color.Transparent;
            this.hubimg.Images.SetKeyName(0, "server_icon.jpg");
            this.hubimg.Images.SetKeyName(1, "users_icon.png");
            this.hubimg.Images.SetKeyName(2, "folder_icon.png");
            this.hubimg.Images.SetKeyName(3, "screen_icon.png");
            this.hubimg.Images.SetKeyName(4, "network_icon.png");
            this.hubimg.Images.SetKeyName(5, "cmd_icon.png");
            this.hubimg.Images.SetKeyName(6, "surveillance_icon.png");
            this.hubimg.Images.SetKeyName(7, "romania.png");
            this.hubimg.Images.SetKeyName(8, "bitcoin_icon.png");
            this.hubimg.Images.SetKeyName(9, "c#_icon.png");
            this.hubimg.Images.SetKeyName(10, "unknown_icon.png");
            this.hubimg.Images.SetKeyName(11, "united_kingdom.png");
            this.hubimg.Images.SetKeyName(12, "folder2_icon.png");
            this.hubimg.Images.SetKeyName(13, "exe_icon.png");
            this.hubimg.Images.SetKeyName(14, "dll_icon.png");
            this.hubimg.Images.SetKeyName(15, "txt_icon.png");
            this.hubimg.Images.SetKeyName(16, "zip_icon.png");
            this.hubimg.Images.SetKeyName(17, "doc_icon.png");
            this.hubimg.Images.SetKeyName(18, "pdf_icon.png");
            this.hubimg.Images.SetKeyName(19, "blank_icon.png");
            this.hubimg.Images.SetKeyName(20, "torrent_icon.png");
            this.hubimg.Images.SetKeyName(21, "image_icon.png");
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadtoolStripMenuItem,
            this.deleteStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(129, 48);
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip2_ItemClicked);
            // 
            // downloadtoolStripMenuItem
            // 
            this.downloadtoolStripMenuItem.Image = global::server.Properties.Resources.download_icon;
            this.downloadtoolStripMenuItem.Name = "downloadtoolStripMenuItem";
            this.downloadtoolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.downloadtoolStripMenuItem.Text = "Download";
            // 
            // deleteStripMenuItem
            // 
            this.deleteStripMenuItem.Image = global::server.Properties.Resources.delete_icon;
            this.deleteStripMenuItem.Name = "deleteStripMenuItem";
            this.deleteStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.deleteStripMenuItem.Text = "Delete";
            // 
            // filelistview
            // 
            this.filelistview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.filelistview.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.filelistview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filelistview.FullRowSelect = true;
            this.filelistview.GridLines = true;
            this.filelistview.HideSelection = false;
            this.filelistview.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.filelistview.Location = new System.Drawing.Point(0, 87);
            this.filelistview.MultiSelect = false;
            this.filelistview.Name = "filelistview";
            this.filelistview.Size = new System.Drawing.Size(811, 382);
            this.filelistview.SmallImageList = this.hubimg;
            this.filelistview.TabIndex = 13;
            this.filelistview.UseCompatibleStateImageBehavior = false;
            this.filelistview.View = System.Windows.Forms.View.Details;
            this.filelistview.DoubleClick += new System.EventHandler(this.filelistview_DoubleClick);
            this.filelistview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.filelistview_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 661;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 144;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drivescombo);
            this.groupBox1.Controls.Add(this.directorybox);
            this.groupBox1.Controls.Add(this.searchbutton);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 44);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Directory";
            // 
            // directorybox
            // 
            this.directorybox.Location = new System.Drawing.Point(133, 18);
            this.directorybox.Name = "directorybox";
            this.directorybox.Size = new System.Drawing.Size(376, 20);
            this.directorybox.TabIndex = 0;
            this.directorybox.Text = "C:\\";
            // 
            // searchbutton
            // 
            this.searchbutton.Location = new System.Drawing.Point(515, 14);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(72, 26);
            this.searchbutton.TabIndex = 16;
            this.searchbutton.Text = "Search";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.searchfilebutton);
            this.groupBox2.Controls.Add(this.searchbox);
            this.groupBox2.Location = new System.Drawing.Point(611, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 44);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search File";
            // 
            // searchfilebutton
            // 
            this.searchfilebutton.Location = new System.Drawing.Point(110, 14);
            this.searchfilebutton.Name = "searchfilebutton";
            this.searchfilebutton.Size = new System.Drawing.Size(72, 26);
            this.searchfilebutton.TabIndex = 17;
            this.searchfilebutton.Text = "Search";
            this.searchfilebutton.UseVisualStyleBackColor = true;
            this.searchfilebutton.Click += new System.EventHandler(this.searchfilebutton_Click);
            // 
            // searchbox
            // 
            this.searchbox.Location = new System.Drawing.Point(6, 18);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(98, 20);
            this.searchbox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(811, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // howToToolStripMenuItem
            // 
            this.howToToolStripMenuItem.Name = "howToToolStripMenuItem";
            this.howToToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.howToToolStripMenuItem.Text = "How To";
            this.howToToolStripMenuItem.Click += new System.EventHandler(this.howToToolStripMenuItem_Click);
            // 
            // drivescombo
            // 
            this.drivescombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drivescombo.FormattingEnabled = true;
            this.drivescombo.Location = new System.Drawing.Point(6, 17);
            this.drivescombo.Name = "drivescombo";
            this.drivescombo.Size = new System.Drawing.Size(121, 21);
            this.drivescombo.TabIndex = 17;
            this.drivescombo.SelectedIndexChanged += new System.EventHandler(this.drivescombo_SelectedIndexChanged);
            // 
            // filemanager
            // 
            this.AcceptButton = this.searchbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 469);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.filelistview);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "filemanager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Manager";
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ImageList hubimg;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.ToolStripMenuItem downloadtoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button searchfilebutton;
		private System.Windows.Forms.TextBox searchbox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox directorybox;
		private System.Windows.Forms.Button searchbutton;
		private System.Windows.Forms.ListView filelistview;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem howToToolStripMenuItem;
        private System.Windows.Forms.ComboBox drivescombo;
    }
}