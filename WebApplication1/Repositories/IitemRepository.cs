using WebApplication1.Models.Domain;

namespace WebApplication1.Repositories
{
    public interface IitemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();

       Task<Item> GetAsync(Guid ItemID);

        Task<Item> AddAsync(Item items);

        Task<Item> DeleteAsync(Guid itemID);

        Task<Item> UpdateAsync(Guid itemID, Item items); 
    }
}
