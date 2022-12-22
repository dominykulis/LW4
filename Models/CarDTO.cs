namespace Software.Design.Models;

public class CarDTO
{
    public string Name { get; set; } = default!;
    public int Horsepower { get; set; }
    public int Weight { get; set; } 
    public string Acceleration { get; set; } = default!;
    public int manufacturer_ID { get; set; }
}