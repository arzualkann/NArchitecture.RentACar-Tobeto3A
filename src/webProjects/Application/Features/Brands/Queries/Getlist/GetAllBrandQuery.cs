using Application.Features.Brands.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.Getlist;
public class GetAllBrandQuery: IRequest<List<GetAllBrandsResponse>>
{
    public int Id { get; set; }
    public string Name { get; set; } 

}
