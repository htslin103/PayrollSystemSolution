using Microsoft.AspNetCore.Mvc.Rendering;

namespace PayrollWeb.Models
{
    public class GenericListModel
    {
        public GenericListModel()
        { }

        public GenericListModel(IEnumerable<(int id, string name)> items)
        {
            Items = items.Select(e => new SelectListItem(e.name, e.id.ToString()));
        }

        public int SelectedItemId {get; set; }
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}