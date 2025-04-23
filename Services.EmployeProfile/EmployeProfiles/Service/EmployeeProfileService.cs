using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.EmployeProfile.EmployeDBContext;
using Services.EmployeProfile.EmployeProfiles.Core.DataModel;
using Services.EmployeProfile.EmployeProfiles.Interfaces;
using Services.Shared.Repository;
using Services.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmployeProfile.EmployeProfiles.Service
{
    public class EmployeeProfileService : Repository<EmployeeProfile>, IEmployeeProfileService
    {
        private readonly IEmployeeProfile _employeeProfile;
        private readonly ILogger<EmployeeProfile> logger;
        public EmployeeDbContext _EmployeeDbContext { get; set; }
        public EmployeeProfileService(IEmployeeProfile employeeProfile, EmployeeDbContext EmployeeDbContext) : base(EmployeeDbContext)
        {
            _EmployeeDbContext = EmployeeDbContext;
            this._employeeProfile = employeeProfile;
        }

        public async Task<Response> DeleteAsync(Guid Id)
        {

            Response response = new Response();
            try
            {
                logger.LogInformation("Deletion Process is started");
                var entity = await _employeeProfile.GetByIdAsync(Id);
                logger.LogInformation("Employee with Id=" + Id + "is going to be deleted");
                await _employeeProfile.DeleteAsync(entity);
                logger.LogInformation("Employee with Id=" + Id + "is  deleted successfully");
                response.IsSucess = true;
                response.Object = entity;
            }
            catch (Exception ex)
            {
                logger.LogInformation("An Error occur with deletion process");
                response.IsSucess = false;
                response.ErrorMessage = ex.Message;

            }
            return response;
        }

        public async Task<List<EmployeeProfile>> GetAll()
        {
            return await _EmployeeDbContext.EmployeeProfiles.ToListAsync();
        }

        public async Task<EmployeeProfile> GetByIdAsync(Guid id)
        {
            return await _EmployeeDbContext.EmployeeProfiles.Where(a => a.EmployeeId == id).SingleAsync();

        }

        public async Task<Response> CreateAsync(EmployeeProfile employeeProfile)
        {
            Response response = new Response();
            try
            {
                await _employeeProfile.CreateAsync(employeeProfile);
                response.IsSucess = true;
                response.Object = employeeProfile;
            }
            catch(Exception ex)
            {
                response.IsSucess = false;
                response.ErrorMessage = "Error Message=" + ex.Message;
            }
          
        
            return response;
        }

        public async Task<Response> UpdateAsync(EmployeeProfile employeeProfile)
        {
            Response response = new Response();
            try
            {
              await  _employeeProfile.UpdateAsync(employeeProfile);
                response.IsSucess = true;
                response.Object = employeeProfile;
            }
            catch(Exception ex)
            {
                response.IsSucess = false;
                response.ErrorMessage = "Error Message=" + ex.Message;
            }
          
            return response;    
        }
    }
}
