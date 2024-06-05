public class SalaryCalculator
{
    public static decimal CalculateSalary<T>(T salaryBasePerHour, int workedHours) where T : struct
    {
        // Convert the salary base to dynamic to perform arithmetic operations
        dynamic salaryBase = salaryBasePerHour;

        // Calculate the total salary
        decimal totalSalary = (decimal)(salaryBase * workedHours);

        return totalSalary;
    }
}


