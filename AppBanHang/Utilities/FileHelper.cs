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
            string baseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string assetsDirectory = Path.Combine(baseDirectory, folderName);
            if (!Directory.Exists(assetsDirectory))
            {
                Directory.CreateDirectory(assetsDirectory);
            }

            string filePath = Path.Combine(assetsDirectory, fileName);
                 
            await File.WriteAllBytesAsync(filePath, imageContent);

            return filePath;
        }
        public static byte[] GetBytesFromPath(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            {
                using(var read = new BinaryReader(stream))
                {
                    return read.ReadBytes((int)stream.Length);
                }
            }
        }
    }
}
