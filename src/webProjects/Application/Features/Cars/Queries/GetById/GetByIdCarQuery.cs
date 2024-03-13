using Application.Features.Brands.Dtos;
using Application.Features.Cars.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetById;
public class GetByIdCarQuery : IRequest<GetByIdCarResponse>
{
    public int Id { get; set; }
}
