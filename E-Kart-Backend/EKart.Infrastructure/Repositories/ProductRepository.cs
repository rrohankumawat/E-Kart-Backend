using EKart.Core.DTOs;
using EKart.Core.Entities;
using EKart.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EKart.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext.AppDbContext _context)   : IProductRepository
    {
        public async Task<PagedResult<Product>> GetProductsByPaginationAsync(PaginationParams pagination)
        {
            var query = _context.Products.AsQueryable();

            var totalRecords = await query.CountAsync();

            var data = await query
                .OrderBy(x => x.ProductId)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PagedResult<Product>
            {
                Data = data,
                TotalRecords = totalRecords,
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize
            };
        }

        public async Task<List<Product>> GetProductsByCursorAsync(int lastId, int pagesize)
        {
                var data = await _context.Products
                .Where(p => p.ProductId > lastId)
                .OrderBy(p => p.ProductId)
                .Take(pagesize)
                .ToListAsync();
            return data;
        }



    }
}
