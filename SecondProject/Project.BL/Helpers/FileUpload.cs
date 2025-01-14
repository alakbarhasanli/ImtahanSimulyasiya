using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Helpers
{
    public static class FileUpload
    {
        public static bool CheckType(this IFormFile formFile) => formFile.ContentType.Contains("image");
        public static bool CheckSize(this IFormFile formFile, int size)
        {
            if (formFile.Length > size * 1024 * 1024)
            {
                return false;
            }
            return true;
        }
        public static async Task<string> UploadImage(this IFormFile formFile, string envpath, params string[] folders)
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
            string filename = Path.GetFileNameWithoutExtension(formFile.FileName);
            if (filename.Length > 50)
            {
                filename.Substring(0, 79);
            }
            filename = filename + Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
            uploadPath = Path.Combine(uploadPath, filename);

            using var stream = new FileStream(uploadPath, FileMode.Create);
            await formFile.CopyToAsync(stream);

            return filename;

        }

    }
}
