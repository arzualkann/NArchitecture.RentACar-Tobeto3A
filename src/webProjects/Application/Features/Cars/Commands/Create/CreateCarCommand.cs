using Application.Features.Cars.Dtos;
using MediatR;

namespace Application.Features.Cars.Commands.Create;

public class CreateCarCommand:IRequest<CreatedCarResponse>
{
    public double DailyPrice { get; set; }
    public int State { get; set; }  // 1- Available 2- Rented 3-Under Maitenance

}
