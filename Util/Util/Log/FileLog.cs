using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace Util.Log
{
    public class FileLog : BaseLog
    {
        private static string defaultPath = "\\Log\\";
        private static string path = "";
        private static string fileName;
        public FileLog() : this(defaultPath)
        {
        }

        public FileLog(string savePath)
        {
            var now = DateTime.Now;
            string datePath = now.Year + "\\" + now.Month + "\\";
            fileName = now.Day + ".log";
        }

        protected override bool WriteLog(string logType, string log)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                FileStream fs = new FileStream(path + fileName, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write("(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "){" + logType + "}-----" + log);
                sw.Flush();
                sw.Close();
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
