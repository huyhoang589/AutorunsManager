using System;
using Microsoft.Win32;
using ImageInformation;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace RegistryInfo
{
    class HKClassesRoot
    {
        #region PARAMS
        private List<ImageInfo> listHKCR;
        private List<string> listCheck;
        private ImageInfo infoDLL;
        #endregion

        #region CONSTRUCTOR
        public HKClassesRoot()
        {
            listHKCR = new List<ImageInfo>();
            listCheck = new List<string>();
        }
        #endregion

        #region METHODS
        public void load_HKCU_DLL()
        {
            //Open the HKEY_CLASSES_ROOT\CLSID which contains the list of all registered COM files (.ocx,.dll, .ax) 
            //on the system no matters if is 32 or 64 bits.
            RegistryKey CR_idKey = Registry.ClassesRoot.OpenSubKey("CLSID");

            //Get all the sub keys it contains, wich are the generated GUID of each COM.
            //For each CLSID\GUID key we get the InProcServer32 sub-key .
            #region Process
                foreach (string subKey in CR_idKey.GetSubKeyNames())
                {
                    try
                    {
                        string idSubkey = "CLSID\\" + subKey + "\\InProcServer32";
                        RegistryKey CR_idSubKey = Registry.ClassesRoot.OpenSubKey(idSubkey);
                        if ((CR_idSubKey != null))
                        {
                            infoDLL = new ImageInfo();

                            string[] valName = CR_idSubKey.GetValueNames();

                            foreach (string val in valName)
                            {
                                if (CR_idSubKey.GetValue(val).ToString().Contains("C:\\"))
                                {
                                    string imagePath = CR_idSubKey.GetValue(val).ToString();
                                    if (File.Exists(imagePath))
                                    {
                                        FileVersionInfo fVerInfo = FileVersionInfo.GetVersionInfo(imagePath);
                                        bool check = checkImage(fVerInfo.FileName, listCheck);
                                        if (check == false)
                                        {
                                            #region set ImageInformation
                                            listCheck.Add(fVerInfo.FileName);
                                            infoDLL.set_imageName(fVerInfo.InternalName);
                                            infoDLL.set_imageDescription(fVerInfo.FileDescription);
                                            infoDLL.set_publisher(fVerInfo.CompanyName);
                                            infoDLL.set_imagePath(fVerInfo.FileName);
                                            infoDLL.set_registrySection("HKCR\\CLSID");
                                            infoDLL.set_fileVersion(fVerInfo.FileVersion);
                                            infoDLL.set_internalName(fVerInfo.InternalName);
                                            infoDLL.set_originalName(fVerInfo.OriginalFilename);
                                            infoDLL.set_productName(fVerInfo.ProductName);
                                            infoDLL.set_productVersion(fVerInfo.ProductVersion);
                                            infoDLL.set_copyright(fVerInfo.LegalCopyright);
                                            infoDLL.set_baseRegistryKey(Registry.ClassesRoot.ToString());
                                            infoDLL.set_full_registrySection(idSubkey);

                                            listHKCR.Add(infoDLL);
                                            #endregion
                                        }//END IF
                                    }// END IF                                                                                      
                                }                                
                            }
                        }
                    }//END try
                    catch
                    {
                        //MessageBox.Show("HKCR_DLLs_An exception has occured!  " + e.Message);
                    }                   
                }
                #endregion
            CR_idKey.Close();
        }
        private bool checkImage(string imageName, List<string> lstCheck)
        {
            foreach (string addedName in listCheck)
            {
                if (imageName == addedName) return true;
            }
            return false;

        }
        #endregion

        #region GET
        public List<ImageInfo> get_HKCR_DLL()
        {
            return listHKCR;
        }
        #endregion
    }
}
