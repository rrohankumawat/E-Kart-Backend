using EKart.Core.DTOs;
using EKart.Core.Entities;
using EKart.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EKart.Application.Queries.ProductQueries
{
    public class ProductQueries
    {
        public record GetProductByPaginationQuery(int pageNumber, int pageSize) : IRequest<PagedResult<Product>>;
        public record GetProductByCursorQuery(int lastId, int pageSize) : IRequest<List<Product>>;
        public class GetProductByPaginationQueryHandler(IProductRepository _productRepository) : IRequestHandler<GetProductByPaginationQuery, PagedResult<Product>>
        {
            public async Task<PagedResult<Product>> Handle(GetProductByPaginationQuery request, CancellationToken cancellationToken)
            {
                var paginationParams = new PaginationParams
                {
                    PageNumber = request.pageNumber,
                    PageSize = request.pageSize
                };
                var result = await _productRepository.GetProductsByPaginationAsync(paginationParams);
                return result;
            }
        }

        public class GetProductByCursorQueryHandler(IProductRepository _productRepository) : IRequestHandler<GetProductByCursorQuery, List<Product>>
        {
            public async Task<List<Product>> Handle(GetProductByCursorQuery request, CancellationToken cancellationToken)
            {
                var result = await _productRepository.GetProductsByCursorAsync(request.lastId, request.pageSize);
                return result;
            }
        }
    }
}
