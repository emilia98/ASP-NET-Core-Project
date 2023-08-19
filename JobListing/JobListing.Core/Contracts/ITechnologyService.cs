using JobListing.Core.Models.InputModels.Technology;
using JobListing.Core.Models.ViewModels.Technology;

namespace JobListing.Core.Contracts
{
    public interface ITechnologyService
    {
        // GetAllAsync
        Task<IEnumerable<TechnologyViewModel>> GetAllAsync(bool withDeleted);

        // GetByIdAsync

        // AddAsync
        Task AddAsync(TechnologyAddInputModel model); 

        // EditAsync

        // DeleteAsync
    }
}
