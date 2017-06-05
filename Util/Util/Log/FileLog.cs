using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace Util.Log
{
    public static class FileLog
    {
        public static string defaultPath = "\\Log\\";

        public static string path;
        static FileLog()
        {

        }

        public static bool WriteLog(string logType, string log)
        {
            var now = DateTime.Now;
            string realPath = path + now.Year + "\\" + now.Month + "\\";

            string fileName = now.Day + ".log";
            try
            {
                if (!Directory.Exists(realPath))
                {
                    Directory.CreateDirectory(realPath);
                }
                FileStream fs = new FileStream(realPath + fileName, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "){" + logType + "}-----" + log);
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

        public static bool WriteFatalLog(string log)
        {
            return WriteLog("FATAL", log);
        }

        public static bool WriteErrorLog(string log)
        {
            return WriteLog("ERROR", log);
        }

        public static bool WriteWarnLog(string log)
        {
            return WriteLog("WARN", log);
        }

        public static bool WriteInfoLog(string log)
        {
            return WriteLog("INFO", log);
        }

        public static bool WriteDebugLog(string log)
        {
            return WriteLog("DEBUG", log);
        }
    }
}
