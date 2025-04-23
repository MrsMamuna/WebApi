using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Services.EmployeProfile.EmployeProfiles.Core.DataModel
{
    public class EmployeeProfile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? EmployeeId { get; set; }
        [Required]
        public string? EmployeeName { get; set; }
        [Required]

        public string? Email { get; set; }
        [Required]

        public string? Contact { get; set; }
    }
}
