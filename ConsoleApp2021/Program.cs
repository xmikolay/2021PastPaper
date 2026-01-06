using ClassLibrary2021;
using Microsoft.EntityFrameworkCore;

static void list_hire_cars()
{
    using (var context = new HireContext())
    {
        //create an instance of the hire context and print out a list of all the cars that are in the database
        var cars = context.Cars.ToList();
        Console.WriteLine("List of Cars in the Database:");
        foreach (var car in cars)
        {
            Console.WriteLine($"CarID: {car.CarID}, Make: {car.Make}, Model: {car.Model}, Class: {car.Class}");
        }
    }
}

static void list_hire_revenue()
{
    using (var context = new HireContext())
    {
        //print out list of all the car makes and models hires together the total revenue for each hire of those cars
        var hireRevenues = context.Hires
            .Include(h => h.Car)
            .Select(h => new
            {
                Make = h.Car.Make,
                Model = h.Car.Model,
                Days = (h.HireEndDate - h.HireStartDate).Days,
                Revenue = ((h.HireEndDate - h.HireStartDate).Days * h.Car.CostPerDay) + h.ExtraCharge
            })
            .ToList();

        Console.WriteLine("Hire Revenue");

        foreach (var hire in hireRevenues)
        {
            Console.WriteLine($"{hire.Make} {hire.Model} - {hire.Days} days - ${hire.Revenue:F2}");
        }
    }
}

list_hire_cars();
Console.WriteLine();
list_hire_revenue();