using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace gif_to_jpg
{
    class Program
    {
        static void Main(string[] args)
        {

            string file = @"D:\USER\Desktop\gif_to_jpg\gif_to_jpg\sticker_12.gif";
            using (Image image = Image.FromFile(file))
            {
                FrameDimension fd = new FrameDimension(image.FrameDimensionsList[0]);
                int framecount = image.GetFrameCount(fd);
                string path = file.Replace(Path.GetExtension(file), "");

                //新增資料夾
                Directory.CreateDirectory(path);

                //保存圖像
                for (int i = 0; i < framecount; i++)
                {
                    image.SelectActiveFrame(fd, i);
                    image.Save(Path.Combine(path, "frame_" + i + ".jpg"), ImageFormat.Jpeg);
                }
            }
        }

    }
}
