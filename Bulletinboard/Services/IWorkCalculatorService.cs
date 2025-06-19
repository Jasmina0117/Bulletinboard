using System;

namespace Bulletinboard.Services
{
    public interface IWorkCalculatorService
    {
        double CalculateHours(double itemPrice, double hourlyWage);
    }
}
