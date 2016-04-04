using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using AutorunsManager.Main;
using ImageInformation;
using System.Threading;

namespace AutorunsManager
{
    public partial class AutorunsManager : Form
    {
        #region PARAMS
        #region Registry params
        //HKCU Run
        private List<ImageInfo> lst_HKCU_Run;
        private ImageList lstImg_HKCU_Run;
        //HKCU RunOnce
        private List<ImageInfo> lst_HKCU_RunOnce ;
        private ImageList lstImg_HKCU_RunOnce ;
        //HKLM Run32
        private List<ImageInfo> lst_HKLM_Run32 ;
        private ImageList lstImg_HKLM_Run32 ;
        //HKLM Run64
        private List<ImageInfo> lst_HKLM_Run64 ;
        private ImageList lstImg_HKLM_Run64 ;
        //HKLM RunOnce32
        private List<ImageInfo> lst_HKLM_RunOnce32 ;
        private ImageList lstImg_HKLM_RunOnce32 ;
        //HKLM RunOnce64
        private List<ImageInfo> lst_HKLM_RunOnce64 ;
        private ImageList lstImg_HKLM_RunOnce64 ;
        //HKLM Services
        private List<ImageInfo> lst_HKLM_Serv ;
        private ImageList lstImg_HKLM_Serv;
        //HKCR DLL
        private List<ImageInfo> lst_HKCR_DLLs ;
        private ImageList lstImg_HKCR_DLLs ;
        #endregion
     
        #region ListView params
        //Load data to lstView
        public static List<ImageInfo> lst_everything ;
        public static ImageList lstImg_everything ;
        private List<ImageInfo> lst_registry ;
        private ImageList lstImg_registry ;
        private List<ImageInfo> lst_cu ;
        private ImageList lstImg_cu ;
        private List<ImageInfo> lst_au;
        private ImageList lstImg_au ;
        #endregion
       
        #region Public params
        public static string selectedFile;
        public static string baseRegkey;    //HKLM | HKCU | HKCR
        public static string full_regKey; // regKey value to Jump to;
        public static string typeOS;    // 32bit | 64bit
        public static List<string> invalidImages ;
        #endregion

        //check if Scan is finished
        private bool checkScan;

        //check if Scanning process is terminated by pressing ESC
        public static bool Terminate;
        KeyboardHook hook ;
        #endregion

        #region CONSTRUCTORS
        public AutorunsManager()
        {
            InitializeComponent();
            this.Init_Params();
        }
        #endregion

        #region GUI EVENTS
        private void AutorunsManager_Load(object sender, EventArgs e)
        {
            #region GUI setting
            this.lstViewImage.View = View.Details;
            this.lstViewImage.FullRowSelect = true;           
            this.view_details_ToolStripMenuItem.Checked = true;
            this.lstViewImage.View = View.Details;
            this.lstViewImage.GridLines = true;
            this.lstViewImage.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top |AnchorStyles.Bottom;
            this.treeViewImage.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.labelStatus.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            #endregion

            checkScan = false;
            Terminate = false;
            load_Buttons();
            MainMethods main = new MainMethods();
            main.load_TreeView(treeViewImage);

           
        }
        private void treeViewImage_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void treeViewImage_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.treeViewImage.SelectedNode.BackColor = SystemColors.HighlightText;
            string strNode = treeViewImage.SelectedNode.Text.ToLower();            
            load_lstView(strNode);
        }               
        private void lstViewImage_MouseClick(object sender, MouseEventArgs e)
        {            
            if(e.Button == MouseButtons.Right)
            {
                ListViewItem item = this.lstViewImage.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    this.SubMenu.Show(this.lstViewImage, e.Location);
                }
            }            
        }

        #region MAIN MENU
        #region File 
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Export2File";
            sfd.Filter = "Text File (.txt) | *.txt";
            sfd.DefaultExt = ".txt";
            string fileName= null;
            if(sfd.ShowDialog() == DialogResult.OK)
            {
               fileName = sfd.FileName.ToString();
            }           
            MainMethods main = new MainMethods();
            main.ExportLstView2TXT(this.lstViewImage, fileName);
        }
        private void regEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("regedit.exe");
        }
        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Refresh_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.load_Refresh();
        }
        #endregion

        #region Image 
        private void image_jumpToImage_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                selectedFile = lstViewImage.SelectedItems[0].Text;
                foreach (ImageInfo img in lst_everything)
                {
                    if (img.get_imageName() == selectedFile)
                    {
                        MainMethods main = new MainMethods();
                        main.jump2Image(img.get_imagePath());
                    }
                }      
            }
            catch
            {
                return;
            }
        }
        private void image_jumToRegistry_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                selectedFile = lstViewImage.SelectedItems[0].Text;
                foreach (ImageInfo img in lst_everything)
                {
                    if (img.get_imageName() == selectedFile)
                    {
                        baseRegkey = img.get_baseRegistryKey();
                        full_regKey = img.get_full_registrySection();
                        typeOS = img.get_typeOS();
                        MainMethods main = new MainMethods();
                        main.jump2Registry();
                    }
                }
            }
            catch
            {
                return;
            }
        }
        private void image_properties_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {                
                selectedFile = lstViewImage.SelectedItems[0].Text;
                form_Properties fProperties = new form_Properties();
                fProperties.ShowDialog();                     
            }
           catch
            {
                return;
            }
        }
        #endregion

        #region View       
        private void view_smallIcons_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.view_details_ToolStripMenuItem.Checked = false;
            this.view_list_ToolStripMenuItem.Checked = false;
            this.view_smallIcons_ToolStripMenuItem.Checked = true;
            this.lstViewImage.View = View.SmallIcon;
            this.lstViewImage.GridLines = true;
        }
        private void view_list_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.view_smallIcons_ToolStripMenuItem.Checked = false;
            this.view_details_ToolStripMenuItem.Checked = false;
            this.view_list_ToolStripMenuItem.Checked = true;
            this.lstViewImage.View = View.List;
            this.lstViewImage.GridLines = true;
        }
        private void view_details_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.view_smallIcons_ToolStripMenuItem.Checked = false;
            this.view_list_ToolStripMenuItem.Checked = false;
            this.view_details_ToolStripMenuItem.Checked = true;
            this.lstViewImage.View = View.Details;
            this.lstViewImage.GridLines = true;
        }
        #endregion

        #region System
        private void system_shutDown_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMethods main = new MainMethods();
            main.pc_Shutdown();
        }
        private void system_Sleep_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMethods main = new MainMethods();
            main.pc_Sleep();
        }
        private void system_reboot_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMethods main = new MainMethods();
            main.pc_Restart();
        }
        private void system_logOff_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMethods main = new MainMethods();
            main.pc_LogOff();
        }
        #endregion

        #region Help
        private void Help_content_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_Content();
        }
        private void Help_about_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_About();
        }
        #endregion
        #endregion

        #region TOOLBAR
        #region Run
        private void btnRun_Click(object sender, EventArgs e)
        {
            Shell32.Shell shell = new Shell32.Shell();
            shell.FileRun();
        }
        #endregion

        #region Properties
        private void btnProperties_Click(object sender, EventArgs e)
        {
            try
            {
                selectedFile = lstViewImage.SelectedItems[0].Text;
                form_Properties fProperties = new form_Properties();
                fProperties.ShowDialog();
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.load_Refresh();
        }
        #endregion

        #region Content
        private void btnContent_Click(object sender, EventArgs e)
        {
            load_Content();
        }
        #endregion

        #region About
        private void btnAbout_Click(object sender, EventArgs e)
        {
            load_About();
        }
        #endregion
        #endregion

        #region SUB MENU
        private void jumpToImageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                selectedFile = lstViewImage.SelectedItems[0].Text;
                foreach (ImageInfo img in lst_everything)
                {
                    if (img.get_imageName() == selectedFile)
                    {
                        MainMethods main = new MainMethods();
                        main.jump2Image(img.get_imagePath());
                    }
                }
            }
            catch
            {
                return;
            }
        }
        private void jumpToRegistryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                selectedFile = lstViewImage.SelectedItems[0].Text;
                foreach (ImageInfo img in lst_everything)
                {
                    if (img.get_imageName() == selectedFile)
                    {
                        baseRegkey = img.get_baseRegistryKey();
                        full_regKey = img.get_full_registrySection();
                        typeOS = img.get_typeOS();
                        MainMethods main = new MainMethods();
                        main.jump2Registry();
                    }
                }
            }
            catch
            {
                return;
            }
        }
        private void propertiesAltEnterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                selectedFile = lstViewImage.SelectedItems[0].Text;
                form_Properties fProperties = new form_Properties();
                fProperties.ShowDialog();
            }
            catch
            {
                return;
            }
        }
        #endregion

        #endregion

        #region PRIVATE METHODS
        private void load_lstView(string nodeName)
        {
            switch (nodeName)
            {
                #region everything
                case "everything":
                    {
                        lstViewImage.Items.Clear();
                        #region SCAN
                        if (!checkScan)
                        {
                            Thread t_scan = new Thread(new ThreadStart(this.scanAll));
                            t_scan.Start();
                            this.labelStatus.Text = "Scanning (Esc to cancel)";
                            // register the event that is fired after the key press.
                            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
                            // register the ESC as hot key.
                            hook.RegisterHotKey(Main.ModifierKeys.None, Keys.Escape);
                            t_scan.Join();
                            this.labelStatus.Text = "READY!";                                                   
                            checkScan = true;
                        }
                        #endregion
                        showImage(lst_everything, lstImg_everything);
                        break;
                    }
                #endregion
                #region registry
                case "registry":
                    {
                        lstViewImage.Items.Clear();
                        showImage(lst_registry, lstImg_registry);
                        break;
                    }
                #region current user
                case "current user":
                    {
                        lstViewImage.Items.Clear();
                        showImage(lst_cu, lstImg_cu);
                        break;
                    }
                case "cu_run":
                    {
                        lstViewImage.Items.Clear();
                        showImage(lst_HKCU_Run, lstImg_HKCU_Run);
                        break;
                    }
                case "cu_runonce":
                    {
                        lstViewImage.Items.Clear();
                        showImage(lst_HKCU_RunOnce, lstImg_HKCU_RunOnce);
                        break;
                    }
                #endregion
                #region all user
                case "all user":
                    {
                        lstViewImage.Items.Clear();
                        showImage(lst_au, lstImg_au);
                        break;
                    }
                case "au_run":
                    {
                        lstViewImage.Items.Clear();
                        showImage(lst_HKLM_Run32, lstImg_HKLM_Run32);
                        break;
                    }
                case "au_runonce":
                    {
                        lstViewImage.Items.Clear();
                        showImage(lst_HKLM_RunOnce32, lstImg_HKLM_RunOnce32);
                        break;
                    }
                case "au_run_64":
                    {
                        lstViewImage.Items.Clear();
                        showImage(lst_HKLM_Run64, lstImg_HKLM_Run64);
                        break;
                    }
                case "au_runonce_64":
                    {
                        lstViewImage.Items.Clear();
                        showImage(lst_HKLM_RunOnce64, lstImg_HKLM_RunOnce64);
                        break;
                    }
                #endregion
                #endregion
                #region services + dlls
                case "services":
                    {
                        lstViewImage.Items.Clear();
                        showImage(lst_HKLM_Serv, lstImg_HKLM_Serv);
                        break;
                    }
                case "knowndlls":
                    {
                        lstViewImage.Items.Clear();
                        showImage(lst_HKCR_DLLs, lstImg_HKCR_DLLs);
                        break;
                    }
                #endregion
                default: break;
            }
        }       
        private void scanAll()
        {            
            ImageScanner scanner = new ImageScanner();
            scanner.Start();
            #region GET DATA
            //HKCU Run
            this.lst_HKCU_Run = scanner.get_lst_HKCU_Run();
            this.lstImg_HKCU_Run = scanner.get_lstImage_HKCU_Run();
            //HKCU RunOnce
            this.lst_HKCU_RunOnce = scanner.get_lst_HKCU_RunOnce();
            this.lstImg_HKCU_RunOnce = scanner.get_lstImage_HKCU_RunOnce();
            //HKLM Run32
            this.lst_HKLM_Run32 = scanner.get_lst_HKLM_Run32();
            this.lstImg_HKLM_Run32 = scanner.get_lstImage_HKLM_Run32();
            //HKLM Run64
            this.lst_HKLM_Run64 = scanner.get_lst_HKLM_Run64();
            this.lstImg_HKLM_Run64 = scanner.get_lstImage_HKLM_Run64();
            //HKLM RunOnce32
            this.lst_HKLM_RunOnce32 = scanner.get_lst_HKLM_RunOnce32();
            this.lstImg_HKLM_RunOnce32 = scanner.get_lstImage_HKLM_RunOnce32();
            //HKLM RunOnce64
            this.lst_HKLM_RunOnce64 = scanner.get_lst_HKLM_RunOnce64();
            this.lstImg_HKLM_RunOnce64 = scanner.get_lstImage_HKLM_RunOnce64();
            //HKLM  Services
            this.lst_HKLM_Serv = scanner.get_lst_HKLM_Serv();
            this.lstImg_HKLM_Serv = scanner.get_lstImage_HKLM_Serv();
            //HKCR DLL
            this.lst_HKCR_DLLs = scanner.get_lst_HKCR_DLLs();
            this.lstImg_HKCR_DLLs = scanner.get_lstImage_HKCR_DLLs();
            #endregion         
            #region LOAD DATA TO lstView
            load_lstView_everything();
            load_lstView_registry();
            load_lstView_CU();
            load_lstView_AU();
            #endregion
        }      
        private void load_lstView_everything()
        {
            #region HKCU
            foreach (ImageInfo img in lst_HKCU_Run)
            {
                lst_everything.Add(img);
                lstImg_everything.Images.Add(img.get_imageName(),lstImg_HKCU_Run.Images[img.get_imageName()]);
            }    
            foreach (ImageInfo img in lst_HKCU_RunOnce)
            {
                lst_everything.Add(img);
                lstImg_everything.Images.Add(img.get_imageName(), lstImg_HKCU_RunOnce.Images[img.get_imageName()]);
            }
            #endregion
            #region HKLM
            foreach (ImageInfo img in lst_HKLM_Run32)
            {
                lst_everything.Add(img);
                lstImg_everything.Images.Add(img.get_imageName(), lstImg_HKLM_Run32.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKLM_Run64)
            {
                lst_everything.Add(img);
                lstImg_everything.Images.Add(img.get_imageName(), lstImg_HKLM_Run64.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKLM_RunOnce32)
            {
                lst_everything.Add(img);
                lstImg_everything.Images.Add(img.get_imageName(), lstImg_HKLM_RunOnce32.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKLM_RunOnce64)
            {
                lst_everything.Add(img);
                lstImg_everything.Images.Add(img.get_imageName(), lstImg_HKLM_RunOnce64.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKLM_Serv)
            {
                lst_everything.Add(img);
                lstImg_everything.Images.Add(img.get_imageName(), lstImg_HKLM_Serv.Images[img.get_imageName()]);
            }
            #endregion
            #region HKCR
            foreach (ImageInfo img in lst_HKCR_DLLs)
            {
                lst_everything.Add(img);
                lstImg_everything.Images.Add(img.get_imageName(), Properties.Resources.dll);
            }       
        #endregion
        }
        private void load_lstView_registry()
        {
            #region HKCU
            foreach (ImageInfo img in lst_HKCU_Run)
            {
                lst_registry.Add(img);
                lstImg_registry.Images.Add(img.get_imageName(), lstImg_HKCU_Run.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKCU_RunOnce)
            {
                lst_registry.Add(img);
                lstImg_registry.Images.Add(img.get_imageName(), lstImg_HKCU_RunOnce.Images[img.get_imageName()]);
            }
            #endregion
            #region HKLM
            foreach (ImageInfo img in lst_HKLM_Run32)
            {
                lst_registry.Add(img);
                lstImg_registry.Images.Add(img.get_imageName(), lstImg_HKLM_Run32.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKLM_Run64)
            {
                lst_registry.Add(img);
                lstImg_registry.Images.Add(img.get_imageName(), lstImg_HKLM_Run64.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKLM_RunOnce32)
            {
                lst_registry.Add(img);
                lstImg_registry.Images.Add(img.get_imageName(), lstImg_HKLM_RunOnce32.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKLM_RunOnce64)
            {
                lst_registry.Add(img);
                lstImg_registry.Images.Add(img.get_imageName(), lstImg_HKLM_RunOnce64.Images[img.get_imageName()]);
            }
            #endregion
        }
        private void load_lstView_CU()
        {
            #region HKCU
            foreach (ImageInfo img in lst_HKCU_Run)
            {
                lst_cu.Add(img);
                lstImg_cu.Images.Add(img.get_imageName(), lstImg_HKCU_Run.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKCU_RunOnce)
            {
                lst_cu.Add(img);
                lstImg_cu.Images.Add(img.get_imageName(), lstImg_HKCU_RunOnce.Images[img.get_imageName()]);
            }
            #endregion            
        }
        private void load_lstView_AU()
        {
            #region HKLM
            foreach (ImageInfo img in lst_HKLM_Run32)
            {
                lst_au.Add(img);
                lstImg_au.Images.Add(img.get_imageName(), lstImg_HKLM_Run32.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKLM_Run64)
            {
                lst_au.Add(img);
                lstImg_au.Images.Add(img.get_imageName(), lstImg_HKLM_Run64.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKLM_RunOnce32)
            {
                lst_au.Add(img);
                lstImg_au.Images.Add(img.get_imageName(), lstImg_HKLM_RunOnce32.Images[img.get_imageName()]);
            }
            foreach (ImageInfo img in lst_HKLM_RunOnce64)
            {
                lst_au.Add(img);
                lstImg_au.Images.Add(img.get_imageName(), lstImg_HKLM_RunOnce64.Images[img.get_imageName()]);
            }
            #endregion
        }       
        private void showImage(List<ImageInfo> lstImgInfo, ImageList imgLst)
        {
            if (lstImgInfo.Count > 0)
            {
                lstViewImage.SmallImageList = imgLst;
                
                foreach (ImageInfo image in lstImgInfo)
                {
                    ListViewItem item = new ListViewItem(image.get_imageName());
                    item.SubItems.Add(image.get_registrySection());
                    item.SubItems.Add(image.get_imageDescription());
                    if (image.get_imageStatus() == "invalid")
                    {
                        item.SubItems.Add("(Not verified) " + image.get_publisher());
                        item.BackColor = Color.LightPink;
                    }
                    else
                    {
                        item.SubItems.Add(image.get_publisher());
                    }
                    if (image.get_imageStatus() == "miss")
                    {
                        item.BackColor = Color.LimeGreen;
                    }                    
                    item.SubItems.Add(image.get_imagePath());
                    item.ImageIndex = imgLst.Images.IndexOfKey(image.get_imageName());
                              
                    lstViewImage.Items.Add(item);
                }
            }
        }
        private void load_Refresh()
        {
            this.Init_Params();
            this.treeViewImage.SelectedNode = this.treeViewImage.Nodes[0];
            Thread t_scan = new Thread(new ThreadStart(this.scanAll));
            t_scan.Start();
            this.labelStatus.Text = "Scanning";
            t_scan.Join();
            this.labelStatus.Text = "READY!";
            checkScan = true;
            showImage(lst_everything, lstImg_everything);
        }
        private void Init_Params()
        {
            #region Init Params
            //HKCU Run
            lst_HKCU_Run = new List<ImageInfo>();
            lstImg_HKCU_Run = new ImageList();
            //HKCU RunOnce
            lst_HKCU_RunOnce = new List<ImageInfo>();
            lstImg_HKCU_RunOnce = new ImageList();
            //HKLM Run32
            lst_HKLM_Run32 = new List<ImageInfo>();
            lstImg_HKLM_Run32 = new ImageList();
            //HKLM Run64
            lst_HKLM_Run64 = new List<ImageInfo>();
            lstImg_HKLM_Run64 = new ImageList();
            //HKLM RunOnce32
            lst_HKLM_RunOnce32 = new List<ImageInfo>();
            lstImg_HKLM_RunOnce32 = new ImageList();
            //HKLM RunOnce64
            lst_HKLM_RunOnce64 = new List<ImageInfo>();
            lstImg_HKLM_RunOnce64 = new ImageList();
            //HKLM  Services
            lst_HKLM_Serv = new List<ImageInfo>();
            lstImg_HKLM_Serv = new ImageList();
            //HKCR DLL
            lst_HKCR_DLLs = new List<ImageInfo>();
            lstImg_HKCR_DLLs = new ImageList();

            invalidImages = new List<string>();
            hook = new KeyboardHook();
            #endregion            

            #region data to lstView
            //Load data to lstView
             lst_everything = new List<ImageInfo>();
             lstImg_everything = new ImageList();
             lst_registry = new List<ImageInfo>();
             lstImg_registry = new ImageList();
             lst_cu = new List<ImageInfo>();
             lstImg_cu = new ImageList();
             lst_au = new List<ImageInfo>();
             lstImg_au = new ImageList();
            #endregion
        }
        private void load_Buttons()
        {
            this.btnRun.Image = Properties.Resources.run;
            this.btnRun.ImageAlign = ContentAlignment.TopCenter;
            this.btnRun.TextAlign = ContentAlignment.BottomCenter;

            this.btnProperties.Image = Properties.Resources.properties;
            this.btnProperties.ImageAlign = ContentAlignment.TopCenter;
            this.btnProperties.TextAlign = ContentAlignment.BottomCenter;

            this.btnRefresh.Image = Properties.Resources.refresh;
            this.btnRefresh.ImageAlign = ContentAlignment.TopCenter;
            this.btnRefresh.TextAlign = ContentAlignment.BottomCenter;

            this.btnContent.Image = Properties.Resources.help;
            this.btnContent.ImageAlign = ContentAlignment.TopCenter;
            this.btnContent.TextAlign = ContentAlignment.BottomCenter;

            this.btnAbout.Image = Properties.Resources.about;
            this.btnAbout.ImageAlign = ContentAlignment.TopCenter;
            this.btnAbout.TextAlign = ContentAlignment.BottomCenter;
        }
        private void load_Content()
        {
            MessageBox.Show("User Guide update later.");
        }
        private void load_About()
        {
            MessageBox.Show(  "Công cụ hỗ trợ tìm kiếm và tiêu diệt mã độc \n"+
                                            "Author : Nguyen Huy Hoang \n" +
                                            "Phong Ky Thuat - Cuc QLKT NVMM \n" +
                                            "Ban Co Yeu Chinh Phu" );
        }
        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // if ESC is pressed, scanning process will be terminated
            Terminate = true;            
            //this.labelStatus.Text = e.Modifier.ToString() + " + " + e.Key.ToString();
        }
  
        #endregion  

        

        

        

        

       

        

       

       

        

       

        

       

        

       

        

        

       

       

        

       



       

       

        

        

        

    }
}
