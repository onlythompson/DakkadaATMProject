using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DakkadaATM
{
    public class ImageProcessingEngine
    {
        public byte[] getResizedImage(string path, int width, int height)
        {
            Image inputImg = Image.FromFile(path);
            int resizedHeight = inputImg.Height;
            int resizedWidth = inputImg.Width;


            resizedHeight = (resizedHeight * width) / resizedWidth;
            resizedWidth = width;

            if (resizedHeight > height)
            {
                resizedWidth = (resizedWidth * height) / resizedHeight;
                resizedHeight = height;
            }

            Bitmap bitmapImg = new Bitmap(inputImg, resizedWidth, resizedHeight);

            MemoryStream ms = new MemoryStream();

            bitmapImg.Save(ms, ImageFormat.Jpeg);


            byte[] ouptputImg = ms.ToArray();

            return ouptputImg;

        }


        //public void ReadFromDb(Guid id)
        //{

        //    CustomerPic SampleCustomer;

        //    using (var context = new PicsDbContext())
        //    {
        //        SampleCustomer = context.CustomerPics.Find(id);
        //    }

        //    MemoryStream ms = new MemoryStream(SampleCustomer.Photo);

        //    RPhoto.Image = Image.FromStream(ms);

        //}

    }
}
