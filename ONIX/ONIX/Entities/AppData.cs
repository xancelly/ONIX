using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIX.Entities
{
    public class AppData
    {
        public static ONIX_DATABASEEntities Context
        {
            get; set;
        } = new ONIX_DATABASEEntities();
    }
}
