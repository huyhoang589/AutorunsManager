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
        private List<ImageInfo> listHKLM_Run_32;
        private List<ImageInfo> listHKLM_Run_64;
        private List<ImageInfo> listHKLM_RunOnce_32;
        private List<ImageInfo> listHKLM_RunOnce_64;
        private List<ImageInfo> listHKLM_Services;
        #endregion

        #region CONSTRUCTOR
        public HKLocalMachine()
        {
            listHKLM_Run_32 = new List<ImageInfo>();
            listHKLM_Run_64 = new List<ImageInfo>();
            listHKLM_RunOnce_32= new List<ImageInfo>();
            listHKLM_RunOnce_64= new List<ImageInfo>();
            listHKLM_Services = new List<ImageInfo>();
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
                    catch(Exception e)
                    {
                        MessageBox.Show("HKLM_Run32_An exception has occured!  " + e.Message);                            
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
                catch (Exception e)
                {
                    MessageBox.Show("HKLM_Run64_An exception has occured!  " + e.Message);
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
                catch (Exception e)
                {
                    MessageBox.Show("HKLM_RunOnce32_An exception has occured!  " + e.Message);
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
                catch (Exception e)
                {
                    MessageBox.Show("HKLM_RunOnce64_An exception has occured!  " + e.Message);
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
                catch(Exception e)
                {
                    MessageBox.Show("HKLM_Services_An exception has occured!  " + e.Message);
                }
            }
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
        #endregion
       
    }
}
