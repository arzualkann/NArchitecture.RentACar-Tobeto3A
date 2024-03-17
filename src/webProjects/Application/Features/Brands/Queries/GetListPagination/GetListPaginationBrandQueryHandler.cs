using Application.Features.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetListPagination;

public class GetListPaginationBrandQueryHandler : IRequestHandler<GetListPaginationBrandQuery, BrandListModel>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetListPaginationBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<BrandListModel> Handle(GetListPaginationBrandQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Brand> brands = await _brandRepository.GetListPaginateAsync
            (index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        BrandListModel brandListModel = _mapper.Map<BrandListModel>(brands);
        return brandListModel;
    }
}
//index: hangi sayfadayız? size:o sayfada kaç tane istiyoruz?
//request bizim querimiz
//requestin içindeki pagerequestte bulunan page(hangi sayfa),requestin içerinde bulunan page requestteki pagesize
//page request olrak ne verilirse mesela 10 lu döndür 2. sayfayı gibi bir mantığı var 
//Ipaginate içinde  From { get; } ,int Index { get; },int Size { get; },int Count { get; },int Pages { get; },IList<T> Items { get; },bool HasPrevious { get; },bool HasNext { get; }
//brandsi brandlist modeline mapleyip return yapıyoruz.