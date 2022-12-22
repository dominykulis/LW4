using Microsoft.EntityFrameworkCore;
using Software.Design.DataModels;
using Software.Design.Models;

namespace Software.Design.Services;

public class CarService
{
    private readonly CarContext _dbContext;

    public CarService(CarContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Car>> Display()
    {
        var x = await _dbContext.Models.ToListAsync();
        
        return x;
    }

    public async Task<Car> Put(CarDTO carDTO)
    {
        var x = new Car(carDTO);

        await _dbContext.Models.AddAsync(x);
        await _dbContext.SaveChangesAsync();
        
        return x;
    }
    public async Task<Car> Display_ID(int id)
    {
        var x = await _dbContext.Models.Where(x => x.ID == id).FirstOrDefaultAsync();
        
        return x;
    }
    public async Task<Car> Put_ID(int id, CarDTO carDTO)
    {
        var x = await _dbContext.Models.Where(x => x.ID == id).FirstOrDefaultAsync();
        
        if(x != null)
        {

            x.Name = carDTO.Name;

            x.Horsepower = carDTO.Horsepower;

            x.Weight = carDTO.Weight;

            x.Acceleration = carDTO.Acceleration;

            x.manufacturer_ID = carDTO.manufacturer_ID;
        
        }

        await _dbContext.SaveChangesAsync();
        
        return x;
    }
    public async Task<Car> DeleteProduct(int id)
    {
        var x = await _dbContext.Models.Where(x => x.ID == id).FirstOrDefaultAsync();
        
        if(x != null)
        {
        
        _dbContext.Models.Remove(x);
        
        }

        
        await _dbContext.SaveChangesAsync();
        await _dbContext.Models.ToListAsync();
        
        return x;
    }
}