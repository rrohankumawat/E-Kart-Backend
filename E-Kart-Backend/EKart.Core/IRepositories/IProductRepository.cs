using EKart.Core.DTOs;
using EKart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EKart.Core.IRepositories
{
    public interface IProductRepository
    {
        Task<PagedResult<Product>> GetProductsByPaginationAsync(PaginationParams pagination);
        Task<List<Product>> GetProductsByCursorAsync(int lastId, int pagesize);
    }
}
