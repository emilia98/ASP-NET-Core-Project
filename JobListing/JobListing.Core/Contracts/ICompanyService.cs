using JobListing.Core.Models.InputModels.Company;
using JobListing.Core.Models.ViewModels.Company;

namespace JobListing.Core.Contracts
{
    public interface ICompanyService
    {
        Task<FullCompanyProfileViewModel?> GetCompanyProfileAsync(string id);

        Task<int?> GetCompanyId(string id);

        Task<UpdateCompanyProfileInputModel?> GetUpdateCompanyProfileAsync(string id);

        Task<bool> UpdateCompanyProfileAsync(string id, UpdateCompanyProfileInputModel model);
    }
}