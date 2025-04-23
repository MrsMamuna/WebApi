using Microsoft.EntityFrameworkCore;
using Services.EmployeProfile.BloodGroups.Core.DataModel;
using Services.EmployeProfile.BloodGroups.Interfaces;
using Services.EmployeProfile.EmployeDBContext;
using Services.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmployeProfile.BloodGroups.Repositories
{
    public class BloodGroupRepository:Repository<BloodGroup>,IBloodGroup
    {
        public EmployeeDbContext _EmployeeDbContext { get; set; }
        public BloodGroupRepository(EmployeeDbContext EmployeeDbContext) : base(EmployeeDbContext)
        {
            _EmployeeDbContext = EmployeeDbContext;
        }

        public async Task<BloodGroup> GetBloodGroupByIdAsync(Guid id)
        {
            return await _EmployeeDbContext.BloodGroups.Where(a => a.BloodGrpoupId == id).SingleAsync();
        }

        //public async Task<List<BloodGroup>> GetAllBloodGroups()
        //{
        //    return await _EmployeeDbContext.BloodGroups.ToListAsync();
        //}

    }
}
