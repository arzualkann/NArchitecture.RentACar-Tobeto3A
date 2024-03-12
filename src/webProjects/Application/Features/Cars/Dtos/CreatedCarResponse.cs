namespace Application.Features.Cars.Dtos;

public class CreatedCarResponse
{
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; } 
    public double DailyPrice { get; set; }
    public DateTime CreatedDate { get; set; }

}
