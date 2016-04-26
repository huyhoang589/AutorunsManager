using System;
using Microsoft.Win32;
using ImageInformation;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Reflection;

namespace RegistryInfo
{
    class HKLocalMachine
    {
        #region PARAMS
        private string regKey_Run64 = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";
        private string regKey_Run32 = "Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Run";
        private string regKey_RunOnce64 = "Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce";
        private string regKey_RunOnce32 = "Software\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\RunOnce";
        private string regKey_Services = "System\\CurrentControlSet\\Services";
        private string regKey_KnownDLLs = "System\\CurrentControlSet\\Control\\Session Manager\\KnownDLLs";

        private List<ImageInfo> listHKLM_Run_32;
        private List<ImageInfo> listHKLM_Run_64;
        private List<ImageInfo> listHKLM_RunOnce_32;
        private List<ImageInfo> listHKLM_RunOnce_64;
        private List<ImageInfo> listHKLM_Services;
        private List<ImageInfo> listHKLM_Drivers;
        private List<ImageInfo> listHKLM_KnownDlls;
        private List<ImageInfo> listHKLM_KnownDlls_32;
        #endregion

        #region CONSTRUCTOR
        public HKLocalMachine()
        {
            listHKLM_Run_32 = new List<ImageInfo>();
            listHKLM_Run_64 = new List<ImageInfo>();
            listHKLM_RunOnce_32= new List<ImageInfo>();
            listHKLM_RunOnce_64= new List<ImageInfo>();
            listHKLM_Services = new List<ImageInfo>();
            listHKLM_Drivers = new List<ImageInfo>();
            listHKLM_KnownDlls = new List<ImageInfo>();
            listHKLM_KnownDlls_32 = new List<ImageInfo>();
        }
        #endregion

        #region METHODS
        public void load_HKLM_Run_32()
        {
                RegistryKey Run_32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(regKey_Run32);          
                foreach(string image in Run_32.GetValueNames())
                {                              
                    try
                    {
                        string filePath = Run_32.GetValue(image).ToString();                        
                        ImageInfo infoRun32 = new ImageInfo(image, filePath);
                        infoRun32.set_registrySection("HKLM\\" + regKey_Run32);
                        infoRun32.set_baseRegistryKey(Registry.LocalMachine.ToString());
                        infoRun32.set_full_registrySection(regKey_Run32);
                        infoRun32.set_typeOS("x32");
                        listHKLM_Run_32.Add(infoRun32);
                    }
                    catch
                    {
                        //MessageBox.Show("HKLM_Run32_An exception has occured!  " + e.Message);                            
                    }                                                                      
                }
                Run_32.Close();          
        }        
        public void load_HKLM_Run_64()
        {
            RegistryKey Run_64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(regKey_Run64);
            foreach (string image in Run_64.GetValueNames())
            {                
                try
                {
                    string filePath = Run_64.GetValue(image).ToString();                    
                    ImageInfo infoRun64 = new ImageInfo(image, filePath);
                    infoRun64.set_registrySection("HKLM\\" + regKey_Run64);
                    infoRun64.set_baseRegistryKey(Registry.LocalMachine.ToString());
                    infoRun64.set_full_registrySection(regKey_Run64);
                    infoRun64.set_typeOS("x64");
                    listHKLM_Run_64.Add(infoRun64);
                }
                catch 
                {
                    //MessageBox.Show("HKLM_Run64_An exception has occured!  " + e.Message);
                }
            }
            Run_64.Close();
        }
        public void load_HKLM_RunOnce_32()
        {
            RegistryKey RunOnce_32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(regKey_RunOnce32);
            foreach (string image in RunOnce_32.GetValueNames())
            {                
                try
                {
                    string filePath = RunOnce_32.GetValue(image).ToString();                  
                    ImageInfo infoRunOnce32 = new ImageInfo(image, filePath);
                    infoRunOnce32.set_registrySection("HKLM\\" + regKey_RunOnce32);
                    infoRunOnce32.set_baseRegistryKey(Registry.LocalMachine.ToString());
                    infoRunOnce32.set_full_registrySection(regKey_RunOnce32);
                    infoRunOnce32.set_typeOS("x32");
                    listHKLM_RunOnce_32.Add(infoRunOnce32);
                }
                catch 
                {
                    //MessageBox.Show("HKLM_RunOnce32_An exception has occured!  " + e.Message);
                }
            }
            RunOnce_32.Close();
        }
        public void load_HKLM_RunOnce_64()
        {
            RegistryKey RunOnce_64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(regKey_RunOnce64);
            foreach (string image in RunOnce_64.GetValueNames())
            {
                try
                {
                    string filePath = RunOnce_64.GetValue(image).ToString();
                    ImageInfo infoRunOnce64 = new ImageInfo(image, filePath);
                    infoRunOnce64.set_registrySection("HKLM\\" + regKey_RunOnce64);
                    infoRunOnce64.set_baseRegistryKey(Registry.LocalMachine.ToString());
                    infoRunOnce64.set_full_registrySection(regKey_RunOnce64);
                    infoRunOnce64.set_typeOS("x64");
                    listHKLM_RunOnce_64.Add(infoRunOnce64);
                }
                catch 
                {
                    //MessageBox.Show("HKLM_RunOnce64_An exception has occured!  " + e.Message);
                }

            }
            RunOnce_64.Close();
        }     
        public void load_HKLM_Services()
        {
            foreach(ServiceController service in ServiceController.GetServices())
            {
                try
                {                   
                    RegistryKey Services = Registry.LocalMachine.OpenSubKey(regKey_Services +"\\" + service.ServiceName);
                    string filePath = Services.GetValue("ImagePath").ToString();
                    ImageInfo infoServices = new ImageInfo(service.ServiceName,filePath );
                    infoServices.set_registrySection("HKLM\\" + regKey_Services);
                    infoServices.set_baseRegistryKey(Registry.LocalMachine.ToString());
                    infoServices.set_full_registrySection(regKey_Services + "\\" + service.ServiceName);
                    listHKLM_Services.Add(infoServices);              
                    Services.Close();
                }
                catch
                {
                    //MessageBox.Show("HKLM_Services_An exception has occured!  " + e.Message);
                }
            }
        }
        public void load_HKLM_Drivers()
        {
            foreach (ServiceController service in ServiceController.GetDevices())
            {
                try
                {
                    RegistryKey Drivers = Registry.LocalMachine.OpenSubKey(regKey_Services + "\\" + service.ServiceName);
                    string filePath = Drivers.GetValue("ImagePath").ToString();
                    ImageInfo iInfo = new ImageInfo(service.ServiceName, filePath,true);
                    iInfo.set_registrySection("HKLM\\" + regKey_Services);
                    iInfo.set_baseRegistryKey(Registry.LocalMachine.ToString());
                    iInfo.set_full_registrySection(regKey_Services + "\\" + service.ServiceName);
                    listHKLM_Drivers.Add(iInfo);
                    Drivers.Close();
                }
                catch
                {
                    //MessageBox.Show("HKLM_Services_An exception has occured!  " + e.Message);
                }
            }
        }
        public void load_HKLM_KnownDLLs()
        {
            RegistryKey KnownDLLs = Registry.LocalMachine.OpenSubKey(regKey_KnownDLLs);
            string filePath = KnownDLLs.GetValue("DllDirectory").ToString();
            string filePath32 = KnownDLLs.GetValue("DllDirectory32").ToString();
            foreach (string image in KnownDLLs.GetValueNames())
            {
                try
                {
                    if (image != "DllDirectory" && image != "DllDirectory32")
                    {
                        string fileName = KnownDLLs.GetValue(image).ToString();

                        ImageInfo iInfo = new ImageInfo(image, filePath + "\\" + fileName);
                        iInfo.set_registrySection("HKLM\\" + regKey_KnownDLLs);
                        iInfo.set_baseRegistryKey(Registry.LocalMachine.ToString());
                        iInfo.set_full_registrySection(regKey_KnownDLLs);
                        listHKLM_KnownDlls.Add(iInfo);

                        ImageInfo iInfo32 = new ImageInfo(image, filePath32 + "\\" + fileName);
                        iInfo32.set_registrySection("HKLM\\" + regKey_KnownDLLs);
                        iInfo32.set_baseRegistryKey(Registry.LocalMachine.ToString());
                        iInfo32.set_full_registrySection(regKey_KnownDLLs);
                        listHKLM_KnownDlls.Add(iInfo32);
                    }//end IF                                            
                }
                catch(Exception e)
                {
                    MessageBox.Show("HKLM_KnownDLLs_An exception has occured! " + e.Message);
                }                
            }
            KnownDLLs.Close();
        }
        
        #endregion

        #region GET
        public List<ImageInfo> get_HKLM_Run_32()
        {
            return listHKLM_Run_32;
        }
        public List<ImageInfo> get_HKLM_Run_64()
        {
            return listHKLM_Run_64;
        }
        public List<ImageInfo> get_HKLM_RunOnce_32()
        {
            return listHKLM_RunOnce_32;
        }
        public List<ImageInfo> get_HKLM_RunOnce_64()
        {
            return listHKLM_RunOnce_64;
        }
        public List<ImageInfo>get_HKLM_Services()
        {
            return listHKLM_Services;
        }
        public List<ImageInfo> get_HKLM_Drivers()
        {
            return listHKLM_Drivers;
        }
        public List<ImageInfo> get_HKLM_KnownDLLs()
        {
            return listHKLM_KnownDlls;
        }
        public List<ImageInfo> get_HKLM_KnownDLLs_32()
        {
            return listHKLM_KnownDlls_32;
        }
        #endregion

    }
}
