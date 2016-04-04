using System;
using Microsoft.Win32;
using System.Collections.Generic;
using ImageInformation;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace RegistryInfo
{
    class HKCurrentUser
    {
        #region PARAMS
        private string strRegKey_Run = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private string strRegKey_RunOnce = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\RunOnce";
        private List<ImageInfo> listHKCU_Run;
        private List<ImageInfo> listHKCU_RunOnce;
        #endregion

        #region CONSTRUCTOR
        public HKCurrentUser()
        {
            listHKCU_Run = new List<ImageInfo>();
            listHKCU_RunOnce = new List<ImageInfo>();
        }
        #endregion

        #region METHODS
        public void load_HKCU_Run()
        {
            RegistryKey regKey_Run = Registry.CurrentUser.OpenSubKey(strRegKey_Run);
            foreach (string image in regKey_Run.GetValueNames())
            {
                try
                {
                    string filePath = regKey_Run.GetValue(image).ToString();
                    ImageInfo info = new ImageInfo(image, filePath); 
                    info.set_registrySection("HKCU\\" + strRegKey_Run);
                    info.set_baseRegistryKey(Registry.CurrentUser.ToString());
                    info.set_full_registrySection(strRegKey_Run );
                    listHKCU_Run.Add(info);                                                                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("HKCU_Run_An exception has occured!  " + e.Message);
                }
            }
            regKey_Run.Close();
        }
        public void load_HKCU_RunOnce()
        {
            RegistryKey regKey_RunOnce = Registry.CurrentUser.OpenSubKey(strRegKey_RunOnce);
            foreach (string image in regKey_RunOnce.GetValueNames())
            {
                try
                {
                    string filePath = regKey_RunOnce.GetValue(image).ToString();
                    ImageInfo info = new ImageInfo(image, filePath);
                    info.set_registrySection("HKCU\\" + strRegKey_RunOnce);
                    listHKCU_RunOnce.Add(info);
                }
                catch (Exception e)
                {
                    MessageBox.Show("HKCU_RunOnce_An exception has occured!  " + e.Message);
                }
            }
            regKey_RunOnce.Close();
        }

        
        #endregion

        #region GET
        public List<ImageInfo> get_HKCU_Run()
        {
            return listHKCU_Run;
        }
        public List<ImageInfo> get_HKCU_RunOnce()
        {
            return listHKCU_RunOnce;
        }
        #endregion
    }
}
