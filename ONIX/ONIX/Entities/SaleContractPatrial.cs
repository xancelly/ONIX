    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ONIX.Entities
{
    public partial class SaleContract
    {
        public string GetOrganization
        {
            get
            {
                return $"{Organization.TypeOrganization.Name} «{Organization.Name}»";
            }
        }

        public string GetEmployee
        {
            get
            {
                return $"{Employee.LastName} {Employee.FirstName} {Employee.MiddleName}";
            }
        }

        public decimal GetSumWithNDS
        {
            get
            {
                var Specification = AppData.Context.SaleContractSpecification.Where(c => c.IdSaleContract == Id).ToList();
                decimal TotalCost = 0;
                foreach (var item in Specification)
                {
                    decimal NDS = Convert.ToDecimal(AppData.Context.GoodNDS.OrderByDescending(c => c.Date).Where(c => c.Date <= Date && c.IdGood == item.Good.Id).Select(c => c.NDS).FirstOrDefault());
                    decimal Price = Convert.ToDecimal(AppData.Context.GoodPrice.OrderByDescending(c => c.Date).Where(c => c.Date <= Date && c.IdGood == item.Good.Id).Select(c => c.Price).FirstOrDefault() * item.Count);
                    TotalCost += Price + ((Price * NDS) / 100);
                }
                return TotalCost;
            }
        }

        public decimal GetSumWithoutNDS
        {
            get
            {
                var Specification = AppData.Context.SaleContractSpecification.Where(c => c.IdSaleContract == Id).ToList();
                decimal TotalCost = 0;
                foreach (var item in Specification)
                    TotalCost += Convert.ToDecimal(AppData.Context.GoodPrice.OrderByDescending(c => c.Date).Where(c => c.Date <= Date && c.IdGood == item.Good.Id).Select(c => c.Price).FirstOrDefault() * item.Count);
                return TotalCost;
            }
        }

        public decimal GetSumNDS
        {
            get
            {
                var Specification = AppData.Context.SaleContractSpecification.Where(c => c.IdSaleContract == Id).ToList();
                decimal TotalNDS = 0;
                foreach (var item in Specification)
                {
                    decimal NDS = Convert.ToDecimal(AppData.Context.GoodNDS.OrderByDescending(c => c.Date).Where(c => c.Date <= Date && c.IdGood == item.Good.Id).Select(c => c.NDS).FirstOrDefault());
                    decimal Price = Convert.ToDecimal(AppData.Context.GoodPrice.OrderByDescending(c => c.Date).Where(c => c.Date <= Date && c.IdGood == item.Good.Id).Select(c => c.Price).FirstOrDefault() * item.Count);
                    TotalNDS += (Price * NDS) / 100;
                }
                return TotalNDS;
            }
        }

    }
}
