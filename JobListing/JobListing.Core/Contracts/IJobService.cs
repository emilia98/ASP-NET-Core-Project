using JobListing.Core.Models.InputModels.Job;
using JobListing.Core.Models.ViewModels.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListing.Core.Contracts
{
    public interface IJobService
    {
        // AddAsync
        Task<bool> AddAsync(int companyId, AddJobInputModel model);

        // GetByIdAsync

        // GetAllAsync
        Task<IEnumerable<JobViewModel>> GetAllAsync(string? companyId = null);

        // UpdateAsync

        // GetJobModelAsync
    }
}
