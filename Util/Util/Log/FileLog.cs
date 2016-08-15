﻿using System;
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
        private static string path;
        public FileLog() : this(defaultPath)
        {

        }

        public FileLog(string savePath)
        {
            var now = DateTime.Now;
            string datePath = now.Year + "\\" + now.Month + "\\" + now.Day + ".log";
            string realPath = HttpContext.Current.Server.MapPath(savePath + datePath);

        }

        protected override bool WriteLog(string logType, string log)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write("{" + logType + "}-----" + log);
                sw.Flush();
                sw.Close();
                fs.Close();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


    }
}