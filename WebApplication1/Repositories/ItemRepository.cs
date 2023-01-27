using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;

namespace WebApplication1.Repositories
{
    public class ItemRepository : IitemRepository
    {

        private readonly RestDbContext restDbContext;

        public ItemRepository(RestDbContext restDbContext)
        {
            this.restDbContext = restDbContext;
        }

        public async Task<Item> AddAsync(Item items)
        {
            items.itemId = Guid.NewGuid();
            await restDbContext.AddAsync(items);
            await restDbContext.SaveChangesAsync();
            return items;
        }

        public Task<Item> DeleteAsync(Guid itemID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await restDbContext.item.ToListAsync();
        }

        public async Task<Item> GetAsync(Guid ItemID)
        {
            return await restDbContext.item.FirstOrDefaultAsync(x => x.itemId == ItemID);
        }

        public Task<Item> UpdateAsync(Guid itemID, Item items)
        {
            throw new NotImplementedException();
        }
    }
}
