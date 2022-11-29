using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PayrollWeb.Models
{
    public class CompanyDetailViewModel
    {
        [Required]
        [RegularExpression(@"\d\d-\d{7}", ErrorMessage = "Invalid format")]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Government Tax Id", Prompt = "Name")]
        [RegularExpression(@"[\w\s-'&]{2,30}", ErrorMessage = "Invalid name format")]
        public string TaxId { get; set; }


        public string Name { get; set; }

        [Required]
        [Display(Name = "Street Address", Prompt = "Address")]
        [RegularExpression(@"[\w\s-'&]{2,30}", ErrorMessage = "Invalid address format")]
        public string StreetAddress { get; set; }    
    }
}
