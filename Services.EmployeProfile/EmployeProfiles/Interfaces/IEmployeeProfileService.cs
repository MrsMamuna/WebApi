using Services.EmployeProfile.EmployeProfiles.Core.DataModel;
using Services.Shared.Interfaces;
using Services.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmployeProfile.EmployeProfiles.Interfaces
{
    public interface IEmployeeProfileService
    {
        Task<List<EmployeeProfile>> GetAll();
        Task<EmployeeProfile> GetByIdAsync(Guid id);
        Task<Response> DeleteAsync(Guid Id);
        Task<Response> CreateAsync(EmployeeProfile employeeProfile);
        Task<Response> UpdateAsync(EmployeeProfile employeeProfile);
    }
}

