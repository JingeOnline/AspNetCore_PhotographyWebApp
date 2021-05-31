using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using PhotographyWebAppCore.Models;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace PhotographyWebAppCore.Helpers
{
    public static class ImageHelper
    {
        private static string _rootPath = Environment.CurrentDirectory + "\\wwwroot";

        /// <summary>
        /// 把原始图片调整大小（大中小三种）并储存到对应的文件夹中
        /// </summary>
        /// <param name="photo"></param>
        public static void ResizeImageAndSaveCopies(this Photo photo)
        {
            string folder_big = "images\\photos_big";
            string folder_middle = "images\\photos_middle";
            string folder_small = "images\\photos_small";

            //string[] parts = photo.PhotoFile.Split('/');
            //string fileName = parts[parts.Length - 1];
            string fileName = photo.PhotoFile.FileName;
            photo.Path_Big = Path.Combine(folder_big, fileName);
            photo.Path_Middle = Path.Combine(folder_middle, fileName);
            photo.Path_Small = Path.Combine(folder_small, fileName);

            string origional_path = Path.Combine(_rootPath, photo.Path_Origional);
            using (MemoryStream stream = new MemoryStream())
            {
                photo.PhotoFile.CopyTo(stream);
                //把流的指针重新指向初始位置，因为copyto之后，指针在末尾。
                //https://github.com/SixLabors/ImageSharp/issues/901
                stream.Seek(0, 0);

                using (Image image = Image.Load(stream))
                {
                    int longEdge = (image.Width > image.Height) ? image.Width : image.Height;
                    if (longEdge > 1920)
                    {
                        double scale = longEdge / 1920;
                        int width = (int)(image.Width / scale);
                        int height = (int)(image.Height / scale);
                        image.Mutate(x => x.Resize(width, height));
                    }
                    image.Save(Path.Combine(_rootPath, folder_big, fileName));

                    if (longEdge > 960)
                    {
                        double scale = longEdge / 960;
                        int width = (int)(image.Width / scale);
                        int height = (int)(image.Height / scale);
                        image.Mutate(x => x.Resize(width, height));
                        image.Save(Path.Combine(_rootPath, folder_middle, fileName));
                    }
                    image.Save(Path.Combine(_rootPath, folder_big, fileName));

                    if (longEdge > 512)
                    {
                        double scale = longEdge / 512;
                        int width = (int)(image.Width / scale);
                        int height = (int)(image.Height / scale);
                        image.Mutate(x => x.Resize(width, height));
                        image.Save(Path.Combine(_rootPath, folder_small, fileName));
                    }
                    image.Save(Path.Combine(_rootPath, folder_small, fileName));
                }
            }
        }
    }
}
