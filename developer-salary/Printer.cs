
namespace developer_salary
{
    internal class Printer
    {
        public static void PrintDevelopers(List<Developer> developers)
        {
            decimal totalSalary = 0;
            int totalHours = 0;

            foreach (var dev in developers)
            {
                decimal baseSalary = dev.WorkedHours * dev.SalaryByHour;
                switch (dev.Type)
                {
                    case DeveloperType.Junior:
                        dev.TotalSalary = baseSalary;
                        break;
                    case DeveloperType.Intermediate:
                        dev.TotalSalary = baseSalary * 1.12m;
                        break;
                    case DeveloperType.Senior:
                        dev.TotalSalary = baseSalary * 1.25m;
                        break;
                    case DeveloperType.Lead:
                        dev.TotalSalary = baseSalary * 1.5m;
                        break;
                }

                totalSalary += dev.TotalSalary;
                totalHours += dev.WorkedHours;

                Console.WriteLine($"Dev Name: {dev.Name}");
                Console.WriteLine($"Dev Type: {dev.Type}");
                Console.WriteLine($"Worked Hours: {dev.WorkedHours}");
                Console.WriteLine($"SalaryByHour: {dev.SalaryByHour} USD");
                Console.WriteLine($"Total Salary: {dev.TotalSalary:F2} USD");
                Console.WriteLine();
            }

            Console.WriteLine("Resume:");
            Console.WriteLine($"Total Salary: {totalSalary:F2} USD");
            Console.WriteLine($"Total Hours: {totalHours}");
            Console.WriteLine($"Total Devs: {developers.Count}");
        }
    }
}
