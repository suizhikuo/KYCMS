namespace Ky.BLL
{
    using System;
    using System.IO;
    using System.Web;

    public class B_FileCheck
    {
        public bool FileCheck(string FilePath)
        {
            string path = HttpContext.Current.Server.MapPath(FilePath) + "/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "";
            try
            {
                Directory.CreateDirectory(path);
                Directory.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void FolderDel(string FilePath)
        {
            string path = HttpContext.Current.Server.MapPath(FilePath);
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }
    }
}

