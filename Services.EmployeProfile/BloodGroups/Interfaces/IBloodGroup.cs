using Services.EmployeProfile.BloodGroups.Core.DataModel;
using Services.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmployeProfile.BloodGroups.Interfaces
{
    public interface IBloodGroup:IRepository<BloodGroup>
    {
        //   Task<List<BloodGroup>> GetAllBloodGroups();
        Task<BloodGroup> GetBloodGroupByIdAsync(Guid id);


    }
}
