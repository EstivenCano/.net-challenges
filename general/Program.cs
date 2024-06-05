// See https://aka.ms/new-console-template for more information

// Exercise

int salaryBaseInt = 50;
decimal salaryBaseDecimal = 50.75m;
float salaryBaseFloat = 50.5f;
double salaryBaseDouble = 50.25;

int workedHours = 160;

decimal salaryInt = SalaryCalculator.CalculateSalary(salaryBaseInt, workedHours);
decimal salaryDecimal = SalaryCalculator.CalculateSalary(salaryBaseDecimal, workedHours);
decimal salaryFloat = SalaryCalculator.CalculateSalary(salaryBaseFloat, workedHours);
decimal salaryDouble = SalaryCalculator.CalculateSalary(salaryBaseDouble, workedHours);

Console.WriteLine($"Total Salary (int): {salaryInt}");
Console.WriteLine($"Total Salary (decimal): {salaryDecimal}");
Console.WriteLine($"Total Salary (float): {salaryFloat}");
Console.WriteLine($"Total Salary (double): {salaryDouble}");

/* --------------------------------------------------------- */