using Microsoft.AspNetCore.Mvc.Rendering;

namespace PayrollWeb.Models
{
    public class CompanyListModel
    {
        public CompanyListModel()
        {        }

        public CompanyListModel(IEnumerable<(int id, string name)> comps)
        {
            Companies = comps.Select(c => new SelectListItem(c.name, c.id.ToString()));
            SelectedCompanyId = -1;
        }

        public int SelectedCompanyId {get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }

    }
}
