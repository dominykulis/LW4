using Microsoft.VisualStudio.TestTools.UnitTesting;
using Software.Design.Models;
using System;
using System.Diagnostics.Metrics;

namespace Testing;

[TestClass]
public class Tests
{
    [TestMethod]
    public void Inputs_From_DB_Have_Correct_Properties()
    {
        var carDTO = new CarDTO
        {
            Name = "Module R",
            Horsepower= 1236,
            Weight= 5000,
            Acceleration = "0.2 s 100km/h",
            manufacturer_ID = 4,
        };
        var car = new Car(carDTO);

        Assert.AreEqual(carDTO.Name, car.Name);
        Assert.AreEqual(carDTO.Horsepower, car.Horsepower);
        Assert.AreEqual(carDTO.Weight, car.Weight);
        Assert.AreEqual(carDTO.Acceleration, car.Acceleration);
        Assert.AreEqual(carDTO.manufacturer_ID, car.manufacturer_ID);
    }

    [TestMethod]
    public void Inputs_FromDB_Have_InCorrect_Values_ExpectedToFail()
    {
        var carDTO = new CarDTO
        {
            Name = "RGW KL;NJJKBLSDFFOSDJKHGLSFDG ;BJKLNGDSFJKL;NFBHDSLJKBNFADSKJHVBADSFLKJ;SDFGKJLHAJKLBAVENL;KJSBLHDFJKFV;lw'sjda;lkjefhgas;'ldfoisdhv",
            Horsepower= 1236,
            Weight= 5000,
            Acceleration = "sd;kljhfhsjkdfdiakodsfvauihsdjfitiugyoihjosrtdfgyuhresrtrtrtyirotufggwiohaijoakofjuhygsdhgfjvfyuvighbsdijn",
            manufacturer_ID = 4,
        };
        Assert.IsFalse(Check_Length(carDTO.Name));
        Assert.IsFalse(Check_Length(carDTO.Acceleration));
    }

    [TestMethod]
    public void Inputs_FromDB_Have_Null_Values_ExpectedToFail()
    {
        var carDTO = new CarDTO
        {
            Name = null,
            Horsepower = 0,
            Weight= 5000,
            Acceleration = null,
            manufacturer_ID = 4,
        };
        Assert.IsNull(carDTO.Name);
        Assert.IsNull(carDTO.Acceleration);
    }

    [TestMethod]
    public void Inputs_FromDB_Have_Invalid_Values_ExpectedToFail()
    {
        var carDTO = new CarDTO
        {
            Name = "Module R",
            Horsepower = 0,
            Weight= -2,
            Acceleration = "0.2 s 100km/h",
            manufacturer_ID = 8,
        };
        Assert.IsFalse(Check_Horsepower(carDTO.Horsepower));
        Assert.IsFalse(Check_Weight(carDTO.Weight));
        Assert.IsFalse(Check_ID(carDTO.manufacturer_ID));
    }
    bool Check_Length(string test_value)
    {
        return test_value.Length <= 50;
    }

    bool Check_Horsepower(int test_value)
    {
        return test_value > 0 && test_value < 2000;
    }

    bool Check_Weight(int test_value)
    {
        return test_value > 500 && test_value < 10000;
    }

    bool Check_ID(int test_value)
    {
        return test_value > 0 && test_value < 5;
    }
}