using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Factory
{
    public class YXTCenterEntitiesFactory
    {
        public static YXTCenterEntities CreateYXTCenterEntities()
        {
            return new YXTCenterEntities();
        }
    }
}
