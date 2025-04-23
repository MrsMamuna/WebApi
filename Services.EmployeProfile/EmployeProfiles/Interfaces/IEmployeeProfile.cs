using Microsoft.EntityFrameworkCore;
using Services.EmployeProfile.EmployeProfiles.Core.DataModel;
using Services.Shared.Interfaces;
using Services.Shared.Repository;

namespace Services.EmployeProfile.EmployeProfiles.Interfaces
{
    public interface IEmployeeProfile : IRepository<EmployeeProfile>
    {
        //   Task<List<EmployeeProfile>> GetAll();
        //  Task<EmployeeProfile> GetByIdAsync(Guid Id);
        Task<EmployeeProfile> GetByIdAsync(Guid id);
    }

}
