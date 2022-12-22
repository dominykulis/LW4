namespace Software.Design.Models;

public class Car
{
    public Car()
    {
    }

    public Car(CarDTO carDTO)
    {

        Name = carDTO.Name;

        Horsepower = carDTO.Horsepower;

        Weight = carDTO.Weight;

        Acceleration = carDTO.Acceleration;

        manufacturer_ID = carDTO.manufacturer_ID;
        
    }

    public int ID { get; set; }
    public string Name { get; set; } = default!;
    public int Horsepower { get; set; }
    public int Weight { get; set; } 
    public string Acceleration { get; set; } = default!;
    public int manufacturer_ID { get; set; }
}