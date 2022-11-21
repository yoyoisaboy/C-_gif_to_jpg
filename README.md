C# GIF to JPG 

紀錄將 gif 檔 切成 JPG 。就醬....
注意:
如果Image有問題可能是 System.Drawing.Common沒更新到6.0.0，如果是6.0.0以上好像就不能用了(好爛= =)

```
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string file = @".\giphy.gif";
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
```

