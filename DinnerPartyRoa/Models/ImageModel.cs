using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace DinnerPartyRoa.Models
{
    public class ImageModel
    {
        public byte[] ImageToByteArray(string imagepath)
        {
            Image image = Image.FromFile(imagepath);
            byte[] imageByte = ImageToByteArraybyMemoryStream(image);
            return imageByte;
        }

        private byte[] ImageToByteArraybyMemoryStream(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}