using Application.Features.Cars.Dtos;
using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Commands.Delete;

public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeletedModelResponse>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<DeletedModelResponse> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        Model? model = await _modelRepository.GetAsync(c => c.Id == request.Id, include: x => x.Include(x => x.Brand));
        Model deletedModel = await _modelRepository.DeleteAsync(model);
        DeletedModelResponse response = _mapper.Map<DeletedModelResponse>(deletedModel);
        return response;
    }

}