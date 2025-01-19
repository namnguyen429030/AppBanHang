using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanHang.Utilities
{
    public static class FileHelper
    {
        public static async Task<string> SaveFile(byte[] imageContent, string folderName, string fileName)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string assetsDirectory = Path.Combine(baseDirectory, folderName);
            if (!Directory.Exists(assetsDirectory))
            {
                Directory.CreateDirectory(assetsDirectory);
            }

            string filePath = Path.Combine(assetsDirectory, fileName);
                 
            await File.WriteAllBytesAsync(filePath, imageContent);

            return filePath;
        }
    }
}
