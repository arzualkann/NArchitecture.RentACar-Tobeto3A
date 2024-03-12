using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Dtos;
using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;
    public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }
    public async Task<CreatedModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        Model mappedModel = _mapper.Map<Model>(request);
        Model createdModel = await _modelRepository.AddAsync(mappedModel);
        CreatedModelResponse createdModelResponse = _mapper.Map<CreatedModelResponse>(createdModel);
        return createdModelResponse;
    }
}
