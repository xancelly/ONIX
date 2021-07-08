using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIX.Entities
{
    public partial class ServiceContractSpecification
    {
        public string GetSumService
        {
            get
            {
                decimal Price = Service.GetLastPrice;
                decimal NDS = Service.GetLastNDS;
                return Math.Round((decimal)(Count * (Price + (Price * NDS / 100))), 2).ToString();
            }
        }
    }
}
