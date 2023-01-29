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

        public async Task<Item> DeleteAsync(Guid itemID)
        {
            var item = await restDbContext.item.FirstOrDefaultAsync(x => x.itemId == itemID);

            if (item == null)
            {
                return null;
            }

            // Delete the item 
            restDbContext.item.Remove(item);
            await restDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await restDbContext.item.ToListAsync();
        }

        public async Task<Item> GetAsync(Guid ItemID)
        {
            return await restDbContext.item.FirstOrDefaultAsync(x => x.itemId == ItemID);
        }

        public async Task<Item> UpdateAsync(Guid itemID, Item items)
        {
            var existingItem = await restDbContext.item.FirstOrDefaultAsync(x => x.itemId == itemID);
            if (existingItem == null)
            {
                return null;
            }

            existingItem.name = items.name;
            existingItem.price = items.price;

            await restDbContext.SaveChangesAsync();

            return existingItem;

        }
    }
}
