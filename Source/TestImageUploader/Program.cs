using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageUploader;

namespace TestImageUploader
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageUploader.ImageUploader iu = new ImageUploader.ImageUploader();
            //Enter below your Cloudinary Credentials to make your tests. 
            iu.CloudName = "";
            iu.Apikey = "";
            iu.ApiSecret = "";

            //Check you have this image on your hard drive or replace it with an existing and correct URI
            iu.UploadImage("file:///c:/temp/Koala.jpg");

            Console.ReadKey();
        }
    }
}
