namespace Ky.BLL
{
    using System;
    using System.Data;
    using System.IO;

    public class B_ViewFile
    {
        private DataTable CreateDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Path", typeof(string));
            table.Columns.Add("UpdateTime", typeof(string));
            table.Columns.Add("Type", typeof(string));
            return table;
        }

        public DataTable GetFileList(string dirPath)
        {
            DataRow row;
            DataTable table = this.CreateDataTable();
            string[] directories = Directory.GetDirectories(dirPath);
            string[] files = Directory.GetFiles(dirPath);
            foreach (string str in directories)
            {
                DirectoryInfo info = new DirectoryInfo(str);
                row = table.NewRow();
                row["Name"] = info.Name;
                row["Path"] = str;
                row["UpdateTime"] = info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                row["Type"] = "";
                table.Rows.Add(row);
                info = null;
            }
            foreach (string str in files)
            {
                FileInfo info2 = new FileInfo(str);
                row = table.NewRow();
                row["Name"] = info2.Name;
                row["Path"] = str;
                row["UpdateTime"] = info2.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                row["Type"] = Path.GetExtension(str).ToLower();
                table.Rows.Add(row);
                info2 = null;
            }
            return table;
        }
    }
}

