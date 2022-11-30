using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PayrollWeb.Models
{
    public class CompanyDetailViewModel
    {
        public CompanyDetailViewModel() { }
        public CompanyDetailViewModel(int id, (string taxid, string name, string address) comp) 
        { 
            Id = id;
            TaxId = comp.taxid;
            Name = comp.name;
            StreetAddress = comp.address;
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Government Tax Id", Prompt = "Name")]
        [RegularExpression(@"\d\d-\d{7}", ErrorMessage = "Invalid format")]
        public string TaxId { get; set; }

        [Required]
        [RegularExpression(@"[\w\s-'&]{2,30}", ErrorMessage = "Invalid name format")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Street Address", Prompt = "Address")]
        [RegularExpression(@"[\w\s-'&]{2,30}", ErrorMessage = "Invalid address format")]
        public string StreetAddress { get; set; }    
    }
}
