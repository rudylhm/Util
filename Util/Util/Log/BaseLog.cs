using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Log
{
    public abstract class BaseLog
    {
        public virtual bool WriteFatalLog(string log)
        {
            return WriteLog("FATAL", log);
        }

        public virtual bool WriteErrorLog(string log)
        {
            return WriteLog("ERROR", log);
        }

        public virtual bool WriteWarnLog(string log)
        {
            return WriteLog("WARN", log);
        }

        public virtual bool WriteInfoLog(string log)
        {
            return WriteLog("INFO", log);
        }

        public virtual bool WriteDebugLog(string log)
        {
            return WriteLog("DEBUG", log);
        }

        protected abstract bool WriteLog(string logType, string log);
    }
}
