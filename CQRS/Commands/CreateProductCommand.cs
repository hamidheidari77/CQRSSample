using CQRSExample.CQRS.Interfaces;
using CustomCQRS.CQRS.Interfaces;

namespace CustomCQRS.CQRS.Commands;

public class CreateProductCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Description { get; set; }
}
