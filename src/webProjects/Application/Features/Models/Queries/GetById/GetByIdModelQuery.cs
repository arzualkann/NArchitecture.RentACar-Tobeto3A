using Application.Features.Models.Dtos;
using MediatR;

namespace Application.Features.Models.Queries.GetById;
public class GetByIdModelQuery : IRequest<GetByIdModelResponse>
{
    public int Id { get; set; }
}
