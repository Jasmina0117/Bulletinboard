using System;

namespace Bulletinboard.Services
{
    public class WorkCalculatorService : IWorkCalculatorService
    {
        public double CalculateHours(double itemPrice, double hourlyWage)
        {
            if (hourlyWage <= 0)
            {
                throw new ArgumentException("Hourly wage must be greater than zero", nameof(hourlyWage));
            }
            if (itemPrice < 0)
            {
                throw new ArgumentException("Item price cannot be negative", nameof(itemPrice));
            }

            return itemPrice / hourlyWage;
        }
    }
}
