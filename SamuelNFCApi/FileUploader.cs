using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SamuelNFCApi
{
    public class FileUploader
    {
        public static void UploadFTPFile(
            string fileName, int lastIdInserted, HttpPostedFile file, string folderPath)
        {
            string FileExt = Path.GetExtension(fileName).ToUpper();
            string fullPath = Path.Combine(folderPath, lastIdInserted.ToString() + FileExt);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            file.SaveAs(fullPath);
        }

        public static void UploadFTPFile(
            string fileName, string name, HttpPostedFile file, string folderPath)
        {
            string FileExt = Path.GetExtension(fileName).ToUpper();
            string fullPath = Path.Combine(folderPath, name.ToString() + FileExt);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            file.SaveAs(fullPath);
        }

        public static void DeleteFTPFile(int imageId, string folderPath)
        {
            string fullPath = Path.Combine(folderPath, imageId.ToString() + ".PDF");
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
        }
    }
}