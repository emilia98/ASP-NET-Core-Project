using JobListing.Core.Models.InputModels.Technology;
using JobListing.Core.Models.ViewModels.Technology;

namespace JobListing.Core.Contracts
{
    public interface ITechnologyService
    {
        // GetAllAsync
        Task<IEnumerable<TechnologyViewModel>> GetAllAsync(bool withDeleted);

        // GetByIdAsync
        Task<TechnologyViewModel?> GetBtIdAsync(int id, bool withDeleted);

        // AddAsync
        Task AddAsync(TechnologyAddInputModel model);

        // GetEditModelAsync
        Task<TechnologyEditInputModel?> GetEditModelAsync(int id);

        // EditAsync
        Task<bool> EditAsync(int id, TechnologyEditInputModel model);


        // DeleteAsync
        // Task<bool> DeleteAsync(int id, bool hardDelete);
        Task<bool> DeleteAsync(int id);
    }
}
