using Application.Features.Models.Dtos;
using MediatR;
using System.Security.Cryptography;

namespace Application.Features.Models.Queries.GetList;
public class GetAllModelsQuery : IRequest<List<GetAllModelsResponse>>
{
    public int BrandId { get; set; } 
    public string Name { get; set; } 
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public DateTime DeletedDate { get; set; }

}