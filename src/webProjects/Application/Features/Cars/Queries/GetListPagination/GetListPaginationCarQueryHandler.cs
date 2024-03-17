using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetListPagination;
using Application.Features.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetListPagination;

public class GetListPaginationCarQueryHandler : IRequestHandler<GetListPaginationCarQuery, CarListModel>
{
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public GetListPaginationCarQueryHandler(ICarRepository carRepository, IMapper mapper)
    {
        _carRepository = carRepository;
        _mapper = mapper;
    }

    public async Task<CarListModel> Handle(GetListPaginationCarQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Car> cars = await _carRepository.GetListPaginateAsync
            (index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        CarListModel carListModel = _mapper.Map<CarListModel>(cars);
        return carListModel;
    }
}

