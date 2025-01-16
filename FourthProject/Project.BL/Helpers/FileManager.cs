using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Helpers
{
    public static class FileManager
    {
        public static async Task<string> ImageUpload(this IFormFile formfile, string envpath, params string[] folders)
        {
            string uploadPath = envpath;
            string path = string.Empty;
            foreach (var folder in folders)
            {
                path = Path.Combine(path, folder);
            }
            uploadPath = uploadPath + "/" + path;
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            string filename = Path.GetFileNameWithoutExtension(formfile.FileName);
            if (filename.Length > 50)
            {
                filename.Substring(0, 79);
            }
            filename = filename + Guid.NewGuid().ToString() + Path.GetExtension(formfile.FileName);
            string mainpath = Path.Combine(uploadPath, filename);
            using var stream = new FileStream(mainpath, FileMode.Create);
            await formfile.CopyToAsync(stream);
            return filename;
        }
    }
}
