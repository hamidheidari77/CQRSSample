using CQRSExample.CQRS.Interfaces;
using CQRSExample.Models;
using CustomCQRS.CQRS.Interfaces;

namespace CustomCQRS.CQRS.Queries;

public class GetAllProductsQuery : IRequest<List<Product>>
{
}
