using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.DTO;

namespace WebApplication1.Repositories
{
    public class OrderRepository : IorderRepository
    {


        private readonly RestDbContext restDbContext;

        public OrderRepository(RestDbContext restDbContext)
        {
            this.restDbContext = restDbContext;
        }
        public async Task<order> AddAsync(order orders)
        {
            orders.orderId = Guid.NewGuid();
            await restDbContext.AddAsync(orders);
            await restDbContext.SaveChangesAsync();
            return orders;
        }

        public Task<order> DeleteAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<order>> GetAllOrderAsync()
        {
            return await restDbContext.order.ToListAsync();
        }

        public async Task<order> GetOrdeAsync(Guid orderId)
        {
            return  await restDbContext.order.FirstOrDefaultAsync(x => x.orderId == orderId);
        }

        public Task<order> UpdateAsync(Guid orderId, order orders)
        {
            throw new NotImplementedException();
        }
    }
}
