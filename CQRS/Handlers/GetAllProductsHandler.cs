using CQRSExample.Data;
using CQRSExample.Models;
using CustomCQRS.CQRS.Interfaces;
using CustomCQRS.CQRS.Queries;
using Microsoft.EntityFrameworkCore;

namespace CustomCQRS.CQRS.Handlers;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly AppDbContext _context;

    public GetAllProductsHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> Handle(GetAllProductsQuery request)
    {
        return await _context.Products.ToListAsync();
    }
}
