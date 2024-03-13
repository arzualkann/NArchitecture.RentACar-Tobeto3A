using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.Getlist;
public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandQuery, List<GetAllBrandsResponse>>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetAllBrandsQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllBrandsResponse>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
    {
        List<Brand> brands = await _brandRepository.GetAllAsync();
        List<GetAllBrandsResponse> responses = _mapper.Map<List<GetAllBrandsResponse>>(brands);
        return responses;
    }
}