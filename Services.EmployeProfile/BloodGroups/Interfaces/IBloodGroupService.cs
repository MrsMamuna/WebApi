using Services.EmployeProfile.BloodGroups.Core.DataModel;
using Services.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmployeProfile.BloodGroups.Interfaces
{
    public interface IBloodGroupService
    {
        Task<Response> DeleteAsync(Guid id);
        Task<List<BloodGroup>> GetAllBloodGroups();
        Task<BloodGroup> GetBloodGroupByIdAsync(Guid id);
        Task<Response> CreateAsync(BloodGroup bloodGroup);
        Task<Response> UpdateAsync(BloodGroup bloodGroup);
    }
}
