using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ImageUploader.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageUploader
{
    public class ImageUploader : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;


        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion

        #region Attributes

        Cloudinary m_refCloudinary;
        string m_refLastUploadedImageURL;

        Account m_refAccount;
        string m_refCloudName = "", m_refApiKey = "", m_refApiSecret = "";    

        #endregion

        #region Properties

        public String LastUploadedImageURL
        {
            get { return m_refLastUploadedImageURL; }
            set
            {
                m_refLastUploadedImageURL = value;
                NotifyPropertyChanged("LastUploadedImageURL");
            }
        }

        public String CloudName
        {
            get { return m_refCloudName; }
            set
            {
                m_refCloudName = value;
                NotifyPropertyChanged("CloudName");
                _UpdateCredentials();
            }
        }

        public String Apikey
        {
            get { return m_refApiKey; }
            set
            {
                m_refApiKey = value;
                NotifyPropertyChanged("Apikey");
                _UpdateCredentials();
            }
        }

        public String ApiSecret
        {
            get { return m_refApiSecret; }
            set
            {
                m_refApiSecret = value;
                NotifyPropertyChanged("ApiSecret");
                _UpdateCredentials();
            }
        }

       


        #endregion

        #region Events
        
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);
        public event MessageEventHandler FileUploaded, ErrorReceived;

        #endregion

        public ImageUploader()
        {
            _UpdateCredentials();
        }

        private void _UpdateCredentials()
        {
            m_refAccount = new Account(
               m_refCloudName,
               m_refApiKey,
               m_refApiSecret);

            if (String.IsNullOrEmpty(m_refAccount.Cloud) || String.IsNullOrEmpty(m_refAccount.ApiKey) || String.IsNullOrEmpty(m_refAccount.ApiSecret))
            {
                //wait for additional account info
            }
            else
            {
                try
                {
                    m_refCloudinary = new Cloudinary(m_refAccount);
                }
                catch (Exception ex)
                {
                    //TODO
                }
               
            }
                
        }

        public void UploadImage(string filepath)
        {
             //check credentials are correctly set
            if (String.IsNullOrEmpty(m_refAccount.Cloud) || String.IsNullOrEmpty(m_refAccount.ApiKey) || String.IsNullOrEmpty(m_refAccount.ApiSecret))
            {
                //raise error message
                if (ErrorReceived != null)
                    ErrorReceived(this, new MessageEventArgs("Please verify your Cloudinary credentials before using this service."));
            }
            else
            {
                //clean file path in case it comes from an IntuiFace snapshot
                if (filepath.StartsWith("file:///"))
                {
                    filepath = filepath.Remove(0, 8);
                }


                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filepath)
                };


                Task.Factory.StartNew(() => _Upload(uploadParams));
            }
        }

        private void _Upload(ImageUploadParams uploadParams)
        {
            try
            {
                var uploadResult = m_refCloudinary.Upload(uploadParams);
                if (uploadResult != null)
                {
                    //Save last uploaded image URL
                    LastUploadedImageURL = uploadResult.Uri.AbsoluteUri;

                    //Raise trigger
                    //TODO: add URL as trigger parameter
                    if (FileUploaded != null)
                        FileUploaded(this, new MessageEventArgs(LastUploadedImageURL));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Upload error: " + ex.Message);               
            }
          
        }
    }
}
