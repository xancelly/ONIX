using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIX.Entities
{
    public partial class SaleContractSpecification
    {
        public string GetSumGood
        {
            get
            {
                decimal Price = Good.GetLastPrice;
                decimal NDS = Good.GetLastNDS;
                return Math.Round((Count * (Price + (Price * NDS / 100))), 2).ToString();
            }
        }
    }
}
