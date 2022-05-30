using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Practice_Front_to_Back.Utilities.Extension
{
    public static class FileExtension
    {
        public static bool Checksize(this IFormFile file, int kb)
        {
            if (file.Length / 1024 > kb) return true;
            return false;
        }
        public static bool CheckType(this IFormFile file, string type)
        {
            if (file.ContentType.Contains(type)) return true;
            return false;
        }
        public async static  Task<string> SaveFileAsync(this IFormFile file,string save)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(save, fileName);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
