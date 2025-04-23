using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmployeProfile.EmployeProfiles.Core.DataModel
{
    public class Teacher
    {
        public Guid TeacherId { get; set; }
        public string Name { get; set; }
        public string CNIC { get; set; }
    }
}
