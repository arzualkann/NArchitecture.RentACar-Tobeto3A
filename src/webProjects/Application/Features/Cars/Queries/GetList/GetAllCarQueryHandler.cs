using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cars.Queries.GetList
{
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, List<GetAllCarsResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetAllCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCarsResponse>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            List<Car> cars = await _carRepository.GetAllAsync(include: x => x.Include(x => x.Model));
            List<GetAllCarsResponse> responses = _mapper.Map<List<GetAllCarsResponse>>(cars);
            return responses;
        }

    }
}
