namespace Ky.BLL
{
    using Ky.Model;
    using System;
    using System.IO;
    using System.Xml.Serialization;

    public class B_ConfigModule
    {
        public static M_ConfigModule GetConfig(string filePath)
        {
            M_ConfigModule module2;
            XmlSerializer serializer = new XmlSerializer(typeof(M_ConfigModule));
            FileStream stream = null;
            try
            {
                stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                M_ConfigModule module = serializer.Deserialize(stream) as M_ConfigModule;
                module2 = module;
            }
            catch
            {
                throw new Exception("该配置文件不存在或已经损坏");
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return module2;
        }

        public static void SaveConfig(string filePath, M_ConfigModule config)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(M_ConfigModule));
            FileStream stream = null;
            try
            {
                try
                {
                    stream = new FileStream(filePath, FileMode.Create);
                    serializer.Serialize((Stream) stream, config);
                    stream.Flush();
                }
                catch
                {
                    throw new Exception("该配置文件没有可写权限");
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }
    }
}

