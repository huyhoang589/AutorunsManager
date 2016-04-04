using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;
using RegistryInfo;
using ImageInformation;
using System.Threading;

namespace AutorunsManager.Main
{
    class ImageScanner
    {
        #region PARAMS
        //HKCU Run
        private List<ImageInfo> lst_HKCU_Run;
        private ImageList lstImg_HKCU_Run;
        //HKCU RunOnce
        private List<ImageInfo> lst_HKCU_RunOnce;
        private ImageList lstImg_HKCU_RunOnce;
        //HKLM Run32
        private List<ImageInfo> lst_HKLM_Run32;
        private ImageList lstImg_HKLM_Run32;
        //HKLM Run64
        private List<ImageInfo> lst_HKLM_Run64;
        private ImageList lstImg_HKLM_Run64;
        //HKLM RunOnce32
        private List<ImageInfo> lst_HKLM_RunOnce32;
        private ImageList lstImg_HKLM_RunOnce32;
        //HKLM RunOnce64
        private List<ImageInfo> lst_HKLM_RunOnce64;
        private ImageList lstImg_HKLM_RunOnce64;
        //HKLM Services
        private List<ImageInfo> lst_HKLM_Serv;
        private ImageList lstImg_HKLM_Serv;
        //HKCR DLL
        private List<ImageInfo> lst_HKCR_DLLs;
        private ImageList lstImg_HKCR_DLLs;

        //Threads
        private Thread th_HKCU_Run;
        private Thread th_HKCU_RunOnce;
        private Thread th_HKLM_Run32;
        private Thread th_HKLM_Run64;
        private Thread th_HKLM_RunOnce32;
        private Thread th_HKLM_RunOnce64;
        private Thread th_HKLM_Serv;
        private Thread th_HKCR_DLLs;
       
        #endregion

        #region CONSTRUCTORS
        public ImageScanner()
        {
            #region Init params
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
            
            #endregion

            #region Threads
            // Create Threads
           ThreadStart thStart_HKCU_Run = new ThreadStart(this.load_HKCU_Run);
           ThreadStart thStart_HKCU_RunOnce = new ThreadStart(this.load_HKCU_RunOnce);
           ThreadStart thStart_HKLM_Run32 = new ThreadStart(this.load_HKLM_Run32);
           ThreadStart thStart_HKLM_Run64 = new ThreadStart(this.load_HKLM_Run64);
           ThreadStart thStart_HKLM_RunOnce32 = new ThreadStart( this.load_HKLM_RunOnce32);
           ThreadStart thStart_HKLM_RunOnce64 = new ThreadStart( this.load_HKLM_RunOnce64);
           ThreadStart thStart_HKLM_Serv = new ThreadStart(this.load_HKLM_Services);
           ThreadStart thStart_HKCR_DLLs = new ThreadStart( this.load_HKCR_DLLs);

           th_HKCU_Run = new Thread(thStart_HKCU_Run);
           th_HKCU_RunOnce = new Thread(thStart_HKCU_RunOnce);
           th_HKLM_Run32 = new Thread(thStart_HKLM_Run32);
           th_HKLM_Run64 = new Thread(thStart_HKLM_Run64);
           th_HKLM_RunOnce32 = new Thread(thStart_HKLM_RunOnce32);
           th_HKLM_RunOnce64 = new Thread(thStart_HKLM_RunOnce64);
           th_HKLM_Serv = new Thread(thStart_HKLM_Serv);
           th_HKCR_DLLs = new Thread(thStart_HKCR_DLLs);
            #endregion
        }
        public void Start()
        {
            try
            {
                this.threads_Start();
                this.threads_End();                  
            }
            catch(Exception e)
            {
                 MessageBox.Show("ImageScanner _ An exception has occured!  " + e.Message);
            }            
        }
        #endregion

        #region GET
        //HKCU Run
        public List<ImageInfo> get_lst_HKCU_Run()
        {
            return lst_HKCU_Run;                 
        }
        public ImageList get_lstImage_HKCU_Run()
        {
            return lstImg_HKCU_Run;        
        }
        //HKCU RunOnce
        public List<ImageInfo> get_lst_HKCU_RunOnce()
        {
            return lst_HKCU_RunOnce;
        }
        public ImageList get_lstImage_HKCU_RunOnce()
        {
            return lstImg_HKCU_RunOnce;
        }
        //HKLM Run32
        public List<ImageInfo> get_lst_HKLM_Run32()
        {
            return lst_HKLM_Run32;
        }
        public ImageList get_lstImage_HKLM_Run32()
        {
            return lstImg_HKLM_Run32;
        }
        //HKLM Run64
        public List<ImageInfo> get_lst_HKLM_Run64()
        {
            return lst_HKLM_Run64;
        }
        public ImageList get_lstImage_HKLM_Run64()
        {
            return lstImg_HKLM_Run64;
        }
        //HKLM RunOnce32
        public List<ImageInfo> get_lst_HKLM_RunOnce32()
        {
            return lst_HKLM_RunOnce32;
        }
        public ImageList get_lstImage_HKLM_RunOnce32()
        {
            return lstImg_HKLM_RunOnce32;
        }
        //HKLM RunOnce64
        public List<ImageInfo> get_lst_HKLM_RunOnce64()
        {
            return lst_HKLM_RunOnce64;
        }
        public ImageList get_lstImage_HKLM_RunOnce64()
        {
            return lstImg_HKLM_RunOnce64;
        }
        //HKLM  Services
        public List<ImageInfo> get_lst_HKLM_Serv()
        {
            return lst_HKLM_Serv;
        }
        public ImageList get_lstImage_HKLM_Serv()
        {
            return lstImg_HKLM_Serv;
        }
        //HKCR DLL
        public List<ImageInfo> get_lst_HKCR_DLLs()
        {
            return lst_HKCR_DLLs;
        }
        public ImageList get_lstImage_HKCR_DLLs()
        {
            return lstImg_HKCR_DLLs;
        }
        #endregion

        #region PRIVATE METHODS
        private void load_HKCU_Run()
        {
            HKCurrentUser CU_Run = new HKCurrentUser();
            CU_Run.load_HKCU_Run();
            lst_HKCU_Run = CU_Run.get_HKCU_Run();
            lstImg_HKCU_Run = get_imgLst_from_lstImgInfo(lst_HKCU_Run);
            check_InvalidImage(AutorunsManager.invalidImages, lst_HKCU_Run);
            check_missImage(lst_HKCU_Run);
        }
        private void load_HKCU_RunOnce()
        {
            HKCurrentUser CU_RunOnce = new HKCurrentUser();
            CU_RunOnce.load_HKCU_RunOnce();
            lst_HKCU_RunOnce = CU_RunOnce.get_HKCU_RunOnce();
            lstImg_HKCU_RunOnce = get_imgLst_from_lstImgInfo(lst_HKCU_RunOnce);
            check_InvalidImage(AutorunsManager.invalidImages, lst_HKCU_RunOnce);
            check_missImage(lst_HKCU_RunOnce);
        }
        private void load_HKLM_Run32()
        {
            HKLocalMachine LM_Run32 = new HKLocalMachine();
            LM_Run32.load_HKLM_Run_32();
            lst_HKLM_Run32 = LM_Run32.get_HKLM_Run_32();
            lstImg_HKLM_Run32 = get_imgLst_from_lstImgInfo(lst_HKLM_Run32);
            check_InvalidImage(AutorunsManager.invalidImages, lst_HKLM_Run32);
            check_missImage(lst_HKLM_Run32);
        }
        private void load_HKLM_Run64()
        {
            HKLocalMachine LM_Run64 = new HKLocalMachine();
            LM_Run64.load_HKLM_Run_64();
            lst_HKLM_Run64 = LM_Run64.get_HKLM_Run_64();
            lstImg_HKLM_Run64 = get_imgLst_from_lstImgInfo(lst_HKLM_Run64);
            check_InvalidImage(AutorunsManager.invalidImages, lst_HKLM_Run64);
            check_missImage(lst_HKLM_Run64);
        }
        private void load_HKLM_RunOnce32()
        {
            HKLocalMachine LM_RunOnce32 = new HKLocalMachine();
            LM_RunOnce32.load_HKLM_RunOnce_32();
            lst_HKLM_RunOnce32 = LM_RunOnce32.get_HKLM_RunOnce_32();
            lstImg_HKLM_RunOnce32 = get_imgLst_from_lstImgInfo(lst_HKLM_RunOnce32);
            check_InvalidImage(AutorunsManager.invalidImages, lst_HKLM_RunOnce32);
            check_missImage(lst_HKLM_RunOnce32);
        }
        private void load_HKLM_RunOnce64()
        {
            HKLocalMachine LM_RunOnce64 = new HKLocalMachine();
            LM_RunOnce64.load_HKLM_RunOnce_64();
            lst_HKLM_RunOnce64 = LM_RunOnce64.get_HKLM_RunOnce_64();
            lstImg_HKLM_RunOnce64 = get_imgLst_from_lstImgInfo(lst_HKLM_RunOnce64);
            check_InvalidImage(AutorunsManager.invalidImages, lst_HKLM_RunOnce64);
            check_missImage(lst_HKLM_RunOnce64);
        }
        private void load_HKLM_Services()
        {
            HKLocalMachine LM_Serv = new HKLocalMachine();
            LM_Serv.load_HKLM_Services();
            lst_HKLM_Serv = LM_Serv.get_HKLM_Services();
            lstImg_HKLM_Serv = get_imgLst_from_lstImgInfo(lst_HKLM_Serv);
            check_InvalidImage(AutorunsManager.invalidImages, lst_HKLM_Serv);
            check_missImage(lst_HKLM_Serv);
        }
        private void load_HKCR_DLLs()
        {
            HKClassesRoot CR_DLL = new HKClassesRoot();
            CR_DLL.load_HKCU_DLL();
            lst_HKCR_DLLs = CR_DLL.get_HKCR_DLL();
            Icon DllsIcon = Properties.Resources.dll;
            foreach (ImageInfo img in lst_HKCR_DLLs)
            {
                lstImg_HKCR_DLLs.Images.Add(img.get_imageName(), DllsIcon);
            }
            check_missImage(lst_HKCR_DLLs);            
        }
        private void threads_Start()
        {
            th_HKCU_Run.Start();
            th_HKCU_RunOnce.Start();
            th_HKLM_Run32.Start();
            th_HKLM_Run64.Start();
            th_HKLM_RunOnce32.Start();
            th_HKLM_RunOnce64.Start();
            th_HKLM_Serv.Start();
            th_HKCR_DLLs.Start();
        }
        private void threads_End()
        {
            th_HKCU_Run.Join();
            th_HKCU_RunOnce.Join();
            th_HKLM_Run32.Join();
            th_HKLM_Run64.Join();
            th_HKLM_RunOnce32.Join();
            th_HKLM_RunOnce64.Join();
            th_HKLM_Serv.Join();
            th_HKCR_DLLs.Join();
        }      
        private static ImageList get_imgLst_from_lstImgInfo(List<ImageInfo> lstImageInfo)
        {
            ImageList lstImage = new ImageList();
            foreach (ImageInfo image in lstImageInfo)
            {
                Icon fileIcon = Properties.Resources.invalid;
                if(image.get_imagePath() != null)
                {
                    fileIcon = Icon.ExtractAssociatedIcon(image.get_imagePath());
                    lstImage.Images.Add(image.get_imageName(), fileIcon);
                }          
                else
                {
                   lstImage.Images.Add(image.get_imageName(), fileIcon);
                   AutorunsManager.invalidImages.Add(image.get_imageName());
                }
            }
            return lstImage;
        }
        private void check_InvalidImage(List<string>invalidImages, List<ImageInfo>lst_imgInfo)
        {
            foreach (ImageInfo img in lst_imgInfo)
            {
                foreach(string inval in invalidImages)
                {
                    if(img.get_imageName() == inval)
                    {
                        img.set_imageStatus("invalid");
                    }
                }                
            }
        }
        private void check_missImage(List<ImageInfo> lst_imgInfo)
        {
            foreach(ImageInfo img in lst_imgInfo)
            {
                if(img.get_imageStatus() != "invalid")
                {
                    if ((img.get_imageName() == "") || (img.get_imageName() == " ") || (img.get_imageName() == null))
                    {
                        img.set_imageStatus("miss");
                    }
                    if ((img.get_imageDescription() == "") || (img.get_imageDescription() == " ") || (img.get_imageDescription() == null))
                    {
                        img.set_imageStatus("miss");
                    }
                    if ((img.get_publisher() == "") || (img.get_publisher() == " ") || (img.get_publisher() == null))
                     {
                         img.set_imageStatus("miss");
                     }
                    if ((img.get_imagePath() == "") || (img.get_imagePath() == " ") || (img.get_imagePath() == null))
                     {
                         img.set_imageStatus("miss");
                     }             
                }// end If        
            }
        }
        #endregion
    }//END Class
}
