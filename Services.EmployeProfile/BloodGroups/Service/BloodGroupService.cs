using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.EmployeProfile.BloodGroups.Core.DataModel;
using Services.EmployeProfile.BloodGroups.Interfaces;
using Services.EmployeProfile.EmployeDBContext;
using Services.Shared.Repository;
using Services.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmployeProfile.BloodGroups.Service
{
    public class BloodGroupService: Repository<BloodGroup>,IBloodGroupService
    {

        private readonly IBloodGroup _bloodGroup;
        private readonly ILogger<BloodGroup> _logger;
        public EmployeeDbContext _EmployeeDbContext { get; set; }

        
        public BloodGroupService(IBloodGroup bloodGroup, EmployeeDbContext EmployeeDbContext, ILogger<BloodGroup> logger) : base(EmployeeDbContext)
        {
            _EmployeeDbContext = EmployeeDbContext;
            _bloodGroup = bloodGroup;
            _logger= logger;
        }
        public async Task<Response> DeleteAsync(Guid id)
        {
            Response response = new Response();
            try
            {
                _logger.LogInformation("Deletion Process is started");
                var entity = await _bloodGroup.GetBloodGroupByIdAsync(id);
                _logger.LogInformation("BloodGroup with Id=" + id + "is going to be deleted");
                await _bloodGroup.DeleteAsync(entity);
                response.IsSucess = true;
                response.Object = entity;

            }
            catch(Exception ex)
            {
                _logger.LogInformation("An Error occur with Deletion process");
                response.IsSucess = false;
                response.ErrorMessage = ex.Message;
            }
            return response;

        }

        public async Task<BloodGroup> GetBloodGroupByIdAsync(Guid id)
        {
            return await _EmployeeDbContext.BloodGroups.Where(a => a.BloodGrpoupId == id).SingleAsync();
        }

        public async Task<List<BloodGroup>> GetAllBloodGroups()
        {
            return await _EmployeeDbContext.BloodGroups.ToListAsync();
        }
        public async Task<Response> CreateAsync(BloodGroup bloodGroup)
        {
            Response response = new Response();
            try
            {
                await _bloodGroup.CreateAsync(bloodGroup);
                response.IsSucess = true;
                response.Object = bloodGroup;
            }
            catch (Exception ex)
            {
                response.IsSucess = false;
                response.ErrorMessage = "Error Message=" + ex.Message;
            }
            
            return response;
        }
        public async Task<Response> UpdateAsync(BloodGroup bloodGroup)
        {
            Response response = new Response();
            try
            {
                await _bloodGroup.UpdateAsync(bloodGroup);
                response.IsSucess = true;
                response.Object = bloodGroup;
            }
            catch(Exception ex)
            {
                response.IsSucess = false;
                response.ErrorMessage = "Error Message" + ex.Message;
            }
            
            return response;
        }
    }
}
