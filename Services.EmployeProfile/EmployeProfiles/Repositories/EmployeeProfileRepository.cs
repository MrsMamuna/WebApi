using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.EmployeProfile.EmployeDBContext;
using Services.EmployeProfile.EmployeProfiles.Core.DataModel;
using Services.EmployeProfile.EmployeProfiles.Interfaces;
using Services.Shared.Repository;

namespace Services.EmployeProfile.EmployeProfiles.Repositories
{
    public class EmployeeProfileRepository : Repository<EmployeeProfile>,IEmployeeProfile
    {
        public EmployeeDbContext _EmployeeDbContext { get; set; }
        private readonly ILogger<EmployeeProfile> logger;

        public EmployeeProfileRepository(EmployeeDbContext EmployeeDbContext) : base(EmployeeDbContext)
        {
            _EmployeeDbContext = EmployeeDbContext;
        }

        //public async Task<List<EmployeeProfile>> GetAll()
        //{
        //    return await _EmployeeDbContext.EmployeeProfiles.ToListAsync();
        //}

        public async Task<EmployeeProfile> GetByIdAsync(Guid Id)
        {
            return await _EmployeeDbContext.EmployeeProfiles.Where(a => a.EmployeeId == Id).SingleAsync();
       
        }
    }
}
