namespace BaseProject.Domain.Model;

public class Car
{

    public int Id { get; set; }
    public required string BrandName { get; set; }
    public required string ModelName { get; set; }
    public required int Power { get; set; }
    public required int Vmax { get; set; } 
    
}
