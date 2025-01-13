using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.BL.Helpers
{
    public static class FileManager
    {
        public static string UploadImage(this IFormFile formFile, string envpath, string folder)
        {

            string path = envpath + folder;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filename = Path.GetFileNameWithoutExtension(formFile.FileName);
            if (filename.Length > 50)
            {
                filename.Substring(0, 79);
            }
            filename = Guid.NewGuid().ToString() + formFile.FileName + Path.GetExtension(formFile.FileName);
            using (FileStream fileStream = new FileStream(path + filename, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            return filename;
        }

    }
}
