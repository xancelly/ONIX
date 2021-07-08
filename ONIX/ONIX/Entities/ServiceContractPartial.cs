using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIX.Entities
{
    public partial class ServiceContract
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
                var Specification = AppData.Context.ServiceContractSpecification.Where(c => c.IdServiceContract == Id).ToList();
                decimal TotalCost = 0;
                foreach (var item in Specification)
                {
                    decimal NDS = Convert.ToDecimal(AppData.Context.ServiceNDS.OrderByDescending(c => c.Date).Where(c => c.Date <= Date && c.IdService == item.Service.Id).Select(c => c.NDS).FirstOrDefault());
                    decimal Price = Convert.ToDecimal(AppData.Context.ServicePrice.OrderByDescending(c => c.Date).Where(c => c.Date <= Date && c.IdService == item.Service.Id).Select(c => c.Price).FirstOrDefault() * item.Count);
                    TotalCost += Price + ((Price * NDS) / 100);
                }
                return TotalCost;
            }
        }

        public string GetService
        {
            get
            {
                var Specification = AppData.Context.ServiceContractSpecification.Where(c => c.IdServiceContract == Id).ToList();
                string ServiceString = "";
                foreach (var item in Specification)
                {
                    ServiceString += $"{item.Service.Name}, ";
                }
                ServiceString = ServiceString.Substring(0, ServiceString.Length - 2);
                return ServiceString;
            }
        }

        public decimal GetSumWithoutNDS
        {
            get
            {
                var Specification = AppData.Context.ServiceContractSpecification.Where(c => c.IdServiceContract == Id).ToList();
                decimal TotalCost = 0;
                foreach (var item in Specification)
                    TotalCost += Convert.ToDecimal(AppData.Context.ServicePrice.OrderByDescending(c => c.Date).Where(c => c.Date <= Date && c.IdService == item.Service.Id).Select(c => c.Price).FirstOrDefault() * item.Count);
                return TotalCost;
            }
        }
        public decimal GetSumNDS
        {
            get
            {
                var Specification = AppData.Context.ServiceContractSpecification.Where(c => c.IdServiceContract == Id).ToList();
                decimal TotalNDS = 0;
                foreach (var item in Specification)
                {
                    decimal NDS = Convert.ToDecimal(AppData.Context.ServiceNDS.OrderByDescending(c => c.Date).Where(c => c.Date <= Date && c.IdService == item.Service.Id).Select(c => c.NDS).FirstOrDefault());
                    decimal Price = Convert.ToDecimal(AppData.Context.ServicePrice.OrderByDescending(c => c.Date).Where(c => c.Date <= Date && c.IdService == item.Service.Id).Select(c => c.Price).FirstOrDefault() * item.Count);
                    TotalNDS += (Price * NDS) / 100;
                }
                return TotalNDS;
            }
        }
    }
}
