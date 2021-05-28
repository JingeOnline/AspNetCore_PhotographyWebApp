using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace PhotographyWebAppCore.Helpers
{
    public class ImageHelper
    {
        private readonly string _rootPath;

        public ImageHelper(IWebHostEnvironment webHostEnvironment)
        {
            _rootPath = webHostEnvironment.WebRootPath;
        }

        /// <summary>
        /// 把原始图片调整大小（大中小三种）并储存到本地硬盘中
        /// </summary>
        /// <param name="filePath"></param>
        public void ResizeImageAndSave(string filePath)
        {
            string folder_big = "images/photos_big";
            string folder_middle = "images/photos_middle";
            string folder_small = "images/photos_small";

            string[] parts = filePath.Split('/');
            string fileName = parts[parts.Length - 1];

            using (Image image = Image.Load(filePath))
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
