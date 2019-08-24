namespace Company.Contracts.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CompanyCreateRequest
    {
        [Required(ErrorMessage = "Company name is required")]
        [StringLength(150, ErrorMessage = "Company name name is too short or too long")]
        public string Name { get; set; }

        public string Number { get; set; }
    }
}