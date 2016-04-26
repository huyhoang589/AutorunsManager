using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Threading;

namespace AutorunsManager.Main
{
    class MainMethods
    {
        #region GUI
        public void load_TreeView(TreeView treeView)
        {
            try
            {
                treeView.Nodes.Add("Everything");

                treeView.Nodes.Add("Start Up");

                treeView.Nodes.Add("Registry");
                treeView.Nodes[2].Nodes.Add("Current User");
                treeView.Nodes[2].Nodes[0].Nodes.Add("CU_Run");
                treeView.Nodes[2].Nodes[0].Nodes.Add("CU_RunOnce");
                treeView.Nodes[2].Nodes.Add("All User");
                treeView.Nodes[2].Nodes[1].Nodes.Add("AU_Run");
                treeView.Nodes[2].Nodes[1].Nodes.Add("AU_RunOnce");
                treeView.Nodes[2].Nodes[1].Nodes.Add("AU_Run_64");
                treeView.Nodes[2].Nodes[1].Nodes.Add("AU_RunOnce_64");

                treeView.Nodes.Add("Services");

                treeView.Nodes.Add("KnownDLLs");

                treeView.Nodes.Add("Drivers");

                treeView.ExpandAll();
            }
            catch
            {
                //MessageBox.Show("main.load_TreeView_An exception has occured !" + e.Message);
                //return;
            }            
        }
        public void ExportLstView2TXT(ListView lstView, String fileName)
        {        
            try
            {
                if(fileName != null)
                {
                    StreamWriter sw = new StreamWriter(fileName);
                    foreach (ListViewItem item in lstView.Items)
                    {
                        sw.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8}", item.SubItems[0].Text, "|", item.SubItems[1].Text, "|", item.SubItems[2].Text, "|", item.SubItems[3].Text, "|", item.SubItems[4].Text);
                    }
                    sw.Flush();
                    sw.Close();
                }//END if
            }
            catch
            {
                //MessageBox.Show("main.ExportLstView2XML_An exception has occured !" + e.Message);
                //return;
            }
        }
        #endregion

        #region EVENTS
        public void jump2Image(string filePath)
        {             
            try
            {
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", filePath));
            }
            catch
            {
                //MessageBox.Show("main.jump2Image_An exception has occured!" + e.Message);
                //return;
            }           
        }
        public void jump2Registry()
        {
            try
            {
                Process[] runningProc = Process.GetProcessesByName("regedit");
                if(runningProc.Length >0)
                {
                    for(int i=0; i<runningProc.Length;i++)
                    {
                        // Close process by sending a close message to its main window.
                        runningProc[i].CloseMainWindow();
                        // Free resources associated with process.
                        runningProc[i].Close();
                    }
                }
                Thread t_thread = new Thread(new ThreadStart(set_regKeyVal));
                t_thread.Start();
                t_thread.Join();                
                               
                 Process.Start("regedit.exe");                     
            }
           catch
            {
                //MessageBox.Show("main.jump2Registry_An exception has occured!" + e.Message);
                //return;
            }
        }
        public void pc_Shutdown()
        {
            try
            {
                Process.Start("shutdown", "/s /t 0");     // starts the shutdown application 
                                                                            // the argument /s is to shut down the computer
                                                                            // the argument /t 0 is to tell the process that 
                                                                            // the specified operation needs to be completed 
                                                                            // after 0 seconds
            }
            catch
            {
                //return;
            }
            
        }
        public void pc_Restart()
        {
            try
            {
                Process.Start("shutdown", "/r /t 0");  // the argument /r is to restart the computer
            }
            catch
            {
                //return;
            }           
        }

        //Extern method to log off
        [DllImport("user32")]
        private static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        public void pc_LogOff()
        {
            try
            {
                ExitWindowsEx(0, 0);
            }
            catch
            {
                //return;
            }            
        }
        
        //Extern method to sleep
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);
        public void pc_Sleep()
        {
            try
            {
                SetSuspendState(false, true, true); //To bring your computer into Hibernate:
                //SetSuspendState(true, true, true);
            }
            catch
            {
                //return;
            }
        }
        #endregion

        #region PRIVATE
        private void set_regKeyVal()
        {
            //Registry Editor is able to remember the last opened key.
            //This data is stored at the following registry key:
            //HKEY_Current_User\Software\Microsoft\Windows\CurrentVersion\Applets\Regedit
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Applets\Regedit", true);
            RegistryKey rkey2jump = null;
            if (AutorunsManager.baseRegkey == Registry.LocalMachine.ToString())
            {
                if(AutorunsManager.typeOS == "x64")
                {
                    rkey2jump = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(AutorunsManager.full_regKey, false);
                    
                }
                else
                {
                    rkey2jump = Registry.LocalMachine.OpenSubKey(AutorunsManager.full_regKey, false);
                }
            }
            if(AutorunsManager.baseRegkey == Registry.CurrentUser.ToString())
            {
                rkey2jump = Registry.CurrentUser.OpenSubKey(AutorunsManager.full_regKey, false);
            }
            if(AutorunsManager.baseRegkey == Registry.ClassesRoot.ToString())
            {
                rkey2jump = Registry.ClassesRoot.OpenSubKey(AutorunsManager.full_regKey, false);
            }
            if(rkey2jump != null)
            {
                rkey.SetValue("LastKey", rkey2jump.ToString());
            }            
        }
        #endregion
    }//END Class
}
