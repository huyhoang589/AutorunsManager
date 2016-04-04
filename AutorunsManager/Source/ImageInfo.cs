using System;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace ImageInformation
{
    /// <summary>
    /// This is primary class
    /// </summary>
    public class ImageInfo
    {
        #region PARAMS
        private string imageName ;
        private string registrySection;
        private string full_registrySection;
        private string baseRegistryKey;
        private string typeOS;
        private string imageDescription ;
        private string imagePath ;
        private string publisher ;
        private string fileVersion;
        private string internalName;
        private string originalName;
        private string productName;
        private string productVersion;
        private string copyright;
        private bool isPatched;
        private string imageStatus; //invalid | valid | miss
        #endregion

        #region CONSTRUCTORS
        public ImageInfo ()
        {
            imageName = String.Empty;
            registrySection = String.Empty;
            full_registrySection = String.Empty;
            baseRegistryKey = String.Empty;
            typeOS = String.Empty;
            imageDescription = String.Empty;
            imagePath = String.Empty;
            publisher = String.Empty;           
            fileVersion = String.Empty;
            internalName = String.Empty;
            originalName = String.Empty;
            productName = String.Empty;
            productVersion = String.Empty;
            copyright = String.Empty;            
            imageStatus = String.Empty;
        }
        public ImageInfo(string fileName, string filePath)
        {
            try
            {
                string fPath = this.filePath(filePath);
                this.imageName = fileName;
                if(File.Exists(fPath))
                {
                    FileVersionInfo fInfo = FileVersionInfo.GetVersionInfo(fPath);
                    this.imagePath = fInfo.FileName;
                    this.imageDescription = fInfo.FileDescription;
                    this.publisher = fInfo.CompanyName;
                    this.fileVersion = fInfo.FileVersion;
                    this.internalName = fInfo.InternalName;
                    this.originalName = fInfo.OriginalFilename;
                    this.productName = fInfo.ProductName;
                    this.productVersion = fInfo.ProductVersion;
                    this.copyright = fInfo.LegalCopyright;
                    this.isPatched = fInfo.IsPatched;
                }
                //else
                //{
                //    MessageBox.Show(fileName + " File not exist !");
                //}          
                //if(this.isPatched == false)
                //{
                //    this.imageStatus = "valid";
                //}
                //else
                //{
                //    this.imageStatus = "invaild";
                //}
            }
            catch(Exception e)
            {
               MessageBox.Show("ImageInformation_An exception has occured!  " + e.Message);                             
            }           
        }
        public ImageInfo(string filePath)
        {
            try
            {
                string fPath = this.filePath(filePath);                
                if (File.Exists(fPath))
                {
                    FileVersionInfo fInfo = FileVersionInfo.GetVersionInfo(fPath);
                    this.imageName = fInfo.InternalName;
                    this.imagePath = fInfo.FileName;
                    this.imageDescription = fInfo.FileDescription;
                    this.publisher = fInfo.CompanyName;
                    this.fileVersion = fInfo.FileVersion;
                    this.internalName = fInfo.InternalName;
                    this.originalName = fInfo.OriginalFilename;
                    this.productName = fInfo.ProductName;
                    this.productVersion = fInfo.ProductVersion;
                    this.copyright = fInfo.LegalCopyright;
                    this.isPatched = fInfo.IsPatched;
                }
                //if (this.isPatched)
                //{
                //    this.imageStatus = "invalid";
                //}
                //else
                //{
                //    this.imageStatus = "vaild";
                //}
            }
            catch (Exception e)
            {
                MessageBox.Show("ImageInformation_An exception has occured!  " + e.Message);
            }
            
        }
        #endregion

        #region SET
        public void set_imageName(string str)
        {          
                if(str != null)
                {
                    imageName = string.Copy(str);
                }         
        }
        public void set_registrySection(string str)
        {           
                if(str != null)
                {
                    registrySection = string.Copy(str);
                }          
        }
        public void set_full_registrySection(string str)
        {
            if (str != null)
            {
                full_registrySection = string.Copy(str);
            }
        }
        public void set_baseRegistryKey(string str)
        {
            if (str != null)
            {
                baseRegistryKey = string.Copy(str);
            }
        }
        public void set_typeOS(string str)
        {
            if (str != null)
            {
                typeOS = string.Copy(str);
            }
        }
        public void set_imageDescription(string str)
        {          
                if(str != null)
                {
                    imageDescription = string.Copy(str);
                }           
        }
        public void set_imagePath(string str)
        {           
                if (str != null)
                {
                    imagePath = string.Copy(str);
                }               
        }
        public void set_publisher(string str)
        {
                if(str != null)
                {
                    publisher = string.Copy(str);
                }          
        }
        public void set_fileVersion(string str)
         {
             if (str != null)
             {
                 fileVersion = string.Copy(str);
             }
         }
        public void set_internalName(string str)
         {
             if (str != null)
             {
                 internalName = string.Copy(str);
             }
         }
        public void set_originalName(string str)
         {
             if (str != null)
             {
                 originalName = string.Copy(str);
             }
         }
        public void set_productName(string str)
         {
             if (str != null)
             {
                 productName = string.Copy(str);
             }
         }
        public void set_productVersion(string str)
         {
             if (str != null)
             {
                 productVersion = string.Copy(str);
             }
         }
        public void set_copyright(string str)
         {
             if (str != null)
             {
                 copyright = string.Copy(str);
             }
         }
        public void set_imageStatus(string str)
        {
            if (str != null)
            {
                imageStatus = string.Copy(str);
            }
        }
        #endregion

        #region GET
        public string get_imageName()
        {
            return imageName;
        }
        public string get_registrySection()
         {
             return registrySection;
         }
        public string get_full_registrySection()
         {
             return full_registrySection;
         }
        public string get_baseRegistryKey()
         {
             return baseRegistryKey;
         }
        public string get_typeOS()
         {
             return typeOS;
         }
        public string get_imageDescription()
         {
             return imageDescription;
         }
        public string get_imagePath()
         {
             return imagePath;
         }
        public string get_publisher()
         {
             return publisher;
         }
        public string get_fileVersion()
         {
             return fileVersion;
         }
        public string get_internalName()
         {
             return internalName;
         }
        public string get_originalName()
         {
             return originalName;
         }
        public string get_productName()
         {
             return productName;
         }
        public string get_productVersion()
         {
             return productVersion;
         }
        public string get_copyright()
         {
             return copyright;
         }
        public string get_imageStatus()
         {
             return imageStatus;
         }
        #endregion

        #region PRIVATE METHODS       
        private string filePath(string Path)
        {
            string imagePath = null;
            if (Path.Contains("C:\\"))
            {
                if (Path.Contains(".exe"))
                {
                    imagePath = "C:\\" + this.Substring(Path, "C:\\", ".exe") + ".exe";
                }
                if (Path.Contains(".EXE"))
                {
                    imagePath = "C:\\" + this.Substring(Path, "C:\\", ".EXE") + ".exe";
                }
                if (Path.Contains(".dll"))
                {
                    imagePath = "C:\\" + this.Substring(Path, "C:\\", ".dll") + ".dll";
                }
                if (Path.Contains(".DLL"))
                {
                    imagePath = "C:\\" + this.Substring(Path, "C:\\", ".DLL") + ".dll";
                }
            }          
            return imagePath;
        }
        private string Substring(string source, string from = null, string until = null, StringComparison comparison = StringComparison.InvariantCulture)
        {
            var fromLength = (from ?? string.Empty).Length;
            var startIndex = !string.IsNullOrEmpty(from)
                ? source.IndexOf(from, comparison) + fromLength
                : 0;

            if (startIndex < fromLength) { throw new ArgumentException("from: Failed to find an instance of the first anchor"); }

            var endIndex = !string.IsNullOrEmpty(until)
            ? source.IndexOf(until, startIndex, comparison)
            : source.Length;

            if (endIndex < 0) { throw new ArgumentException("until: Failed to find an instance of the last anchor"); }

            var subString = source.Substring(startIndex, endIndex - startIndex);
            return subString;
        }
        
        #endregion
    }
}
