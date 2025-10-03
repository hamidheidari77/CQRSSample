using CQRSExample.Data;
using CQRSExample.Models;
using CustomCQRS.CQRS.Commands;
using CustomCQRS.CQRS.Interfaces;


namespace CustomCQRS.CQRS.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly AppDbContext _context;

    public CreateProductHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Description = request.Description
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return product.Id;
    }
}
