using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImageInformation;

namespace AutorunsManager
{
    public partial class form_Properties : Form
    {
        #region CONSTRUCTOR
        public form_Properties()
        {
            InitializeComponent();
            this.labelFileName.Text = "";
            this.labelCompany.Text = "";
            this.labelFileVer.Text = "";
            this.labelInternalName.Text = "";
            this.labelOriginName.Text = "";
            this.labelProductName.Text = "";
            this.labelProductVer.Text = "";
            this.textBoxCopyright.Text = ""; this.textBoxCopyright.ReadOnly = true;
            this.textBoxDescription.Text = ""; this.textBoxDescription.ReadOnly = true;
        }
        #endregion

        #region GUI EVENTS
        private void form_Properties_Load(object sender, EventArgs e)
        {
            form_load();
        }
        #endregion

        #region METHODS
        private void form_load()
        {
            string fileName = AutorunsManager.selectedFileName;
            tabPageProperty.Text = fileName;
            tabProperties.ImageList = AutorunsManager.lstImg_everything;
            int imageIndex = AutorunsManager.lstImg_everything.Images.IndexOfKey(fileName);
            tabPageProperty.ImageIndex = imageIndex;          
           
            foreach (ImageInfo img in AutorunsManager.lst_everything)
            {
                if (img.get_imageName() == fileName)
                {
                    this.labelFileName.Text = img.get_imageName();     
                    this.labelCompany.Text = img.get_publisher();       
                    this.labelFileVer.Text = img.get_fileVersion();         
                    this.labelInternalName.Text = img.get_internalName();
                    this.labelOriginName.Text = img.get_originalName(); 
                    this.labelProductName.Text = img.get_productName(); 
                    this.labelProductVer.Text = img.get_productVersion();  
                    this.textBoxCopyright.Text = img.get_copyright();
                    this.textBoxDescription.Text = img.get_imageDescription();
                            
                }//END if
            }
            tabProperties.SizeMode = TabSizeMode.Fixed;
            tabProperties.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            textBoxCopyright.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            textBoxDescription.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            
        }
       
        #endregion
    }
}
