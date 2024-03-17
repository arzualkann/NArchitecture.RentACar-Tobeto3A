using Application.Features.Brands.Models;
using Application.Features.Cars.Models;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetlistDynamic
{
    public class GetListCarDynamicQuery : IRequest<CarListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }
    }
}
