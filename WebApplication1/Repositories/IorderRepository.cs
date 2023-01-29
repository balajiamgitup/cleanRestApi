using WebApplication1.Models.Domain;

namespace WebApplication1.Repositories
{
    public interface IorderRepository
    {
        Task<IEnumerable<order>> GetAllOrderAsync();

        Task<order> GetOrdeAsync(Guid orderId);

        Task<order> AddAsync(order orders);

        Task<order> DeleteAsync(Guid orderId);

        Task<order> UpdateAsync(Guid orderId, order orders);
    }
}
