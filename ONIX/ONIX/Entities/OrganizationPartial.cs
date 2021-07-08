using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONIX.Entities
{
    public partial class Organization
    {
        public string GetName
        {
            get
            {
                if (TypeOrganization != null)
                {
                    return $"{TypeOrganization.Name} «{Name}»";
                }
                else
                {
                    return $"{Name}";
                } 
            }
        }

        public string CountDocuments
        {
            get
            {
                int CountGoodDocuments = AppData.Context.SaleContract.Where(c => c.IdOrganization == Id).ToList().Count;
                int CountServiceDocuments = AppData.Context.ServiceContract.Where(c => c.IdOrganization == Id).ToList().Count;
                return $"{CountGoodDocuments + CountServiceDocuments}";
            }
        }
    }
}
