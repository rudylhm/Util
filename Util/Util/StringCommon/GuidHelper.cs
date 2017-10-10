using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.StringCommon
{
    public class GuidHelper
    {
        public static string GetNewGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
