using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SportsStoreAPI.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        Task<int> SaveProductAsync(Product product);
        Task<Product> DeleteProductAsync(int productId);
        IEnumerable<Order> Orders { get; }
        Task<int> SaveOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(int orderId);
    }
}