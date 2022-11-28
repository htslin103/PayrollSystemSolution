using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem
{
    public class PaySystemService : IPaySystemService
    {
        public (string taxid, string name, string address) GetCompanyDetail(int id)
        {
            return ("123", "Acme", "123 Easy");
        }

        public void SaveCompanyDetail(int id, string taxId, string name, string address)
        {
            //Do nothing 
        }
    }
}
