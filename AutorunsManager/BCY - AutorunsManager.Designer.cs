namespace AutorunsManager
{
    partial class AutorunsManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutorunsManager));
            this.treeViewImage = new System.Windows.Forms.TreeView();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Refresh_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.image_jumpToImage_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.image_jumToRegistry_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.image_properties_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view_smallIcons_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view_list_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view_details_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.system_shutDown_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.system_Sleep_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.system_reboot_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.system_logOff_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_content_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_about_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.jumpToImageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpToRegistryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesAltEnterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelToolBar = new System.Windows.Forms.Panel();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnContent = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnProperties = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.labelStatus = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstViewImage = new System.Windows.Forms.ListView();
            this.mainMenu.SuspendLayout();
            this.SubMenu.SuspendLayout();
            this.panelToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewImage
            // 
            this.treeViewImage.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeViewImage.HideSelection = false;
            this.treeViewImage.Location = new System.Drawing.Point(12, 80);
            this.treeViewImage.Name = "treeViewImage";
            this.treeViewImage.Size = new System.Drawing.Size(176, 345);
            this.treeViewImage.TabIndex = 0;
            this.treeViewImage.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeViewImage_DrawNode);
            this.treeViewImage.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewImage_AfterSelect);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(795, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.regEditToolStripMenuItem,
            this.Refresh_toolStripMenuItem,
            this.toolStripSeparator1,
            this.Exit_ToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // regEditToolStripMenuItem
            // 
            this.regEditToolStripMenuItem.Name = "regEditToolStripMenuItem";
            this.regEditToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.regEditToolStripMenuItem.Text = "RegEdit";
            this.regEditToolStripMenuItem.Click += new System.EventHandler(this.regEditToolStripMenuItem_Click);
            // 
            // Refresh_toolStripMenuItem
            // 
            this.Refresh_toolStripMenuItem.Name = "Refresh_toolStripMenuItem";
            this.Refresh_toolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.Refresh_toolStripMenuItem.Text = "Refresh";
            this.Refresh_toolStripMenuItem.Click += new System.EventHandler(this.Refresh_toolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(122, 6);
            // 
            // Exit_ToolStripMenuItem
            // 
            this.Exit_ToolStripMenuItem.Name = "Exit_ToolStripMenuItem";
            this.Exit_ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.Exit_ToolStripMenuItem.Text = "Exit";
            this.Exit_ToolStripMenuItem.Click += new System.EventHandler(this.Exit_ToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.image_jumpToImage_ToolStripMenuItem,
            this.image_jumToRegistry_ToolStripMenuItem,
            this.image_properties_ToolStripMenuItem});
            this.imageToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // image_jumpToImage_ToolStripMenuItem
            // 
            this.image_jumpToImage_ToolStripMenuItem.Name = "image_jumpToImage_ToolStripMenuItem";
            this.image_jumpToImage_ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.image_jumpToImage_ToolStripMenuItem.Text = "Jump to Image";
            this.image_jumpToImage_ToolStripMenuItem.Click += new System.EventHandler(this.image_jumpToImage_ToolStripMenuItem_Click);
            // 
            // image_jumToRegistry_ToolStripMenuItem
            // 
            this.image_jumToRegistry_ToolStripMenuItem.Name = "image_jumToRegistry_ToolStripMenuItem";
            this.image_jumToRegistry_ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.image_jumToRegistry_ToolStripMenuItem.Text = "Jum to Registry";
            this.image_jumToRegistry_ToolStripMenuItem.Click += new System.EventHandler(this.image_jumToRegistry_ToolStripMenuItem_Click);
            // 
            // image_properties_ToolStripMenuItem
            // 
            this.image_properties_ToolStripMenuItem.Name = "image_properties_ToolStripMenuItem";
            this.image_properties_ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.image_properties_ToolStripMenuItem.Text = "Properties  ";
            this.image_properties_ToolStripMenuItem.Click += new System.EventHandler(this.image_properties_ToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.view_smallIcons_ToolStripMenuItem,
            this.view_list_ToolStripMenuItem,
            this.view_details_ToolStripMenuItem});
            this.viewToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // view_smallIcons_ToolStripMenuItem
            // 
            this.view_smallIcons_ToolStripMenuItem.Name = "view_smallIcons_ToolStripMenuItem";
            this.view_smallIcons_ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.view_smallIcons_ToolStripMenuItem.Text = "Icons";
            this.view_smallIcons_ToolStripMenuItem.Click += new System.EventHandler(this.view_smallIcons_ToolStripMenuItem_Click);
            // 
            // view_list_ToolStripMenuItem
            // 
            this.view_list_ToolStripMenuItem.Name = "view_list_ToolStripMenuItem";
            this.view_list_ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.view_list_ToolStripMenuItem.Text = "List";
            this.view_list_ToolStripMenuItem.Click += new System.EventHandler(this.view_list_ToolStripMenuItem_Click);
            // 
            // view_details_ToolStripMenuItem
            // 
            this.view_details_ToolStripMenuItem.Name = "view_details_ToolStripMenuItem";
            this.view_details_ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.view_details_ToolStripMenuItem.Text = "Details";
            this.view_details_ToolStripMenuItem.Click += new System.EventHandler(this.view_details_ToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.system_shutDown_ToolStripMenuItem,
            this.system_Sleep_ToolStripMenuItem,
            this.system_reboot_ToolStripMenuItem,
            this.system_logOff_ToolStripMenuItem});
            this.systemToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // system_shutDown_ToolStripMenuItem
            // 
            this.system_shutDown_ToolStripMenuItem.Name = "system_shutDown_ToolStripMenuItem";
            this.system_shutDown_ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.system_shutDown_ToolStripMenuItem.Text = "ShutDown";
            this.system_shutDown_ToolStripMenuItem.Click += new System.EventHandler(this.system_shutDown_ToolStripMenuItem_Click);
            // 
            // system_Sleep_ToolStripMenuItem
            // 
            this.system_Sleep_ToolStripMenuItem.Name = "system_Sleep_ToolStripMenuItem";
            this.system_Sleep_ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.system_Sleep_ToolStripMenuItem.Text = "Sleep";
            this.system_Sleep_ToolStripMenuItem.Click += new System.EventHandler(this.system_Sleep_ToolStripMenuItem_Click);
            // 
            // system_reboot_ToolStripMenuItem
            // 
            this.system_reboot_ToolStripMenuItem.Name = "system_reboot_ToolStripMenuItem";
            this.system_reboot_ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.system_reboot_ToolStripMenuItem.Text = "Reboot";
            this.system_reboot_ToolStripMenuItem.Click += new System.EventHandler(this.system_reboot_ToolStripMenuItem_Click);
            // 
            // system_logOff_ToolStripMenuItem
            // 
            this.system_logOff_ToolStripMenuItem.Name = "system_logOff_ToolStripMenuItem";
            this.system_logOff_ToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.system_logOff_ToolStripMenuItem.Text = "LogOff";
            this.system_logOff_ToolStripMenuItem.Click += new System.EventHandler(this.system_logOff_ToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help_content_ToolStripMenuItem,
            this.Help_about_ToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // Help_content_ToolStripMenuItem
            // 
            this.Help_content_ToolStripMenuItem.Name = "Help_content_ToolStripMenuItem";
            this.Help_content_ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.Help_content_ToolStripMenuItem.Text = "Content";
            this.Help_content_ToolStripMenuItem.Click += new System.EventHandler(this.Help_content_ToolStripMenuItem_Click);
            // 
            // Help_about_ToolStripMenuItem
            // 
            this.Help_about_ToolStripMenuItem.Name = "Help_about_ToolStripMenuItem";
            this.Help_about_ToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.Help_about_ToolStripMenuItem.Text = "About";
            this.Help_about_ToolStripMenuItem.Click += new System.EventHandler(this.Help_about_ToolStripMenuItem_Click);
            // 
            // SubMenu
            // 
            this.SubMenu.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SubMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jumpToImageToolStripMenuItem1,
            this.jumpToRegistryToolStripMenuItem,
            this.propertiesAltEnterToolStripMenuItem1});
            this.SubMenu.Name = "SubMenu";
            this.SubMenu.Size = new System.Drawing.Size(187, 70);
            // 
            // jumpToImageToolStripMenuItem1
            // 
            this.jumpToImageToolStripMenuItem1.Name = "jumpToImageToolStripMenuItem1";
            this.jumpToImageToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.jumpToImageToolStripMenuItem1.Text = "Jump to Image";
            this.jumpToImageToolStripMenuItem1.Click += new System.EventHandler(this.jumpToImageToolStripMenuItem1_Click);
            // 
            // jumpToRegistryToolStripMenuItem
            // 
            this.jumpToRegistryToolStripMenuItem.Name = "jumpToRegistryToolStripMenuItem";
            this.jumpToRegistryToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.jumpToRegistryToolStripMenuItem.Text = "Jump to Registry";
            this.jumpToRegistryToolStripMenuItem.Click += new System.EventHandler(this.jumpToRegistryToolStripMenuItem_Click);
            // 
            // propertiesAltEnterToolStripMenuItem1
            // 
            this.propertiesAltEnterToolStripMenuItem1.Name = "propertiesAltEnterToolStripMenuItem1";
            this.propertiesAltEnterToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.propertiesAltEnterToolStripMenuItem1.Text = "Properties";
            this.propertiesAltEnterToolStripMenuItem1.Click += new System.EventHandler(this.propertiesAltEnterToolStripMenuItem1_Click);
            // 
            // panelToolBar
            // 
            this.panelToolBar.BackColor = System.Drawing.SystemColors.Control;
            this.panelToolBar.Controls.Add(this.btnAbout);
            this.panelToolBar.Controls.Add(this.btnContent);
            this.panelToolBar.Controls.Add(this.btnRefresh);
            this.panelToolBar.Controls.Add(this.btnProperties);
            this.panelToolBar.Controls.Add(this.btnRun);
            this.panelToolBar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panelToolBar.Location = new System.Drawing.Point(12, 27);
            this.panelToolBar.Name = "panelToolBar";
            this.panelToolBar.Size = new System.Drawing.Size(380, 47);
            this.panelToolBar.TabIndex = 5;
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAbout.Location = new System.Drawing.Point(302, 3);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(73, 41);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnContent
            // 
            this.btnContent.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnContent.Location = new System.Drawing.Point(228, 3);
            this.btnContent.Name = "btnContent";
            this.btnContent.Size = new System.Drawing.Size(73, 41);
            this.btnContent.TabIndex = 4;
            this.btnContent.Text = "Content";
            this.btnContent.UseVisualStyleBackColor = true;
            this.btnContent.Click += new System.EventHandler(this.btnContent_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRefresh.Location = new System.Drawing.Point(154, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(73, 41);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnProperties
            // 
            this.btnProperties.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProperties.Location = new System.Drawing.Point(79, 3);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(73, 41);
            this.btnProperties.TabIndex = 2;
            this.btnProperties.Text = "Properties";
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(4, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(73, 41);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelStatus.Location = new System.Drawing.Point(12, 429);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(57, 19);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Status : ";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Image";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Section";
            this.columnHeader2.Width = 91;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 118;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Publisher";
            this.columnHeader4.Width = 109;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ImagePath";
            this.columnHeader5.Width = 189;
            // 
            // lstViewImage
            // 
            this.lstViewImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstViewImage.GridLines = true;
            this.lstViewImage.Location = new System.Drawing.Point(193, 80);
            this.lstViewImage.Name = "lstViewImage";
            this.lstViewImage.Size = new System.Drawing.Size(593, 345);
            this.lstViewImage.TabIndex = 1;
            this.lstViewImage.UseCompatibleStateImageBehavior = false;
            this.lstViewImage.View = System.Windows.Forms.View.Details;
            this.lstViewImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstViewImage_MouseClick);
            // 
            // AutorunsManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(795, 453);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.panelToolBar);
            this.Controls.Add(this.lstViewImage);
            this.Controls.Add(this.treeViewImage);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "AutorunsManager";
            this.Text = "BCY - Autoruns Manager Portable";
            this.Load += new System.EventHandler(this.AutorunsManager_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.SubMenu.ResumeLayout(false);
            this.panelToolBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewImage;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regEditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem image_jumpToImage_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem image_jumToRegistry_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem image_properties_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem view_smallIcons_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem view_list_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem view_details_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem system_shutDown_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem system_Sleep_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem system_reboot_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem system_logOff_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Help_content_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Help_about_ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip SubMenu;
        private System.Windows.Forms.ToolStripMenuItem jumpToImageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem jumpToRegistryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesAltEnterToolStripMenuItem1;
        private System.Windows.Forms.Panel panelToolBar;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnContent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lstViewImage;
        private System.Windows.Forms.ToolStripMenuItem Refresh_toolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;        
    }
}

