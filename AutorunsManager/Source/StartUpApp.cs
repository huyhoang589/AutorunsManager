using System;
using System.IO;
using System.Collections.Generic;
using IWshRuntimeLibrary;
using ImageInformation;

namespace RegistryInfo
{
    class StartUpApp
    {
        #region PARAMS
        private string dirStartUp_AU = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Startup";
        private string dirStartUp_CU = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup";
        private List<ImageInfo> lstStartUpApp_AU;
        private List<ImageInfo> lstStartUpApp_CU;
        #endregion

        #region CONSTRUCTOR
        public StartUpApp()
        {
            lstStartUpApp_AU = new List<ImageInfo>();
            lstStartUpApp_CU = new List<ImageInfo>();
            load_StartUpApp();
        }
        #endregion

        #region PRIVATE METHODS
        private void load_StartUpApp()
        {
            // Using COM object: Windows Script Host Object Model to get the target of a shortcut (.lnk file extension)
            DirectoryInfo dirStartUp_AU_Info = new DirectoryInfo(dirStartUp_AU);
            DirectoryInfo dirStartUp_CU_Info = new DirectoryInfo(dirStartUp_CU);
            foreach (FileInfo fInfo in dirStartUp_CU_Info.GetFiles())
            {
                if (fInfo.Name.Contains(".lnk"))
                {
                    //get the target of a shortcut
                    WshShell shell = new WshShell();
                    IWshShortcut shCut = (IWshShortcut)shell.CreateShortcut(fInfo.FullName);
                    ImageInfo iInfo = new ImageInfo(fInfo.Name,shCut.TargetPath);
                    iInfo.set_registrySection(@"StartUp\Current User");
                    lstStartUpApp_CU.Add(iInfo);
                }// end IF
            }

            foreach (FileInfo fInfo in dirStartUp_AU_Info.GetFiles())
            {
                if (fInfo.Name.Contains(".lnk"))
                {
                    //get the target of a shortcut
                    WshShell shell = new WshShell();
                    IWshShortcut shCut = (IWshShortcut)shell.CreateShortcut(fInfo.FullName);
                    ImageInfo iInfo = new ImageInfo(fInfo.Name, shCut.TargetPath);
                    iInfo.set_registrySection(@"StartUp\All User");
                    lstStartUpApp_AU.Add(iInfo);
                }// end IF
            }
        }
        #endregion;

        #region GET
        public List<ImageInfo> get_StartUpApp_AU()
        {
            return lstStartUpApp_AU;
        }
        public List<ImageInfo> get_StartUpApp_CU()
        {
            return lstStartUpApp_CU;
        }
        #endregion
    }
}
