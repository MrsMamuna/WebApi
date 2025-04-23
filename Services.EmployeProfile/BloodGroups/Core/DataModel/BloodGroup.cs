using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmployeProfile.BloodGroups.Core.DataModel
{
    public class BloodGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? BloodGrpoupId { get; set; }
        public string? BloodGroupName { get; set; }
    }
}
