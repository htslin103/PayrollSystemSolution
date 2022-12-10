using System.ComponentModel.DataAnnotations;

namespace PayrollWeb.Models
{
    public class EmployeeDetailModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"[\d\d\d-\d\d\d]")]
        public string EmpId { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z\s.'-]{2,30}")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z\s.'-]{2,30")]
        public string LastName { get; set; }

        [Required]
        [Range(100, 2000)]
        public float Salary { get; set; }
    }
}
