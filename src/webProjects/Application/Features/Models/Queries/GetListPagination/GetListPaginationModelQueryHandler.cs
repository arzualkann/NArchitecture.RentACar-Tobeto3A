using Application.Features.Cars.Models;
using Application.Features.Cars.Queries.GetListPagination;
using Application.Features.Models.Models;
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

namespace Application.Features.Models.Queries.GetListPagination;
public class GetListPaginationModelQueryHandler : IRequestHandler<GetListPaginationModelQuery, ModelListModel>
{
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public GetListPaginationModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<ModelListModel> Handle(GetListPaginationModelQuery request, CancellationToken cancellationToken)
    {
        IPaginate<Model> models = await _modelRepository.GetListPaginateAsync
            (index: request.PageRequest.Page, size: request.PageRequest.PageSize);
        ModelListModel modelListModel = _mapper.Map<ModelListModel>(models);
        return modelListModel;
    }
}



