using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PayrollSystem
{
    public class PaySystemService : IPaySystemService
    {
        List<(int id, string taxid, 
            string name, string address)> comps;
        public PaySystemService()
        {
            comps = new List<(int id, string taxid, string name, string address)>()
            {
                (1, "12-1234567", "Acme", "123 Easy"),
                (2, "12-1444444", "Jones", "123 Hard"), 
                (3, "12-1555555", "Smith Supply", "123 Moderate")
            };
        }

        public IEnumerable<(int id, string name)> GetAllCompanies()
        {
            return comps.Select(c => (c.id, c.name));
        }

        public void SaveCompanyDetail(int id, string taxId, string name, string address)
        {
            //Do nothing for now
        }

        public (string taxid, string name, string address) GetCompanyDetail(int id)
        {
            var comp = comps[id - 1];
            return (comp.taxid, comp.name, comp.address);
        }
    }
}
